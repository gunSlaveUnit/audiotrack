using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.Controllers.Base;

namespace WEBAPP.Controllers;

[ApiController]
[Route("api/history")]
public class HistoryController : CrudController<Record>
{
    public HistoryController(IRepository<Record> repository) : base(repository)
    {
        
    }
    
    [HttpGet("patient/{id:length(24)}")]
    public virtual async Task<List<Record>> GetRecordsForPatient(string id)
    {
        var records = await Repository.GetAsync();
        var patientHistory = records.FindAll(r => r.Patient == id);

        return patientHistory;
    }
}