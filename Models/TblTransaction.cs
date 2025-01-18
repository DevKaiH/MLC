using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class TblTransaction
{
    public int Id { get; set; }
    public DateTime? Transactiondate { get; set; }
    public string? Memo { get; set; }
    public int? Account { get; set; }
    public int? ReimburseToUser { get; set; }
    public string? AddUser { get; set; }
    public DateTime? AddTime { get; set; }

   
}
