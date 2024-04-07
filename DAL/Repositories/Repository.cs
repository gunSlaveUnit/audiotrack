using DAL.Interfaces;
using DAL.Models;
using DAL.Models.Base;
using DAL.Models.Patient;
using DAL.Models.Test;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DAL.Repositories;

public class Repository<T> : IRepository<T> where T : Entity, new()
{
    private readonly IMongoCollection<T> _collection;

    protected Repository(IOptions<DbConfig> context, string collectionName)
    {
        var mongoClient = new MongoClient(
            context.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            context.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<T>(collectionName);
    }

    public async Task<List<T>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<T> CreateAsync(T newBook)
    {
        await _collection.InsertOneAsync(newBook);
        return newBook;
    }

    public async Task UpdateAsync(string id, T updatedBook) =>
        await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}

public class TestsRepository : Repository<Test>
{
    public TestsRepository(IOptions<DbConfig> context) :
        base(context, "tests")
    {
        
    }
}

public class DevicesRepository : Repository<Device>
{
    public DevicesRepository(IOptions<DbConfig> context) :
        base(context, "devices")
    {
        
    }
}

public class CodesRepository : Repository<DeviceLinkInfo>
{
    public CodesRepository(IOptions<DbConfig> context) :
        base(context, "codes")
    {
        
    }
}

public class RegionsRepository : Repository<Region>
{
    public RegionsRepository(IOptions<DbConfig> context) :
        base(context, "regions")
    {
        
    }
}

public class MedicalInstitutionsRepository : Repository<MedicalInstitution>
{
    public MedicalInstitutionsRepository(IOptions<DbConfig> context) :
        base(context, "medical_institutions")
    {
        
    }
}

public class PatientsRepository : Repository<Patient>
{
    public PatientsRepository(IOptions<DbConfig> context) :
        base(context, "patients")
    {
        
    }
}

public class TestStatusesRepository : Repository<TestStatus>
{
    public TestStatusesRepository(IOptions<DbConfig> context) :
        base(context, "test_statuses")
    {
        
    }
}

public class PatientStatusesRepository : Repository<PatientStatus>
{
    public PatientStatusesRepository(IOptions<DbConfig> context) :
        base(context, "patient_statuses")
    {
        
    }
}

public class PatientSexesRepository : Repository<Sex>
{
    public PatientSexesRepository(IOptions<DbConfig> context) :
        base(context, "sexes")
    {
        
    }
}

public class HistoryRepository : Repository<Record>
{
    public HistoryRepository(IOptions<DbConfig> context) :
        base(context, "history")
    {
        
    }
}