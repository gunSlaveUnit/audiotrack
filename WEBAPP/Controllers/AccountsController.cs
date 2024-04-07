using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;
using DAL.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPP.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController: ControllerBase
{
    private readonly UserManager<UserIdentity> _userManager;
    private readonly SignInManager<UserIdentity> _signInManager;
    public AccountsController(UserManager<UserIdentity> userManager, 
        SignInManager<UserIdentity> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    #region SignUp

    public class SignUpRequestModel
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [Required]
        [JsonPropertyName("email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("passwordConfirm")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
    
    [HttpPost]
    [Route("signup")]
    public async Task<ActionResult> SignUp([FromBody] SignUpRequestModel model)
    {
        IEnumerable<string>? errors;
        if (ModelState.IsValid)
        {
            var user = new UserIdentity()
            {
                Email = model.Email,
                UserName = model.Name
            };
            
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "audiologist");

                await _signInManager.SignInAsync(user, false);
                
                return CreatedAtAction(nameof(SignUp), new { id = user.Id }, user);
            }
            
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
            
            errors = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage));
            return BadRequest(errors);
        }

        errors = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage));
        return BadRequest(errors);
    }

    #endregion

    #region LogIn

    public class LogInRequestModel
    {
        [Required]
        [JsonPropertyName("email")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [JsonPropertyName("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [JsonPropertyName("rememberMe")] 
        public bool RememberMe { get; set; }
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> LogIn([FromBody] LogInRequestModel model)
    {
        IEnumerable<string>? errors;
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            
            var result =
                await _signInManager.PasswordSignInAsync(
                    user, model.Password,
                    model.RememberMe, false);
            
            if (result.Succeeded)
                return Ok();
            
            ModelState.AddModelError("", "Invalid email and/or password");
               
            errors = ModelState.Values.SelectMany(e =>
                e.Errors.Select(er => er.ErrorMessage));
            
            return BadRequest(errors);
        }
        
        errors = ModelState.Values.SelectMany(e =>
            e.Errors.Select(er => er.ErrorMessage));
            
        return BadRequest(errors);
    }

    #endregion

    #region LogOut

    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        
        return Ok();
    }

    #endregion
    
    #region User 
    
    [HttpGet]
    [Route("user")]
    public async Task<IActionResult> GetUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (!string.IsNullOrEmpty(userId))
            return Ok(new {user = userId});
        
        return BadRequest();
    }
    
    #endregion
}