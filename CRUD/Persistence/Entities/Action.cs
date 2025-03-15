using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.DAL.Entities.Abstraction;

namespace CRUD.DAL.Entities;

public class Action : BaseEntity
{
    public Guid Actuuid { get; set; }
    
    public string Name { get; set; } = null!;
    
    public int Typeid { get; set; }
    
    public string Schedule { get; set; } = null!;
    
    // 1 - M
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    
    // 1 - 1
    public virtual Actiontype? ActionType { get; set; }
}
