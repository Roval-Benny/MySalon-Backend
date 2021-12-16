using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;
using DAL;

namespace Services
{
    public interface IServiceService
    {
        List<Service> GetAllService();
        Service AddService(Service service);
        bool DeleteService(Service service);

    }
}

