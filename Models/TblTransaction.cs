using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLC.Models;

public partial class TblTransaction
{
    public int Id { get; set; }
    public DateTime Transactiondate { get; set; }
    public string? Memo { get; set; }
    public int? Account { get; set; }
    public int? ReimburseToUser { get; set; }
    public string? AddUser { get; set; }
    public DateTime? AddTime { get; set; }

    [NotMapped]
    public decimal? Total { get; set; } // Add new property here

}

