using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.DataModel.Master.BookingCode;
using BookingSystemDLS.DataModel.Master.GlobalSetup;
using BookingSystemDLS.DataModel.Master.Menu;
using BookingSystemDLS.DataModel.Master.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.Provider
{
    
    public class GlobalSetupProvider
    {
        private BookingSystemDlsContext _context;

        public GlobalSetupProvider(BookingSystemDlsContext _context)
        {
            this._context = _context;
        }

        private IQueryable<GlobalSetup> allSetup()
        {
            return _context.GlobalSetups;
        }

        private GlobalSetup OneSetup(string code)
        {
            return _context.GlobalSetups.SingleOrDefault(x => x.Code == code);
        }

        public IQueryable<GridGlobalSetupVM> getAll() 
        {
            return allSetup().Select(m => new GridGlobalSetupVM
            {
               Code = m.Code,
               Name = m.Name,
               Desc = m.Desc,
               Value = m.Value
            });
        }

        public GridGlobalSetupVM getSingle(string code)
        {
            var item = OneSetup(code);
            GridGlobalSetupVM model = new GridGlobalSetupVM();
            model.Code = item.Code;
            model.Name = item.Name;
            model.Desc = item.Desc;
            model.Value = item.Value;
            return model;
        }

        public void insert(UpsertGlobalSetupVM model)
        {
            var item = new GlobalSetup();
            item.Code = model.Code;
            item.Value = model.Value;
            item.Name = model.Name;
            item.Desc = model.Desc;
            _context.GlobalSetups.Add(item);
            _context.SaveChanges();
        }

        public void update(UpsertGlobalSetupVM model)
        {
            var item = OneSetup(model.Code);
            item.Value = model.Value;
            item.Name = model.Name;
            item.Desc = model.Desc;
            _context.SaveChanges();
        }

        public void delete(string code)
        {
            var item = OneSetup(code);
            _context.Remove(item);
            _context.SaveChanges();
        }
    }
}
