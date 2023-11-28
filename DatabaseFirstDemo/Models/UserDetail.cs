using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo.Models;

public partial class UserDetail
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
