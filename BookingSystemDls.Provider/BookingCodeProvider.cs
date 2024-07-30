using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.DataModel.Master.BookingCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.Provider
{
    public class BookingCodeProvider
    {
        private BookingSystemDlsContext _context;

        public BookingCodeProvider(BookingSystemDlsContext _context)
        {
            this._context = _context;
        }

        private IQueryable<MstBookingCode> allBookingCode()
        {
            return _context.MstBookingCodes.Where(x => !x.Deldate.HasValue).OrderBy(x => x.Id);
        }

        private MstBookingCode oneBookingCode(int id)
        {
            return _context.MstBookingCodes.SingleOrDefault(bc => bc.Id == id);
        }

        public IQueryable<GridBCVM> getAll()
        {
            return allBookingCode().Select(bc => new GridBCVM
            {
                Id = bc.Id,
                BookingCode = bc.BookingCode,
                IsActive = bc.IsActive
            });
        }

        public GridBCVM getSingle(int id)
        {
            var bc = oneBookingCode(id);
            GridBCVM bcvm = new GridBCVM();
            bcvm.Id = bc.Id;
            bcvm.IsActive = bc.IsActive;
            bcvm.BookingCode = bc.BookingCode;
            return bcvm;
        }

        public void insert(UpsertBCVM model)
        {
            var newBC = new MstBookingCode();
            newBC.BookingCode = model.BookingCode;
            newBC.IsActive = model.IsActive;
            newBC.Createdby = 1;
            newBC.Createddate = DateTime.Now;
            _context.MstBookingCodes.Add(newBC);
            _context.SaveChanges();
        }

        public void update(UpsertBCVM model)
        {
            var BC = oneBookingCode(model.Id);
            BC.BookingCode = model.BookingCode;
            BC.IsActive = model.IsActive;
            BC.Updatedby = 3;
            BC.Updateddate = DateTime.Now;
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var BC = oneBookingCode(id);
            BC.Delby = 3;
            BC.Deldate = DateTime.Now;
            _context.SaveChanges();
        }




    }
}
