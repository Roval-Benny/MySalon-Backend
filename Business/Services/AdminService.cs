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

        public Admin GetAdminByUserName(string userName)
        {
            var adminInfo = _adminrepository.GetAdminByUserName(userName);
            if (adminInfo != null)
            {
                return _adminrepository.GetAdminByUserName(userName);
            }
            else
            {
                throw new AdminNotFoundException($"Admin with UserName:{userName} does not exist");

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
