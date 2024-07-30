using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.DataModel.Master.Room;
using BookingSystemDLS.DataModel.Master.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystemDLS.DataModel.Master.BookingCode;
using BookingSystemDLS.DataModel.Master.Resource;
using BookingSystemDLS.DataModel.Master.resource;

namespace BookingSystemDLS.Provider
{
    
    public class ResourceProvider
    {
        private BookingSystemDlsContext _context;

        public ResourceProvider(BookingSystemDlsContext _context)
        {
            this._context = _context;
        }

        private IQueryable<MstResource> allResource()
        {
            return _context.MstResources.Where(x => !x.Deldate.HasValue).OrderBy(x => x.Id); 
        }

        private MstResource oneResource(int id)
        {
            return _context.MstResources.SingleOrDefault(x => x.Id == id);
        }



        public IQueryable<GridResourceVM> getAll() 
        {
            return allResource().Select(m => new GridResourceVM
            {
                Id = m.Id,
                Name = m.Name,
                IconPath = m.IconPath,
                IsActive = m.IsActive
            });
        }

        public GridResourceVM getSingle(int id)
        {
            var resource = oneResource(id);
            var resourceVm = new GridResourceVM();
            resourceVm.Id = resource.Id;
            resourceVm.Name = resource.Name;
            resourceVm.IconPath = resource.IconPath;
            resourceVm.IsActive = resource.IsActive;
            

            return resourceVm;
        }

        public void insert(UpsertResourceVM model)
        {
            var newItem = new MstResource();
            newItem.Name = model.Name;
            newItem.IconPath = model.IconPath;
            newItem.IsActive = model.IsActive;
            newItem.Createddate = DateTime.Now;
            newItem.Createdby = 1;
           
            _context.MstResources.Add(newItem);
            _context.SaveChanges();
        }

        public void update(UpsertResourceVM model)
        {
            var item = oneResource(model.Id);
            item.Name = model.Name;
            item.IconPath = model.IconPath;
            item.IsActive = model.IsActive;
            item.Updateddate = DateTime.Now;
            item.Updatedby = 2;
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var item = oneResource(id);
            item.Delby = 3;
            item.Deldate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
