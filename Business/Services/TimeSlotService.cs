using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;
using Exceptions;
using Services;
using DAL;

namespace Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotRepository _repository;
        public TimeSlotService(ITimeSlotRepository repo)
        {
            _repository = repo;
        }
        public TimeSlot CreateTimeSlot(int salonId, int serviceId, string date)
        {
            if (salonId < 1 || serviceId < 1 || date.Length == 0)
            {
                throw new NullValueException("Some values is wrong");
            }
            return CreateTimeSlot(salonId, serviceId, date);
        }
        public bool DeleteTimeSlot(int salonId, int serviceId, string date)
        {
            if (_repository.DeleteTimeSlot(salonId, serviceId, date)) return true;
            else throw new TimeSlotNotFoundException($"TimeSlot with SalonId: {salonId} ServiceId: {serviceId} Date: {date} Not Found");
        }
        public List<TimeSlot> GetTimeSlotsBySalonId(int salonId, string date)
        {
            if (_repository.GetTimeSlotsBySalonId(salonId, date) != null)
                return _repository.GetTimeSlotsBySalonId(salonId, date);
            else throw new TimeSlotNotFoundException($"TimeSlot with SalonId: {salonId} Date: {date} Not Found");
        }
        public bool UpdateTimeSlot(int salonId, int serviceId, string date, TimeSlot timeSlot)
        {
            if (_repository.UpdateTimeSlot(salonId, serviceId, date, timeSlot))
            {
                return true;
            }
            else
            {
                throw new TimeSlotNotFoundException($"TimeSlot with SalonId: {salonId} ServiceId: {serviceId} Date: {date} Not Found");
            }
        }
    }
}
