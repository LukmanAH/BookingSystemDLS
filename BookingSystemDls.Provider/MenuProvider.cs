using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.DataModel.Master.BookingCode;
using BookingSystemDLS.DataModel.Master.Location;
using BookingSystemDLS.DataModel.Master.Menu;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDLS.Provider
{
    
    public class MenuProvider
    {
        private BookingSystemDlsContext _context;

        public MenuProvider(BookingSystemDlsContext _context)
        {
            this._context = _context;
        }

        private IQueryable<MstMenu> allMenu()
        {
            return _context.MstMenus.Where(x => !x.Deldate.HasValue);
        }

        private MstMenu oneMenu(int id) 
        {
            return _context.MstMenus.SingleOrDefault(x => x.Id == id);
        }


        public IQueryable<GridMenuVM> getAllMenu() 
        {
            return allMenu().Where(x=>x.IsActive).Select(m => new GridMenuVM 
            {
                Id = m.Id,
                Title = m.Title,
                NavigationTo = m.NavigationTo,
                MenuOrder = m.MenuOrder,
                IsRoot = m.IsRoot,
                IsActive = m.IsActive,
                ParentMenuId = m.ParentMenuId
            }).OrderBy(x => x.MenuOrder); 
        }

        public GridMenuVM getSingle(int id)
        {
            var menu = oneMenu(id);
            var menuVm = new GridMenuVM();
            menuVm.Id = menu.Id;
            menuVm.Title = menu.Title;
            menuVm.NavigationTo = menu.NavigationTo;
            menuVm.MenuOrder = menu.MenuOrder;
            menuVm.IsRoot = menu.IsRoot;
            menuVm.IsActive = menu.IsActive;
            menuVm.ParentMenuId = menu.ParentMenuId;
            return menuVm;
        }

        public List<NestedMenuVm> getNestedMenu()
        {
            var menus = allMenu().Where(x => x.IsActive && !x.ParentMenuId.HasValue).Select(m => new NestedMenuVm
            {
                Id = m.Id,
                Title = m.Title,
                NavigationTo = m.NavigationTo,
                MenuOrder = m.MenuOrder,
                IsRoot = m.IsRoot,
                IsActive = m.IsActive,
                ParentMenuId = m.ParentMenuId,
                SubMenu = new List<GridMenuVM>()
            }).OrderBy(x => x.MenuOrder).ToList();

            var model = new List<NestedMenuVm>();

            foreach (var menu in menus) 
            {
                var newMenu = menu;
                newMenu.SubMenu = allMenu().Where(x=>x.IsActive && x.ParentMenuId == menu.Id).Select(m => new GridMenuVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    NavigationTo = m.NavigationTo,
                    MenuOrder = m.MenuOrder,
                    IsRoot = m.IsRoot,
                    IsActive = m.IsActive,
                    ParentMenuId = m.ParentMenuId
                }
                ).ToList();
                model.Add(newMenu);
            }


            return model;
        }
    }
}
