using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface IAdminRepository
    {
        Admin GetAdminByUserName(string userName);
        Admin CreateAdmin(Admin admin);
        bool DeleteAdmin(Admin admin);
        Admin UpdateAdmin(Admin admin);
    }
}
