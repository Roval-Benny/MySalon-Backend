using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface ISalonServiceRepository
    {
        List<SalonServices> GetAllSalonServiceSalonId(int salonId,int category);
        List<SalonServices> GetAllSalonServiceSalonId(int salonId);
        SalonServices UpdateSalonService(int salonId,int serviceId,SalonServices salon);

    }
}
