using DAL;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.Patient;
using DAL.Models.Test;
using DAL.Models.User;
using DAL.Repositories;
using WEBAPI.Interfaces;
using WEBAPI.Services;
using WEBAPP.Interfaces;
using WEBAPP.Services;

var builder = WebApplication.CreateBuilder(args);

var dbConfigurationSection = builder.Configuration.GetSection("DbConfig");
var dbConfig = dbConfigurationSection.Get<DbConfig>();

builder.Services.Configure<DbConfig>(dbConfigurationSection);

builder.Services
    .AddIdentity<UserIdentity, RoleIdentity>()
    .AddMongoDbStores<UserIdentity, RoleIdentity, Guid>(dbConfig.ConnectionString, dbConfig.DatabaseName)
;

builder.Services.AddSingleton<ICodesService, CodesService>();
builder.Services.AddSingleton<ITestHandler, TestHandler>();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

builder.Services.AddSingleton<IRepository<Test>, TestsRepository>();
builder.Services.AddSingleton<IRepository<Device>, DevicesRepository>();
builder.Services.AddSingleton<IRepository<DeviceLinkInfo>, CodesRepository>();
builder.Services.AddSingleton<IRepository<Region>, RegionsRepository>();
builder.Services.AddSingleton<IRepository<MedicalInstitution>, MedicalInstitutionsRepository>();
builder.Services.AddSingleton<IRepository<Patient>, PatientsRepository>();
builder.Services.AddSingleton<IRepository<TestStatus>, TestStatusesRepository>();
builder.Services.AddSingleton<IRepository<PatientStatus>, PatientStatusesRepository>();
builder.Services.AddSingleton<IRepository<Sex>, PatientSexesRepository>();
builder.Services.AddSingleton<IRepository<Record>, HistoryRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/build";
});

const string policyName = "frontend";
builder.Services.AddCors(
    options => options.AddPolicy(
        name: policyName, 
        policy => policy
            .WithOrigins(new []{"https://localhost:44452"})
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    
}

//app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseRouting();

app.UseCors(policyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action?}/{id?}");

//app.MapFallbackToFile("index.html");

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

});

app.Run();