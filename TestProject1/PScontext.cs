using Microsoft.EntityFrameworkCore;
using PS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class PScontext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<Hall> Halls { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JAV8VG6\SQLEXPRESS; Initial catalog=PS;Trusted_Connection=True; TrustServerCertificate=True;");
        }

    }
}
