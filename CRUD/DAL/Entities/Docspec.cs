using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DAL.Entities;

public class Docspec
{
    public int Specid { get; set; }

    public string Specname { get; set; } = null!;
    
    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
