using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface IAppointmentRepository
    {
        bool CreateAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment appointment);
        List<Appointment> GetAllAppointmentByAdminId(int adminId);
        List<Appointment> GetAllAppointmentByUserId(int userId);
        bool DeleteAppointment(Appointment appointment);

    }
}
