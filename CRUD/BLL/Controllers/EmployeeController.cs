using System.Diagnostics;
using System.Net;
using CRUD.BLL.DTO;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using CRUD.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;
using Action = System.Action;

namespace CRUD.BLL.Controllers;

[Route("api/employee")]
[ApiController]
public class EmployeeController(MedemplRepository repository, EmplaccRepository emplaccRepository) : ControllerBase
{
    [HttpGet("MedUser")]
    public async Task<ActionResult<Emplsaccdatum>> GetUserByLogin(string login)
    {
        var badRequestedData = (await emplaccRepository.GetAllAsync()).FirstOrDefault(x => x.Login == login);

        if (badRequestedData == null)
        {
           return NotFound($"User with {login} not found!");
        }
        else
        {
           return Ok(badRequestedData);
        }
    }

    [HttpGet("GetAll")]
    public async Task<IEnumerable<Medempl>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    [HttpGet("GetSingle")]
    public async Task<ActionResult<Medempl>> GetSingle(Guid guid)
    {
        var data = await repository.GetAllAsync();
        var dataForResult = data.FirstOrDefault(x => x.Empluuid == guid);
        if (dataForResult is null) return NotFound($"Cannot find the employee with guid:{guid}");
        return dataForResult;
    }

    [HttpDelete("MedUser")]
    public async Task<ActionResult> DeleteAction([FromBody] Guid targetGuid)
    {
        try
        {
            await Task.Run(() => repository.Delete(new Medempl(){Empluuid = targetGuid}));
            return Ok("The action successfully deleted!");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("MedUserAcc")]
    public async Task<ActionResult> DeleteMedUser([FromBody] Guid targetGuid)
    {
        try
        {
            await Task.Run(() => emplaccRepository.Delete(new Emplsaccdatum()
            {
                Empluuid = targetGuid,
            }));

            return Ok("Successful complete");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAction(Medempl action)
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
    public async Task<ActionResult> AddAction(Medempl action)
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

    [HttpPost("MedUserAcc")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddNewMedUserAcc([FromBody] Emplsaccdatum medUserAcc)
    {
        try
        {
            await emplaccRepository.AddAsync(medUserAcc);
            return Ok("Successfully added!");
        }
        catch (Exception e)
        {
            if (e is ArgumentException)
                return Conflict(e.Message);
            
            return BadRequest(e.Message);
        }
        
    }

    [HttpPost("MedUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddNewMedUser([FromBody] Medempl medEmpl)
    {
        try
        {
            await repository.AddAsync(medEmpl);
            return Ok("Successful complete!");
        }
        catch (Exception e)
        {
            if (e is ArgumentException)
                return Conflict(e.Message);
            
            return BadRequest(e.Message);
        }
    }
}
