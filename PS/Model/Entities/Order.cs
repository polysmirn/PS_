using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Model.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? Count_hours { get; set; }
        public int Price { get; set; }  
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int? AdminId { get; set; }
        public Admin? Admin { get; set; }
        
        public int HallId { get; set; } 
        public Hall Hall { get; set; }
        public int? PhotographerId { get; set; }
        public Photographer ?Photographer { get; set;}
        public int? StatusId { get; set; }   
        public Status? Status { get; set; }

    }
}
