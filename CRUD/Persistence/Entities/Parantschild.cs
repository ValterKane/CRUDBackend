using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.DAL.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Entities;

public partial class Parantschild : BaseEntity
{
    public Guid Chuuid { get; set; }
    
    public Guid Paruuid { get; set; }

    public string Kinship { get; set; } = null!;
    
    public virtual Child Chuu { get; set; } = null!;
    
    public virtual Parent Paruu { get; set; } = null!;
}
