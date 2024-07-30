using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.DataModel.Master.resource;
using BookingSystemDLS.DataModel.Master.Resource;
using BookingSystemDLS.DataModel.Master.resourceDetail;
using BookingSystemDLS.DataModel.Master.ResourceDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.Provider
{
    public class ResourceDetailProvider
    {
        private BookingSystemDlsContext _context;

        public ResourceDetailProvider(BookingSystemDlsContext _context)
        {
            this._context = _context;
        }

        private IQueryable<MstResourceDetail> allResource()
        {
            return _context.MstResourceDetails.Where(x => !x.Deldate.HasValue);
        }

        private MstResourceDetail oneResource(int id)
        {
            return _context.MstResourceDetails.SingleOrDefault(x => x.Id == id);
        }

        public UpsertResourceDetailVM getSingleUpsert(int id)
        {
            var dtl = oneResource(id);
            var upsertDtl = new UpsertResourceDetailVM();
            upsertDtl.Id = dtl.Id;
            upsertDtl.Code = dtl.Code;
            upsertDtl.IsActive = true;
            upsertDtl.ResourceId = dtl.ResourceId;
            return upsertDtl;
        }

        public List<GridResourceDetailVM> getByResourceID(int id)
        {
            var detail = allResource().Where(x => x.ResourceId == id).Select(m => new GridResourceDetailVM
            {
                Id = m.Id,
                Code = m.Code,
                IsActive = m.IsActive
            }).ToList();


            return detail;
        }

        public void insert(UpsertResourceDetailVM model)
        {
            var newItem = new MstResourceDetail();
            newItem.ResourceId = model.ResourceId;
            newItem.Code = model.Code;
            newItem.IsActive = model.IsActive;
            newItem.Createddate = DateTime.Now;
            newItem.Createdby = 1;

            _context.MstResourceDetails.Add(newItem);
            _context.SaveChanges();
        }

        public void update(UpsertResourceDetailVM model)
        {
            var item = oneResource(model.Id);
            item.Code = model.Code;
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
