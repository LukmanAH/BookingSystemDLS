using System;
using System.Collections.Generic;

namespace BookingSystemDLS.DataAccess.Models;

public partial class MstLocation
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Createdby { get; set; }

    public DateTime? Createddate { get; set; }

    public int? Updatedby { get; set; }

    public DateTime? Updateddate { get; set; }

    public int? Delby { get; set; }

    public DateTime? Deldate { get; set; }

    public virtual ICollection<MstRoom> MstRooms { get; set; } = new List<MstRoom>();
}
