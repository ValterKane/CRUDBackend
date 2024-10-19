using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public class Actiontype : BaseEntity
{
    public int TypeId { get; set; }
    
    public string Name { get; set; } = null!;
    
    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();
    
}
