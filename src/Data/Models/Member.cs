using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Member
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
