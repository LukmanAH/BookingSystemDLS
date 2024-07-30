using System;
using System.Collections.Generic;

namespace BookingSystemDLS.DataAccess.Models;

public partial class MstMenu
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? NavigationTo { get; set; }

    public int? MenuOrder { get; set; }

    public bool IsRoot { get; set; }

    public bool IsActive { get; set; }

    public int Createdby { get; set; }

    public DateTime Createddate { get; set; }

    public int? Updatedby { get; set; }

    public DateTime? Updateddate { get; set; }

    public int? Delby { get; set; }

    public DateTime? Deldate { get; set; }

    public int? ParentMenuId { get; set; }

    public virtual ICollection<MstMenu> InverseParentMenu { get; set; } = new List<MstMenu>();

    public virtual ICollection<MstRoleMenu> MstRoleMenus { get; set; } = new List<MstRoleMenu>();

    public virtual MstMenu? ParentMenu { get; set; }
}
