using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly MySalonDbContext _context;

        public TimeSlotRepository(MySalonDbContext dbContext)
        {
            _context = dbContext;
        }
        public TimeSlot CreateTimeSlot(int salonId, int serviceId, string date)
        {
            var timeSlot = new TimeSlot();
            timeSlot.SalonId = salonId;
            timeSlot.ServiceId = serviceId;
            timeSlot.Date = date;
            timeSlot.Time9To11 = false;
            timeSlot.Time2To4 = false;
            timeSlot.Time4To6 = false;
            timeSlot.Time11To1 = false;
            _context.Add(timeSlot);
            _context.SaveChanges();
            return timeSlot;
            
        }

        public bool DeleteTimeSlot(int salonId, int serviceId, string date)
        {
            var timeSlot = _context.TimeSlots.Find(salonId,serviceId,date);
            if(timeSlot == null) return false;
            _context.TimeSlots.Remove(timeSlot);
            _context.SaveChanges();
            return true;
        }

        public List<TimeSlot> GetTimeSlotsBySalonId(int salonId, string date)
        {
            return _context.TimeSlots.Where<TimeSlot>(x =>x.SalonId==salonId && x.Date==date).ToList();
        }

        public TimeSlot GetTimeSlotByServiceId(int salonId,int serviceId,string date)
        {
            return _context.TimeSlots.Where<TimeSlot>(x=>x.SalonId==salonId &&x.ServiceId==serviceId && x.Date==date).FirstOrDefault();
        }

        public bool UpdateTimeSlot(int salonId, int serviceId, string date, TimeSlot timeSlot)
        {
            var slot = _context.TimeSlots.FirstOrDefault<TimeSlot>(x => x.ServiceId == serviceId && x.SalonId == salonId && x.Date == date);
            if(slot == null) return false;
            slot.Time9To11 = timeSlot.Time9To11;
            slot.Time4To6 = timeSlot.Time4To6;
            slot.Time2To4 = timeSlot.Time2To4;
            slot.Time11To1 = timeSlot.Time11To1;
            _context.Entry(slot).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
