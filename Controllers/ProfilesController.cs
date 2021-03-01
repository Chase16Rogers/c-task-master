using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_master_api.Models;
using task_master_api.Services;

namespace task_master_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProfilesController : ControllerBase
    {
    private readonly ListsService _LS;

    public ProfilesController(ListsService lS)
    {
      _LS = lS;
    }

    [HttpGet("{id}/lists")]
    public ActionResult<IEnumerable<List>> Get(string id)
    {
        try
        {
            return Ok(_LS.GetListsByCreator(id));
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    }
}