using System;
using System.Collections.Generic;

namespace BookingSystemDLS.DataAccess.Models;

public partial class GlobalSetup
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Desc { get; set; }

    public string? Value { get; set; }
}
