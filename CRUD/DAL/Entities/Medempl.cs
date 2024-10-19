using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.DAL.Entities.Abstraction;

namespace CRUD.DAL.Entities;

public class Medempl : BaseEntity
{
    public Guid Empluuid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Secondname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int? Catid { get; set; }
    
    public virtual ICollection<Analyseresult> Analyseresults { get; set; } = new List<Analyseresult>();
    
    public virtual Category? Cat { get; set; }
    
    public virtual Doctor? Doctor { get; set; }
    
    public virtual Emplsaccdatum? Emplsaccdatum { get; set; }
}
