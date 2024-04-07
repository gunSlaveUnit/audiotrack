using DAL.Interfaces;
using DAL.Models.Test;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.Controllers.Base;

namespace WEBAPI.Controllers;

[ApiController]
[Route("api/test-statuses")]
public class TestStatusesController : CrudController<TestStatus>
{
    public TestStatusesController(IRepository<TestStatus> statusesRepository) : base(statusesRepository)
    {
    }
}