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
    
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    
    public virtual Actiontype? ActionType { get; set; }
}
