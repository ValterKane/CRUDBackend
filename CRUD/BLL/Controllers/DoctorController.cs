using System.Diagnostics;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.BLL.Controllers;

[Route("api/doctor")]
[ApiController]
public class DoctorController(DoctorRepository repository) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    [HttpGet("GetSingle")]
    public async Task<ActionResult<Doctor>> GetSingle(Guid guid)
    {
        var data = await repository.GetAllAsync();
        var dataForResult = data.FirstOrDefault(x => x.Docuuid == guid);
        if (dataForResult is null) return NotFound($"Cannot find the doctor with guid:{guid}");
        return dataForResult;
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAction(Doctor action)
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
    public async Task<ActionResult> UpdateAction(Doctor action)
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
    public async Task<ActionResult> AddAction(Doctor action)
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
