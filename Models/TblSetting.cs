using System;
using System.Collections.Generic;

namespace MLC.Models;

public partial class TblSetting
{
    public int Id { get; set; }

    public string? Property { get; set; }

    public double? Value { get; set; }
}
