using System.Diagnostics;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.BLL.Controllers;

[Route("api/child")]
[ApiController]
public class ChildController(ChildRepository repository) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IEnumerable<Child>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    [HttpGet("GetSingle")]
    public async Task<ActionResult<Child>> GetSingle(Guid guid)
    {
        var data = await repository.GetAllAsync();
        var dataForResult = data.FirstOrDefault(x => x.Chuuid == guid);
        if (dataForResult is null) return NotFound($"Cannot find the child with guid:{guid}");
        return dataForResult;
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAction(Child action)
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
    public async Task<ActionResult> UpdateAction(Child action)
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
    public async Task<ActionResult> AddAction(Child action)
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
