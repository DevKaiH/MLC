using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class TransBu
{
    public int Id { get; set; }

    public DateTime? Transactiondate { get; set; }

    public string? Memo { get; set; }

    public decimal? Amount { get; set; }

    public bool? Tax { get; set; }

    public string? Account { get; set; }

    public string? Filename { get; set; }

    public string? AddUser { get; set; }

    public int? LogId { get; set; }

    public string? Bankaccount { get; set; }

    public bool? Detailrecord { get; set; }
}
