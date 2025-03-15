namespace CRUD.BLL.DTO;

public class MedEmplDTO
{
    public Guid Empluuid { get;  set; }

    public string Firstname { get;  set; } = null!;

    public string Secondname { get;  set; } = null!;

    public string Lastname { get;  set; } = null!;

    public int? Catsid { get;  set; }
}
