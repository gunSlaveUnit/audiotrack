using System.Security.Claims;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.Controllers.Base;

namespace WEBAPP.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController : CrudController<Patient>
{
    private readonly IRepository<Record> _historyRepository;
    private readonly UserManager<UserIdentity> _userManager;
    
    public PatientsController(IRepository<Patient> patientsRepository, 
        IRepository<Record> historyRepository, UserManager<UserIdentity> userManager) 
        : base(patientsRepository)
    {
        _historyRepository = historyRepository;
        _userManager = userManager;
    }
    
    [HttpPut("{id:length(24)}")]
    public override async Task<IActionResult> Update(string id, Patient updated)
    {
        var e = await Repository.GetAsync(id);

        if (e is null)
            return NotFound();

        updated.Id = e.Id;

        if (e.Status != updated.Status)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userManager.FindByIdAsync(userId);
        
            var historyChangeStatusRecord = new Record
            {
                DateChange = DateTime.Now,
                Patient = id,
                NewStatus = updated.Status,
                User = currentUser.UserName
            };

            await _historyRepository.CreateAsync(historyChangeStatusRecord);
        }

        await Repository.UpdateAsync(id, updated);

        return NoContent();
    }
}