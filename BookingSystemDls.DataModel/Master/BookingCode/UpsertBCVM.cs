using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.DataModel.Master.BookingCode
{
    public class UpsertBCVM
    {
        public int Id { get; set; }
        public string BookingCode { get; set; }

        public bool IsActive { get; set; }
    }
}
