using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PS.Model.Data;
using PS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Model.Services
{
    public class PhotographerService
    {
        PScontext context;

        public PhotographerService() 
        {
            context = new PScontext();
        }

        public List<Photographer> GetPhotographers()
        {
            return context.Photographers.ToList();
        }

        public Photographer GetPhotographerById(int id)
        {
            return context.Photographers.Where(i => i.Id == id).First();
        }

        public void DeletePhotographer(int id)
        {
            Photographer photographer=context.Photographers.Where(i => i.Id == id).First();
            context.Photographers.Remove(photographer);
            Save();

        }

        public void UpdatePhotographer(Photographer photographer)
        {
            context.Entry(photographer).State = EntityState.Modified;
            Save();
        }

        public void AddPhotographer(Photographer newphotographer)
        {
            context.Photographers.Add(newphotographer);
            Save();
        }


        public void Save()
        {
            context.SaveChanges();
        }

    }

}
