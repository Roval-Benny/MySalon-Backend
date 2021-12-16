using Microsoft.EntityFrameworkCore;
using MySalonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class SalonServiceRepository : ISalonServiceRepository
    {
        private readonly MySalonDbContext _salondbcontext;
        public SalonServiceRepository(MySalonDbContext dbContext)
        {
            _salondbcontext = dbContext;
        }
        public List<SalonServices> GetAllSalonServiceSalonId(int salonId, int category)
        {
            return _salondbcontext.SalonServices.Where(s => s.SalonId== salonId)
                .Where(c => c.Category == category).ToList();
        }

        public List<SalonServices> GetAllSalonServiceSalonId(int salonId)
        {
            return _salondbcontext.SalonServices.Where(s => s.SalonId == salonId).ToList();
        }

        public Boolean UpdateSalonService(int salonId, SalonServices salon)
        {
            var salonserviceToUpdate = _salondbcontext.SalonServices.FirstOrDefault(s => s.Id == salon.Id);
            if (salonserviceToUpdate != null)
            {
                salonserviceToUpdate.Id = salon.Id;
                salonserviceToUpdate.Image = salon.Image;
                salonserviceToUpdate.Name = salon.Name;
                salonserviceToUpdate.Offer = salon.Offer;
                salonserviceToUpdate.Price = salon.Price;
                _salondbcontext.Entry(salonserviceToUpdate).State = EntityState.Modified;
                _salondbcontext.SaveChanges();
                return true;
            }
           
                return false;
            
        }

        public bool UpdateSalonService(SalonServices salon)
        {
            throw new NotImplementedException();
        }
    }
}
