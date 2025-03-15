using System.Diagnostics;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using CRUD.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.BLL.Controllers;

[Route("api/child")]
[ApiController]
public class ChildController(ChildRepository repository, ParentchildRepository parentchildRepository) : ControllerBase
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

    [HttpGet("ChildrenByParentGuid")]
    public async Task<IEnumerable<Child>> GetAllChildByParentGuid(Guid guid)
    {
        var data = await parentchildRepository.GetAllAsync();
      
        if (data.Count() > 0)
        {
            var parchildForCurrentParent = data.Where(x => x.Paruuid == guid);
            var listOfChildrenGuid = parchildForCurrentParent.Select(x => x.Chuuid).ToList();
            var children = await repository.GetAllAsync();

            var childrenSelection = new List<Child>();

            foreach (var child in children)
            {
                if (listOfChildrenGuid.Contains(child.Chuuid))
                {
                    childrenSelection.Add(child);
                }
            }
            
            return childrenSelection;
        }

        return null;
    }
}
