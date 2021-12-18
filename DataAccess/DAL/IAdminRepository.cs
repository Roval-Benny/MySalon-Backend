using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface IAdminRepository
    {
        Admin GetAdminByUserName(string phoneNo);
        Admin CreateAdmin(Admin admin);
        bool DeleteAdmin(int adminId);
        bool UpdateAdmin(Admin admin);
    }
}
