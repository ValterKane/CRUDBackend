using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.DAL.Entities.Abstraction;

namespace CRUD.DAL.Entities;

public class Analyseresult : BaseEntity
{
    public long Resid { get; set; }
    
    public Guid Empluuid { get; set; }
    
    public int TypeOfAnalyse { get; set; }
    
    public string? Resultcomment { get; set; }
    
    public string Result { get; set; } = null!;

    public Guid Childuuid { get; set; }
    
    public virtual Analysetype? Analysetype { get; set; }
    
    public virtual Medempl? Empluu { get; set; }
    
    public virtual Child? Chuu { get; set; }
}
