using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ISalonService
    {
        List<Salon> GetAllSalons();
        Salon GetSalon(int id);
        List<Salon> GetAllSalonsByLocation(string location);

        Salon CreateSalon(Salon salon);

    }
}
