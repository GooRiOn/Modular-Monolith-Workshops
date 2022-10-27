using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MySpot.Modules.Cleaning.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CleaningController : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public string Get() => "Cleaning Module";
}