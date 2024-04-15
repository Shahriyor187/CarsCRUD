using System.ComponentModel.DataAnnotations;

namespace CarsCRUD.Entity;
public class User : BaseEntity
{
    [Required, StringLength(30)]
    public string UserName { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}