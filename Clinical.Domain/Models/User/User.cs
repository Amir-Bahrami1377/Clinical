using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical.Domain.Models.User;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int NationalId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    [MaxLength(350)]
    public string Email { get; set; } = string.Empty;
    public bool IsEmailActive { get; set; } = false;
    public string PasswordHash { get; set; } = string.Empty;
    [Display(Name ="shomare")]
    [Required(ErrorMessage ="shomare ra vared konid")]
    public int PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}
