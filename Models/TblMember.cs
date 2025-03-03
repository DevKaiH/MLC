using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLC.Models;

public partial class TblMember
{
    public int? Id { get; set; }

    public short EnvNo { get; set; }

    public string? Firstname { get; set; }

    public string Lastname { get; set; } = null!;

    public string? Addres1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public string? Postalcode { get; set; }

    public string? Country { get; set; }

    public string? Phone1 { get; set; }

    public string? EMail { get; set; }

    public DateTime Updated { get; set; }

   
}
