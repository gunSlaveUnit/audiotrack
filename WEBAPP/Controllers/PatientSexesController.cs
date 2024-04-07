using DAL.Interfaces;
using DAL.Models.Patient;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.Controllers.Base;

namespace WEBAPI.Controllers;

[ApiController]
[Route("api/patient-sexes")]
public class PatientSexesController : CrudController<Sex>
{
    public PatientSexesController(IRepository<Sex> repository) : base(repository)
    {
    }
}