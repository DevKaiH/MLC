using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class VRecipient
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Bank { get; set; }

    public string? Transit { get; set; }

    public string? Account { get; set; }

    public string? Cell { get; set; }

    public string? Cpa { get; set; }

    public string? Recipients { get; set; }
}
