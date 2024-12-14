using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddUser { get; set; }
}
