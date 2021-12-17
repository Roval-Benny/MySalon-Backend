using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface IServiceRepository
    {
        List<Service> GetAllService();
        Service AddService(Service service);
        bool DeleteService(int serviceId);

    }
}
