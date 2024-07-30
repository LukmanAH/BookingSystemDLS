using BookingSystemDLS.DataModel.Master.ResourceDetail;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.DataModel.Master.Resource
{
    public class ResourceWithDetailVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? IconPath { get; set; }

        public IFormFile IconFile { get; set; }

        public bool IsActive { get; set; }

        public List<GridResourceDetailVM> details { get; set; }
    }
}
