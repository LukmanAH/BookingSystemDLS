using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.DataModel.Master.Room
{
    public class UpsertRoomVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Floor { get; set; }

        public string? Description { get; set; }

        public int Capacity { get; set; }

        public string? Color { get; set; }

        public int LocationId { get; set; }

    }
}
