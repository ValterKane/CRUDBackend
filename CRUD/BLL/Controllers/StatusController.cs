using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Action = CRUD.DAL.Entities.Action;

namespace CRUD.BLL.Controllers;

[Route("api/status")]
[ApiController]
public class StatusController(MyDbContext unitOfWork) : ControllerBase
{
    private MyDbContext _unitOfWork = unitOfWork;

    [HttpGet]
    public ActionResult GetStatus()
    {
        return Ok("Server online!");
    }

    [HttpGet("Children")]
    public async Task<List<Child>> GetChildInfo()
    {
        await _unitOfWork.Children.LoadAsync();
        return _unitOfWork.Children.Local.ToList();
    }

    [HttpGet("ActionList")]
    public async Task<List<Action>> GetActionAct()
    {
        await _unitOfWork.Actions.LoadAsync();
        return _unitOfWork.Actions.Local.ToList();
    }
    
    
}