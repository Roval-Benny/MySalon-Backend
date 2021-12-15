using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface ITimeSlot
    {
        List<TimeSlot> GetTimeSlotsBySalonId(int salonId,string date);
        bool UpdateTimeSlot(int salonId,int serviceId,string date, TimeSlot timeSlot);
        TimeSlot CreateTimeSlot(int salonId,int serviceId,int date);
        bool DeleteTimeSlot(int salonId, int serviceId,int date);

    }
}
