using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DataAccess;

public partial class Account
{
    [Required]
    [StringLength(50), MinLength(1)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "UserName is required")]
    [RegularExpression(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)*$", ErrorMessage = "Error RegularExpression")]
    [StringLength(50), MinLength(5)]
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
