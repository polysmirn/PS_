using Microsoft.EntityFrameworkCore;
using PS.Model.Data;
using PS.Model.Entities;
using PS.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Model.Services
{
    public class OrderService
    {
        PScontext context;

        public OrderService()
        {
            context = new PScontext();
        }
        public ObservableCollection<Hall> GetHalls()
        {
            return new ObservableCollection<Hall>(context.Halls.ToList());
        }

        //public List<Hall> GetHalls()
        //{
        //    return context.Halls.ToList();
        //}
        public ObservableCollection<Photographer> GetPhotos()
        {
           return new ObservableCollection<Photographer>(context.Photographers.ToList());
        }

        public ObservableCollection<Order> GetOrders() 
        {
            return new ObservableCollection<Order>(context.Orders.Include(i => i.Client).Include(i => i.Hall).Include(i => i.Status).Include(i => i.Photographer).ToList());
        }
  

        public Order GetOrderById(int id)
        {
            return context.Orders.FirstOrDefault(i => i.Id == id); 
        }



        public void AddOrder(Order neworder)
        {
            
            neworder.AdminId = 1;
            neworder.StatusId = 1;
                
            
            context.Orders.Add(neworder);
            
            Save();
            GetOrders().Add(neworder);
        }
  

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
