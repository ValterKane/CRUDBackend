using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.DAL.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Entities;

public partial class Emplsaccdatum : BaseEntity
{
    public Guid Empluuid { get; set; }
    
    public string Login { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string Role { get; set; } = null!;
    
    public virtual Medempl Empluu { get; set; } = null!;
}
