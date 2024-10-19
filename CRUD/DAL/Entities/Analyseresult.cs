using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public class Analyseresult : BaseEntity
{
    public long Resid { get; set; }
    
    public Guid Empluuid { get; set; }
    
    public int Analystype { get; set; }
    
    public string? Resultcomment { get; set; }
    
    public string Result { get; set; } = null!;
    
    public virtual Analysetype AnalystypeNavigation { get; set; } = null!;
    
    public virtual Medempl Empluu { get; set; } = null!;
}
