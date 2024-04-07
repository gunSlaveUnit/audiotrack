using DAL.Interfaces;
using DAL.Models.Patient;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.Controllers.Base;

namespace WEBAPI.Controllers;

[ApiController]
[Route("api/patient-statuses")]
public class PatientStatusesController: CrudController<PatientStatus>
{
    public PatientStatusesController(IRepository<PatientStatus> repository) : base(repository)
    {
    }
}