using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class TblAccount
{
    public int Id { get; set; }

    public string? Acct { get; set; }

    public string? Description { get; set; }
}
