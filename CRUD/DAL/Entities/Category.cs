using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public partial class Category : BaseEntity
{
    public int Catid { get; set; }

    public string Catname { get; set; } = null!;
    
    public virtual ICollection<Medempl> Medempls { get; set; } = new List<Medempl>();
}
