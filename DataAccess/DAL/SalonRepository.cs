using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MySalonModels;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SalonRepository : ISalonRepository
    {
        private readonly MySalonDbContext _context;

        public SalonRepository (MySalonDbContext dbContext)
        {
            _context = dbContext;
        }

        public Salon CreateSalon(Salon salon)
        {
            _context.Salon.Add(salon);
            _context.SaveChanges();
            return salon;
        }

        public List<Salon> GetAllSalons()
        {
            return _context.Salon.ToList();
        }

        public List<Salon> GetAllSalonsByLocation(string location)
        {
            // return _context.Branches.Where<Branch>(x=> x.Location == location).ToList();
            //return _context.Salon.ToList();
            return _context.Salon.Where(x => x.Location == location).ToList();
        }
        
        public Salon GetSalon(int id)
        {
            return _context.Salon.Find(id);
        }
    }
}
