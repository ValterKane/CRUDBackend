using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public class Action
{
    public Guid Actuuid { get; set; }
    
    public string Name { get; set; } = null!;
    
    public int Typeid { get; set; }
    
    public string Schedule { get; set; } = null!;
    
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    
    [ForeignKey("Typeid")]
    public virtual Actiontype? ActionType { get; set; }
}
