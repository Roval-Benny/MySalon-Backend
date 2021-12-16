using DAL;
using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;
using Exceptions;

namespace Services
{
    class SalonServiceService : ISalonServiceService
    {
        private readonly ISalonServiceRepository _repository;
        public SalonServiceService(ISalonServiceRepository repo) {

            _repository = repo;
        }
        public List<SalonServices> GetAllSalonServiceSalonId(int salonId, int category)
        {
            if (GetAllSalonServiceSalonId(salonId) != null)
            {
                return _repository.GetAllSalonServiceSalonId(salonId);
            }
            else
            {
                throw new SalonNotFoundException($"Salon with id: {salonId} does not exist");
            }
        }

        public List<SalonServices> GetAllSalonServiceSalonId(int salonId)
        {
            if (GetAllSalonServiceSalonId(salonId) != null)
            {
                return _repository.GetAllSalonServiceSalonId(salonId);
            }
            else
            {
                throw new SalonNotFoundException($"Salon with id: {salonId} does not exist");
            }
        }

        public bool UpdateSalonService(int salonId,SalonServices salon)
        {

            salon.Id = salonId;
            if (_repository.UpdateSalonService(salon))
            {
                return true;
            }
            else
            {
                throw new SalonNotFoundException($"salon with id: {salonId} does not exist");
            }
 
        }

}   } 
