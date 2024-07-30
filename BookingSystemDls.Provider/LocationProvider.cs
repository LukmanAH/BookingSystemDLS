using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.DataModel.Master.Location;
using BookingSystemDLS.DataModel.Master.Menu;
using BookingSystemDLS.DataModel.Master.Room;
using BookingSystemDLS.DataModel.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.Provider
{
    public class LocationProvider
    {
        private BookingSystemDlsContext _context;

        public LocationProvider(BookingSystemDlsContext _context)
        {
            this._context = _context;
        }

        private IQueryable<MstLocation> allLocation()
        {
            return _context.MstLocations.Where(x => !x.Deldate.HasValue);
        }

        private MstLocation oneLocation(int id)
        {
            return _context.MstLocations.SingleOrDefault(x => x.Id == id);
        }


        public IQueryable<GridLocationVM> getAll()
        {
            return allLocation().Select(m => new GridLocationVM
            {
                Id = m.Id,
                Name = m.Name
            });
        }

        public GridLocationVM getSingle(int id)
        {
            var location = oneLocation(id);
            var locationVm = new GridLocationVM();
            locationVm.Id = location.Id;
            locationVm.Name = location.Name;
            return locationVm;
        }

        public void insert(UpsertLocationVM model)
        {
            var newLocation = new MstLocation();
            newLocation.Name = model.Name;
            newLocation.Createddate = DateTime.Now;
            newLocation.Createdby = 1;

            _context.MstLocations.Add(newLocation);
            _context.SaveChanges();
        }

        public void update(UpsertLocationVM model)
        {
            var location = oneLocation(model.Id);
            location.Name = model.Name;
            location.Updateddate = DateTime.Now;
            location.Updatedby = 2;
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var location = oneLocation(id);
            location.Delby = 3;
            location.Deldate = DateTime.Now;
            _context.SaveChanges();
        }


        public List<SelectListItem> getLOV()
        {
            return allLocation().Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            }).ToList();
        }
    }
}
