using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class TblPayment
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? Memo { get; set; }

    public int? RecipientId { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? SubmittedToBmo { get; set; }

    public DateTime? ApproveDate { get; set; }

    public decimal? Amount { get; set; }

    public bool? Tax { get; set; }

    public string? Account { get; set; }

    public string? Filename { get; set; }

    public int? Filenumber { get; set; }

    public string? AddUser { get; set; }

    public DateTime? AddDate { get; set; }
}
