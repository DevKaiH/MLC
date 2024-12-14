using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class TblEftlog
{
    public int Id { get; set; }

    public int? Fcn { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUploaded { get; set; }

    public int? Status { get; set; }

    public string? UserName { get; set; }
}
