using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2;

namespace TestProject2
{
    public class HallService
    {
        private IDbRepos _context;

        public HallService(IDbRepos context)
        {
            _context =context;
        }

        public List<Hall> GetHalls()
        {
            return _context.Halls.GetList().ToList();
        }

        public Hall GetHall(int Id)
        {
            return _context.Halls.GetItem(Id);
        }
       

        public void DeleteHall(int id)
        {
            if(_context.Halls.GetItem(id) != null)
            {
                _context.Halls.Delete(id);
                _context.Save();
            }
           
        }

        public void UpdateHall(Hall hall)
        {
            
        }

        public Hall AddHall(Hall hall)
        {
            var newHall = new Hall()
            {
                Id=hall.Id,
                Name=hall.Name,
                Description=hall.Description,
                Price_for_hour=hall.Price_for_hour,

            };
            _context.Halls.Create(newHall);
            if(_context.Save()>0)
            {
                var hall1=GetHall(hall.Id);
                return hall1;
            }
            return null;
        }

        
    }
}
