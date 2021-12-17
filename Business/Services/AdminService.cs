using DAL;
using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;
using Exceptions;

namespace Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminrepository;
        public AdminService(IAdminRepository repo)
        {
            _adminrepository = repo;
        }
        public Admin CreateAdmin(Admin admin)
        {
            return _adminrepository.CreateAdmin(admin);
            
        }

        public bool DeleteAdmin(int adminId)
        {
            if (_adminrepository.DeleteAdmin(adminId))
            {
                return true;
            }
            else
            {
                throw new AdminNotFoundException($"Admin with Id:{adminId} does not exist");
            }
        }

        public Admin GetAdminByUserName(string phoneNo)
        {
            var adminInfo = _adminrepository.GetAdminByUserName(phoneNo);
            if (adminInfo != null)
            {
                return _adminrepository.GetAdminByUserName(phoneNo);
            }
            else
            {
                throw new AdminNotFoundException($"Admin with Phone Number:{phoneNo} does not exist");

            }
        }

        public bool UpdateAdmin(Admin admin, string userName)
        {
            admin.UserName = userName;
            if (_adminrepository.UpdateAdmin(admin))
            {
                return true;
            }
            else
            {
                throw new AdminNotFoundException($"Admin with UserName:{userName} does not exist");

            }
        }
    }
}
