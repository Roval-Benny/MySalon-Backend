using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly MySalonDbContext _context;
        public ServiceRepository(MySalonDbContext dbContext)
        {
            _context = dbContext;
        }
       public Service AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return service;
        }

        public bool DeleteService(int serviceId)
        {
            Service serviceToDelete = _context.Services.FirstOrDefault(s => s.Id == serviceId);
            if(serviceToDelete == null)
            {
                return false;
            }
            _context.Services.Remove(serviceToDelete);
            _context.SaveChanges();
            return true;
        }

        public List<Service> GetAllService()
        {
            return _context.Services.ToList();
        }
    }
}

