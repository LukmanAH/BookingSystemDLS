using System;
using System.Collections.Generic;

namespace BookingSystemDLS.DataAccess.Models;

public partial class MstRoleMenu
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int MenuId { get; set; }

    public int Createdby { get; set; }

    public DateTime Createddate { get; set; }

    public int? Updatedby { get; set; }

    public DateTime? Updateddate { get; set; }

    public int? Delby { get; set; }

    public DateTime? Deldate { get; set; }

    public virtual MstMenu Menu { get; set; } = null!;

    public virtual MstRole Role { get; set; } = null!;
}
