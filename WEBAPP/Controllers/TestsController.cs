using DAL.Interfaces;
using DAL.Models.Test;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.Controllers.Base;
using WEBAPP.Interfaces;

namespace WEBAPP.Controllers;

[ApiController]
[Route("api/tests")]
public class TestsController : CrudController<Test>
{
    private readonly ITestHandler _testHandler;
    public TestsController(IRepository<Test> testsRepository, ITestHandler testHandler) : base(testsRepository)
    {
        _testHandler = testHandler;
    }
    
    #region Handle
    
    [HttpPost("handle")]
    public async Task<IActionResult> Handle(Test e)
    {
        await _testHandler.HandleTestToChangePatientStatus(e);

        return CreatedAtAction(nameof(Get), new { id = e.Id }, e);
    }

    #endregion
}