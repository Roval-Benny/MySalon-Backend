using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    interface IAdminService
    {
        Admin GetAdminByUserName(string userName);
        Admin CreateAdmin(Admin admin);
        bool DeleteAdmin(int adminId);
        bool UpdateAdmin(Admin admin, string userName);
    }
}
