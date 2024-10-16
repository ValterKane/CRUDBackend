using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public partial class Voucher
{
    public int Void { get; set; }

    public Guid Paruuid { get; set; }
    
    public DateTime Checkin { get; set; }
    
    public DateTime Checkout { get; set; }

    public string Sourcevo { get; set; } = null!;
    
    public virtual Parent Paruu { get; set; } = null!;
}
