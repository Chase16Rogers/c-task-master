using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_master_api.Models;
using task_master_api.Services;

namespace task_master_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly ProfilesService _PS;

    public AccountsController(ProfilesService pS)
    {
      _PS = pS;
    }
  
    [HttpGet]
    public async Task<ActionResult<Profile>> Get()
    {
        try
        {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok (_PS.GetOrCreateProfile(userInfo));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    }
}