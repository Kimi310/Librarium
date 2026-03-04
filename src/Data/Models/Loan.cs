using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Loan
{
    public long Id { get; set; }

    public long BookId { get; set; }

    public long MemberId { get; set; }

    public DateOnly LoanDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
