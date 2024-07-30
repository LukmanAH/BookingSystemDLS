using System;
using System.Collections.Generic;

namespace BookingSystemDLS.DataAccess.Models;

public partial class MstResourceDetail
{
    public int Id { get; set; }

    public int ResourceId { get; set; }

    public string Code { get; set; } = null!;

    public bool IsActive { get; set; }

    public int? Createdby { get; set; }

    public DateTime? Createddate { get; set; }

    public int? Updatedby { get; set; }

    public DateTime? Updateddate { get; set; }

    public int? Delby { get; set; }

    public DateTime? Deldate { get; set; }

    public virtual MstResource Resource { get; set; } = null!;
}
