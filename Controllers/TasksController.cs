using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_master_api.Models;
using task_master_api.Services;

namespace task_master_api.Controllers
{
    [ApiController]
    [Route("api/controller")]
    [Authorize]
    public class TasksController : ControllerBase
    {
           private readonly TasksService _LS;

    public TasksController(TasksService lS)
    {
      _LS = lS;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Task>> Get()
    {
        try
        {
            return Ok(_LS.GetAll());
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpGet("{id}")]
    public ActionResult<Task> Get(int id)
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
    public ActionResult<Task> Create([FromBody] Task newTask)
    {
        try
        {
            return Ok(_LS.Create(newTask));
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpPut("{id}")]
    public ActionResult<Task> Edit(int id, [FromBody] Task editTask)
    {
        try
        {
            return Ok(_LS.Edit(id, editTask));
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpDelete("{id}")]
    public ActionResult<Task> Delete(int id)
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