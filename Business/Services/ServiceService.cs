using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Exceptions;

namespace Services
{
    public class ServiceService : IServiceService
    {

        private readonly IServiceRepository _repository;

        
        public ServiceService(IServiceRepository repo)
        {
            _repository = repo;
        }

        public Service AddService(Service service)
        {
            return _repository.AddService(service);
        }

        public bool DeleteService(int  serviceId)
        {
            if (_repository.DeleteService(serviceId))
            {
                return true;
            }
            else
            {
                throw new ServiceNotFoundException($"Service with serviceId: {serviceId} does not exist");
            }
        }

        public List<Service> GetAllService()
        {
            return _repository.GetAllService();
        }
    }
}
