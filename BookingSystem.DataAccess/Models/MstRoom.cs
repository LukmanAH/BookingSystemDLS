using System;
using System.Collections.Generic;

namespace BookingSystemDLS.DataAccess.Models;

public partial class MstRoom
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Floor { get; set; }

    public string? Description { get; set; }

    public int Capacity { get; set; }

    public string? AttachmentFileName { get; set; }

    public string? Color { get; set; }

    public int LocationId { get; set; }

    public int Createdby { get; set; }

    public DateTime Createddate { get; set; }

    public int? Updatedby { get; set; }

    public DateTime? Updateddate { get; set; }

    public int? Delby { get; set; }

    public DateTime? Deldate { get; set; }

    public virtual MstLocation Location { get; set; } = null!;
}
