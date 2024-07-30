using System;
using System.Collections.Generic;

namespace BookingSystemDLS.DataAccess.Models;

public partial class MstBookingCode
{
    public int Id { get; set; }

    public string BookingCode { get; set; } = null!;

    public bool IsActive { get; set; }

    public int? Createdby { get; set; }

    public DateTime? Createddate { get; set; }

    public int? Updatedby { get; set; }

    public DateTime? Updateddate { get; set; }

    public int? Delby { get; set; }

    public DateTime? Deldate { get; set; }
}
