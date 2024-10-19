using System.Diagnostics;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.BLL.Controllers;

[Route("api/schedule")]
[ApiController]
public class ScheduleController(ScheduleRepository repository) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IEnumerable<Schedule>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    [HttpGet("GetSingle")]
    public async Task<ActionResult<Schedule>> GetSingle(DateTime timeStamp)
    {
        var data = await repository.GetAllAsync();
        var dataForResult = data.FirstOrDefault(x => x.Timemark == timeStamp);
        if (dataForResult is null) return NotFound($"Cannot find the action with guid:{timeStamp}");
        return dataForResult;
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAction(Schedule action)
    {
        try
        {
            await Task.Run(() => repository.Delete(action));
            return Ok("The action successfully deleted!");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAction(Schedule action)
    {
        try
        {
            await Task.Run(() => repository.Update(action));
            return Ok("The action successfully updated!");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddAction(Schedule action)
    {
        try
        {
            await repository.AddAsync(action);
            return Ok("The action successfully added!");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}
