using PS.Model.CustomEntities;
using PS.Model.Data;
using PS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Model.Services
{
    public class ReportService
    {
        PScontext context;

        public ReportService()
        {
            context = new PScontext();
        }
        public List<Hall> GetHalls()
        {
            return context.Halls.ToList();
        }
        public List<Order> GetOrders()
        {
            return context.Orders.ToList();
        }
        public ObservableCollection<OrdersByDate> OrderByDate(DateTime startDate, DateTime endDate,int id)
        {
            var ordersByMonth = new ObservableCollection<OrdersByDate>(GetOrders().OrderByDescending(o => o.Date)
            .Where(o => o.Date.Date >= startDate.Date && o.Date.Date <= endDate.Date && o.HallId == id)
            .Select(g => new OrdersByDate()
            {
                Date = g.Date.ToString("dd.MM.yyyy"),
                Time = g.Date.ToShortTimeString(),

                Hall = g.Hall.Name,
                Price = g.Price
            })
            .ToList());

            return ordersByMonth;
        }
    }
}
