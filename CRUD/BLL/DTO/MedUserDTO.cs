using System.Text.Json.Serialization;

namespace CRUD.BLL.DTO;

public class MedUserDTO
{
    public Guid MedUserGuid { get; set; }
    
    public string MedUserLogin { get; set; }
    
    public string HashedPassword { get; set; }
    
    public string Role { get; set; }
}
