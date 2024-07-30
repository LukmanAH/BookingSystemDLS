using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.DataModel.Master.BookingCode;
using BookingSystemDLS.DataModel.Master.Email;
using BookingSystemDLS.DataModel.Master.Menu;
using BookingSystemDLS.DataModel.Master.Room;
using BookingSystemDLS.DataModel.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.Provider
{
    
    public class EmailProvider
    {
        private BookingSystemDlsContext _context;

        public EmailProvider(BookingSystemDlsContext _context)
        {
            this._context = _context;
        }

        private IQueryable<MstEmail> allEmail()
        {
            return _context.MstEmails.Where(x => !x.Deldate.HasValue);
        }

        private MstEmail OneEmail(int id)
        {
            return _context.MstEmails.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<GridEmailVM> getAll() 
        {
            return allEmail().Select(m => new GridEmailVM
            {
               Id = m.Id,
               Email = m.Email,
            });
        }

        public GridEmailVM getSingle(int id)
        {
            var item = OneEmail(id);
            GridEmailVM model = new GridEmailVM();
            model.Id = item.Id;
            model.Email = item.Email;
            return model;
        }

        public IQueryable<DropdownVM> getLOV()
        {
            return allEmail().Select(m => new DropdownVM
            {
                value = m.Id,
                label = m.Email
            });
        }

        public void insert(UpsertEmailVM model)
        {
            var item = new MstEmail();
            item.Id = model.Id;
            item.Email = model.Email;
            item.Createddate = DateTime.Now;
            item.Createdby = 1;
            _context.MstEmails.Add(item);
            _context.SaveChanges();
        }

        public void update(UpsertEmailVM model)
        {
            var item = OneEmail(model.Id);
            item.Email = model.Email;
            item.Updateddate = DateTime.Now;
            item.Updatedby= 2;
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var item = OneEmail(id);
            _context.Remove(item);
            _context.SaveChanges();
        }
    }
}
