using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DAL.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;

namespace WEBAPI.Controllers;

//TODO: maybe we don't need this controller

[ApiController]
[Route("api/roles")]
public class RolesController : ControllerBase
{
    private readonly RoleManager<RoleIdentity> _roleManager;

    public RolesController(RoleManager<RoleIdentity> roleManager)
    {
        _roleManager = roleManager;
    }
    
    #region POST 
    
    public class Role
    {
        [Required]
        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    
    [HttpPost]
    public async Task<ActionResult> Create(Role role)
    {
        if (!ModelState.IsValid) return BadRequest();

        var roleIdentity = new RoleIdentity { Name = role.Name };
        
        var result = await _roleManager.CreateAsync(roleIdentity);

        if (result.Succeeded) 
            return CreatedAtAction(nameof(Create), new { id = roleIdentity.Id }, roleIdentity);
        
        foreach (var error in result.Errors)
            ModelState.AddModelError(error.Code, error.Description);

        return BadRequest();
    }
    
    #endregion
}