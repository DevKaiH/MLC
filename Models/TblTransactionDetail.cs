using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class TblTransactionDetail
{
    public int Id { get; set; }

    public int TransactionId { get; set; }

    public int? Account { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public string? Filename { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Gst { get; set; }

    public decimal? Pst { get; set; }

    public bool? Approved { get; set; }

    public string? Approver { get; set; }

    public DateTime? ApproveDate { get; set; }
}
