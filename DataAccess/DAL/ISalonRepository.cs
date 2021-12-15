using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface ISalonRepository
    {
        List<Salon> GetAllSalons();
        Salon GetSalon(int id);
        List<Salon> GetAllSalonsByLocation(string location);

    }
}
