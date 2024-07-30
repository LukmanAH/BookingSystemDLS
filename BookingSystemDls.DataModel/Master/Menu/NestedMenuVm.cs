using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.DataModel.Master.Menu
{
    public class NestedMenuVm
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? NavigationTo { get; set; }

        public int? MenuOrder { get; set; }

        public bool IsRoot { get; set; }

        public bool IsActive { get; set; }

        public int? ParentMenuId { get; set; }

        public List<GridMenuVM> SubMenu { get; set; }
    }
}
