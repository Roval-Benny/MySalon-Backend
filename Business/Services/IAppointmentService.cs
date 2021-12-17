using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IAppointmentService
    {
        Appointment CreateAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment appointment, int userId);
        List<Appointment> GetAllAppointmentByAdminId(int adminId);
        List<Appointment> GetAllAppointmentByUserId(int userId);
        bool DeleteAppointment(int appointmentId);
    }
}
