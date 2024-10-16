using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public partial class Schedule
{
    public DateTime Timemark { get; set; }

    public Guid Actuuid { get; set; }

    public Guid Chuuid { get; set; }

    public string Place { get; set; } = null!;
    
    public virtual Action Actuu { get; set; } = null!;
    
    public virtual Child Chuu { get; set; } = null!;
}
