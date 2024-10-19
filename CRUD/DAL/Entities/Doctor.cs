using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public class Doctor : BaseEntity
{
    public Guid Docuuid { get; set; }

    public string Licence { get; set; } = null!;

    public int? Specid { get; set; }
    
    public virtual Medempl Docuu { get; set; } = null!;
    
    public virtual ICollection<Medcart> Medcarts { get; set; } = new List<Medcart>();
    
    public virtual Docspec? Spec { get; set; }
}
