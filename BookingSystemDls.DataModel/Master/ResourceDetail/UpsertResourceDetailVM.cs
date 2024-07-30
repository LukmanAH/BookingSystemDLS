using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.DataModel.Master.resourceDetail
{
    public class UpsertResourceDetailVM
    {
        public int Id { get; set; }

        public int ResourceId { get; set; }

        public string Code { get; set; }
        
        public bool IsActive { get; set; }

    }
}
