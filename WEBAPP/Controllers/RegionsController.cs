using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.Controllers.Base;

namespace WEBAPI.Controllers;

[ApiController]
[Route("api/regions")]
public class RegionsController : CrudController<Region>
{
    public RegionsController(IRepository<Region> regionsRepository) 
        : base(regionsRepository)
    {
        
    }
}