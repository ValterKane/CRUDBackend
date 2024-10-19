using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public class Parent : BaseEntity
{
    public Guid Paruuid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Secondname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Age { get; set; }
    
    public virtual Parantschild? Parantschild { get; set; }
    
    public virtual Parentacc? Parentacc { get; set; }
    
    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
