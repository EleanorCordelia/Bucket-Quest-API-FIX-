using BucketQuestAPI.Controllers;
using BucketQuestAPI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace BucketQuestAPI;

public class GoogleLoginController : BaseApiController {
    private readonly ILogger<GoogleLoginController> _logger;
    private readonly DataContext _context;
    public GoogleLoginController(ILogger<GoogleLoginController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
        {
            _logger.LogInformation("Google Login Index");
            _logger.LogInformation(Url.Action("GoogleResponse", "GoogleLogin"));
            return new ChallengeResult(
                GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = "http://localhost:5103" + Url.Action("GoogleResponse", "GoogleLogin") // Where google responds back
                });
        }
    [HttpPost]
    public IActionResult GoogleResponse()
    {
        _logger.LogInformation("Google Login Response");
        return Ok();
    }
    

}