using System.Diagnostics;
using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Action = CRUD.DAL.Entities.Action;

namespace CRUD.BLL.Controllers;

[Route("api/action")]
[ApiController]
public class ActionController(ActionRepository repository) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IEnumerable<Action>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    [HttpGet("GetSingle")]
    public async Task<ActionResult<Action>> GetSingle(Guid guid)
    {
        var data = await repository.GetAllAsync();
        var dataForResult = data.FirstOrDefault(x => x.Actuuid == guid);
        if (dataForResult is null) return NotFound($"Cannot find the action with guid:{guid}");
        return dataForResult;
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAction(Action action)
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
    public async Task<ActionResult> UpdateAction(Action action)
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
    public async Task<ActionResult> AddAction(Action action)
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
