using BookingSystemDLS.DataModel.Master.Room;
using BookingSystemDLS.DataModel.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.WEB.Models.Room
{
    public class UpsertRoomWebVM
    {
        public GridRoomVM Room { get; set; }

        public List<SelectListItem> LocationLoV { get; set; }

    }
}
