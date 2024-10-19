using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD.DAL.Entities.Abstraction;

namespace CRUD.DAL.Entities;

public class Voucher : BaseEntity
{
    public int Void { get; set; }

    public Guid Paruuid { get; set; }
    
    public DateTime Checkin { get; set; }
    
    public DateTime Checkout { get; set; }

    public string Sourcevo { get; set; } = null!;
    
    public virtual Parent Paruu { get; set; } = null!;
}
