using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Book
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public int PublicationYear { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
