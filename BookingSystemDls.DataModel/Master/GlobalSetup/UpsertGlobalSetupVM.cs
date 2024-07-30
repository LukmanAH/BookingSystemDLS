using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.DataModel.Master.GlobalSetup
{
    public class UpsertGlobalSetupVM
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string? Desc { get; set; }

        public string? Value { get; set; }
    }
}
