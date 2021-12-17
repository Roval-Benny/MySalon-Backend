using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface IAppointmentRepository
    {
        Appointment CreateAppointment(Appointment appointment);
        bool UpdateAppointment(int appointmentId,Appointment appointment);
        List<Appointment> GetAllAppointmentByAdminId(int adminId);
        List<Appointment> GetAllAppointmentByUserId(int userId);
        bool DeleteAppointment(int appointmentId);

    }
}
