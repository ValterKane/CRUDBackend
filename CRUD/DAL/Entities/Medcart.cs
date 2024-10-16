using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Entities;

public class Medcart
{
    public DateTime Timemark { get; set; }
    public Guid Chuuid { get; set; }

    public string? Textresult { get; set; }

    public Guid Docuuid { get; set; }
    
    public virtual Child Chuu { get; set; } = null!;
    
    public virtual Doctor Docuu { get; set; } = null!;
}
