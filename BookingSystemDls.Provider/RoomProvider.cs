using BookingSystemDLS.DataAccess.Models;
using BookingSystemDLS.DataModel.Master.Room;
using BookingSystemDLS.DataModel.Master.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystemDLS.DataModel.Master.BookingCode;

namespace BookingSystemDLS.Provider
{
    
    public class RoomProvider
    {
        private BookingSystemDlsContext _context;

        public RoomProvider(BookingSystemDlsContext _context)
        {
            this._context = _context;
        }

        private IQueryable<MstRoom> allRoom()
        {
            return _context.MstRooms.Where(x => !x.Deldate.HasValue); 
        }

        private MstRoom oneRoom(int id)
        {
            return _context.MstRooms.SingleOrDefault(x => x.Id == id);
        }



        private MstLocation locationName(int id)
        {
            return _context.MstLocations.SingleOrDefault(lc => lc.Id == id);
        }


        public IQueryable<GridRoomVM> getAll() 
        {
            return allRoom().Select(m => new GridRoomVM
            {
                Id = m.Id,
                Name = m.Name,
                Floor = m.Floor,
                Description = m.Description,
                Capacity = m.Capacity,
                Color = m.Color,
                LocationId = m.LocationId,
                LocationName = m.Location.Name
            });
        }

        public GridRoomVM getSingle(int id)
        {
            var room = oneRoom(id);
            var roomVm = new GridRoomVM();
            roomVm.Id = room.Id;
            roomVm.Name = room.Name;
            roomVm.Floor = room.Floor;
            roomVm.Description = room.Description;
            roomVm.Capacity = room.Capacity;
            roomVm.Color = room.Color;
            roomVm.LocationId = room.LocationId;
            roomVm.LocationName = locationName(room.LocationId).Name;

            return roomVm;
        }

        public void insert(UpsertRoomVM model)
        {
            var newRoom = new MstRoom();
            newRoom.Name = model.Name;
            newRoom.Floor = model.Floor;
            newRoom.Description = model.Description;
            newRoom.Capacity = model.Capacity;
            newRoom.Color = model.Color;
            newRoom.LocationId = model.LocationId;
            newRoom.Createddate = DateTime.Now;
            newRoom.Createdby = 1;
           
            _context.MstRooms.Add(newRoom);
            _context.SaveChanges();
        }

        public void update(UpsertRoomVM model)
        {
            var Room = oneRoom(model.Id);
            Room.Name = model.Name;
            Room.Floor = model.Floor;
            Room.Description = model.Description;
            Room.Capacity = model.Capacity;
            Room.Color = model.Color;
            Room.LocationId = model.LocationId;
            Room.Updateddate = DateTime.Now;
            Room.Updatedby = 2;
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var room = oneRoom(id);
            room.Delby = 3;
            room.Deldate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
