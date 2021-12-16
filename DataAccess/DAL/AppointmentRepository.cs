using Microsoft.EntityFrameworkCore;
using MySalonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class AppointmentRepository : IAppointmentRepository
    {
        private readonly MySalonDbContext _salonedbcontext;
        public AppointmentRepository(MySalonDbContext dbcontext)
        {
            _salonedbcontext = dbcontext;
        }
        public Appointment CreateAppointment(Appointment appointment)
        {
            _salonedbcontext.Appointments.Add(appointment);
            _salonedbcontext.SaveChanges();
            return appointment;
        }

        public bool DeleteAppointment(int appointmentId)
        {
            var appointment = _salonedbcontext.Appointments.FirstOrDefault(item => item.Id == appointmentId);
            if (appointment != null)
            {
                _salonedbcontext.Appointments.Remove(appointment);
                _salonedbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Appointment> GetAllAppointmentByAdminId(int adminId)
        {
            return _salonedbcontext.Appointments.Where(a => a.Id == adminId).ToList();
        }

        public List<Appointment> GetAllAppointmentByUserId(int userId)
        {
            return _salonedbcontext.Appointments.Where(u => u.Id == userId).ToList();
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            var appointmentToUpdate = _salonedbcontext.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            if (appointmentToUpdate != null)
            {
                appointmentToUpdate.Id = appointment.Id;
                appointmentToUpdate.Price = appointment.Price;
                appointmentToUpdate.SalonId = appointment.SalonId;
                appointmentToUpdate.SalonName = appointment.SalonName;
                appointmentToUpdate.Status = appointment.Status;
                appointmentToUpdate.Time = appointment.Time;

                _salonedbcontext.Entry(appointmentToUpdate).State = EntityState.Modified;
                _salonedbcontext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
