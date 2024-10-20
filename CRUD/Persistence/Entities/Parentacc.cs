using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.DAL.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Entities;

public  class Parentacc : BaseEntity
{
    public Guid Paruuid { get; set; }
    public string Login { get; set; } = null!;

    public string HashPass { get; set; } = null!;

    public short Status { get; set; }
    
    public virtual Parent Paruu { get; set; } = null!;
}
