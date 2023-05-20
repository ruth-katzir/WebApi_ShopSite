using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO;

public partial class UserDTO
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [StringLength(maximumLength: 20, ErrorMessage = "too long password")]

    public string Password { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Email not valid")]

    public string Email { get; set; } = null!;
}

