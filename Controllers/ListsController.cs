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
    public class ListsController : ControllerBase
    {
        private readonly ListsService _LS;

    public ListsController(ListsService lS)
    {
      _LS = lS;
    }

    [HttpGet("{id}")]
    public ActionResult<List> Get(int id)
    {
        try
        {
            return Ok(_LS.GetOne(id));
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpPost]
    public ActionResult<List> Create([FromBody] List newList)
    {
        try
        {
            return Ok(_LS.Create(newList));
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpPut("{id}")]
    public ActionResult<List> Edit(int id, [FromBody] List editList)
    {
        try
        {
            return Ok(_LS.Edit(id, editList));
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpDelete("{id}")]
    public ActionResult<List> Delete(int id)
    {
        try
        {
            return Ok(_LS.Delete(id));
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
    }


  }
}