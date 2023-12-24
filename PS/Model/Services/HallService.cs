using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PS.Model.Data;
using PS.Model.Entities;
using PS.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Model.Services
{
    public class HallService
    {
        PScontext context;

        public HallService() 
        {
            context = new PScontext();
        }

        public List<Hall> GetHalls()
        {
            return context.Halls.ToList();
        }

        public Hall  GetHallById(int id)
        { 
            return context.Halls.Where(i=>i.Id==id).First();
        }

        public void DeleteHall(int  id)
        {
            Hall hall = context.Halls.Where(i => i.Id == id).First();
            context.Halls.Remove(hall);
            Save();
        }

        public void UpdateHall(Hall hall) 
        {
            context.Entry(hall).State = EntityState.Modified;
            Save();
        }

        public void AddHall(Hall newhall)
        {
            context.Halls.Add(newhall); 
            Save(); 
        }
            

        public void Save()
        {
            context.SaveChanges();
        }


    }
}
