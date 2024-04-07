using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.Controllers.Base;

namespace WEBAPP.Controllers;

[ApiController]
[Route("api/medical_institutions")]
public class MedicalInstitutionsController : CrudController<MedicalInstitution>
{
    public MedicalInstitutionsController(IRepository<MedicalInstitution> medicalInstitutionsRepository) 
        : base(medicalInstitutionsRepository)
    {
        
    }
    
    [HttpGet("region/{id:length(24)}")]
    public virtual async Task<List<MedicalInstitution>> GetAsyncByRegion(string id)
    {
        var institutions = await Repository.GetAsync();
        var filtered = institutions.FindAll(i => i.Region == id);

        return filtered;
    }
}