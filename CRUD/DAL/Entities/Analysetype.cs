using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.DAL.Entities.Abstraction;

namespace CRUD.DAL.Entities;

public class Analysetype : BaseEntity
{
    public int Typeid { get; set; }

    public string Name { get; set; } = null!;
    
    public virtual ICollection<Analyseresult> Analyseresults { get; set; } = new List<Analyseresult>();
}