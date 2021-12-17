﻿using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    interface ISalonServiceService
    {
        List<SalonServices> GetAllSalonServiceSalonId(int salonId, int category);
        List<SalonServices> GetAllSalonServiceSalonId(int salonId);
        bool UpdateSalonService(int salonId,SalonServices salon);
    }
}