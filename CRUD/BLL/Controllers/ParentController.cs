using System.Diagnostics;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using CRUD.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.BLL.Controllers;

[Route("api/parent")]
[ApiController]
public class ParentController(
    ParentRepository repository
    , ParentaccRepository parentaccRepository
    , ParentchildRepository parentchildRepository) :
    ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IEnumerable<Parent>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    [HttpGet("GetSingle")]
    public async Task<ActionResult<Parent>> GetSingle(Guid guid)
    {
        var data = await repository.GetAllAsync();
        var dataForResult = data.FirstOrDefault(x => x.Paruuid == guid);
        if (dataForResult is null) return NotFound($"Cannot find the parent with guid:{guid}");
        return dataForResult;
    }

    [HttpGet("GetByChildGuid")]
    public async Task<IEnumerable<Parent>> GetParentByChildGuid(Guid guid)
    {
        var parchild = await parentchildRepository.GetAllAsync();

        var parentGuids = parchild.Where(x => x.Chuuid == guid).Select(x => x.Paruuid).ToList();

        var parent = await repository.GetAllAsync();

        var result = parent.Where(x => parentGuids.Contains(x.Paruuid));

        return result;
    }


    [HttpDelete]
    public async Task<ActionResult> DeleteAction(Parent action)
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
    public async Task<ActionResult> UpdateAction(Parent action)
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
    public async Task<ActionResult> AddAction(Parent action)
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

    [HttpGet("ParentAcc")]
    public async Task<Parentacc> GetParentAccByLogin(string login)
    {
        return (await parentaccRepository.GetAllAsync()).First(x => x.Login == login);
    }

    [HttpPost("ParentAcc")]
    public async Task<ActionResult> AddNewParent(Parentacc parentacc)
    {
        try
        {
            await parentaccRepository.AddAsync(parentacc);
            return Ok("The action successfully added!");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}
