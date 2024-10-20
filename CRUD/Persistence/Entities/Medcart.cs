using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.DAL.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Entities;

public class Medcart : BaseEntity
{
    public DateTime Timemark { get; set; }
    public Guid Chuuid { get; set; }

    public string? Textresult { get; set; }

    public Guid Docuuid { get; set; }
    
    public virtual Child Chuu { get; set; } = null!;
    
    public virtual Doctor Docuu { get; set; } = null!;
}
