using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using MySalonModels;
using Exceptions;

namespace Services
{

    public class SalonService : ISalonService
    {
        private readonly ISalonRepository _repository;
        public SalonService(ISalonRepository repos)
        {
            _repository = repos;
        }


        public List<Salon> GetAllSalons()
        {
            return _repository.GetAllSalons();
        }
        public Salon GetSalon(int id)
        {
            if (_repository.GetSalon(id) != null)
            {
                return _repository.GetSalon(id);
            }
            else
            {
                throw new SalonNotFoundException($"This Salon does not exist");
            }
        }
        
        public List<Salon> GetAllSalonsByLocation(string location)
        {
            if (_repository.GetAllSalonsByLocation(location) != null)
                return _repository.GetAllSalonsByLocation(location);
            else throw new SalonNotFoundException($"Salon with the Searched Location: {location} is Not Available");
        }

        
    }
}