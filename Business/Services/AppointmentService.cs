using DAL;
using MySalonModels;
using System;
using System.Collections.Generic;
using Exceptions;
using System.Text;

namespace Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository repo)
        {
            _appointmentRepository = repo;
        }
        public Appointment CreateAppointment(Appointment appointment)
        {
            _appointmentRepository.CreateAppointment(appointment);
            return appointment;
        }

        public bool DeleteAppointment(int appointmentId)
        {
            if (_appointmentRepository.DeleteAppointment(appointmentId))
            {
                return true;
            }
            else
            {
                throw new AppointmentNotFoundException($"Appointment with Id:{appointmentId} does not exist");
            }
        }

        public List<Appointment> GetAllAppointmentByAdminId(int adminId)
        {
            var AppointmentInfo = _appointmentRepository.GetAllAppointmentByAdminId(adminId);
            if (AppointmentInfo != null)
            {
                return _appointmentRepository.GetAllAppointmentByAdminId(adminId);
            }
            else
            {
                throw new AdminNotFoundException($"Admin with Id:{adminId} does not exist");
            }
        }

        public List<Appointment> GetAllAppointmentByUserId(int userId)
        {
            var AppointmentInfo = _appointmentRepository.GetAllAppointmentByUserId(userId);
            if (AppointmentInfo != null)
            {
                return _appointmentRepository.GetAllAppointmentByUserId(userId);
            }
            else
            {
                throw new UserNotFoundException($"User with Id:{userId} does not exist");
            }
        }

        public bool UpdateAppointment(Appointment appointment, int appointmentId)
        {
            var AppointmentInfo = _appointmentRepository.GetAllAppointmentByUserId(appointmentId);
            if (AppointmentInfo != null)
            {
                return _appointmentRepository.UpdateAppointment(appointmentId,appointment);
            }
            else
            {
                throw new Exception($"Appointment with Id:{appointmentId} does not exist");
            }
        }
    }
}
