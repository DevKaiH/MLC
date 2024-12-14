using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class TblPclog
{
    public int Id { get; set; }

    public DateOnly? DateCreated { get; set; }

    public int UserID { get; set; }

    public DateOnly? DateUploaded { get; set; }

    public string? Status { get; set; }
 
}
