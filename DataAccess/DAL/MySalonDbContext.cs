using System;
using MySalonModels;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MySalonDbContext:DbContext
    {
        public MySalonDbContext(DbContextOptions<MySalonDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Salon> Salon { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Service> Services { get; set; }    
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<SalonServices> SalonServices { get; set;}
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Admin> Admins { get; set; }

        

    }
}
