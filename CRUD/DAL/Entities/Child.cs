using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public class Child : BaseEntity
{
    public Guid Chuuid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Secondname { get; set; } = null!;

    public string Lastname { get; set; } = null!;
    
    public int? Age { get; set; }
    
    public virtual ICollection<Medcart> Medcarts { get; set; } = new List<Medcart>();
    
    public virtual Parantschild? Parantschild { get; set; }
    
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
