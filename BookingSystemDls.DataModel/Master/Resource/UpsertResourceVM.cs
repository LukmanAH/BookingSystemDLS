using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.DataModel.Master.resource
{
    public class UpsertResourceVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? IconPath { get; set; }
        
        public bool IsActive { get; set; }

    }
}
