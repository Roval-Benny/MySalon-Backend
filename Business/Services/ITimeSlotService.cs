using MySalonModels;
using System.Collections.Generic;

namespace Services
{
    public interface ITimeSlotService
    {
        TimeSlot CreateTimeSlot(int salonId, int serviceId, string date);
        bool DeleteTimeSlot(int salonId, int serviceId, string date);
        List<TimeSlot> GetTimeSlotsBySalonId(int salonId, string date);
        bool UpdateTimeSlot(int salonId, int serviceId, string date, TimeSlot timeSlot);
        TimeSlot GetTimeSlotByServiceId(int salonId, int serviceId, string date);

    }
}