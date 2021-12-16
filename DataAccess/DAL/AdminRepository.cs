using DAL;
using Microsoft.EntityFrameworkCore;
using MySalonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.DataAccess
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MySalonDbContext _salondbcontext;
        public AdminRepository(MySalonDbContext dbContext)
        {
            _salondbcontext = dbContext;
        }

        public Admin GetAdminByUserName(string userName)
        {
            return _salondbcontext.Admins.FirstOrDefault(item => item.UserName == userName);
        }

        public Admin CreateAdmin(Admin admin)
        {
            _salondbcontext.Admins.Add(admin);
            _salondbcontext.SaveChanges();
            return admin;
        }

        public bool DeleteAdmin(int adminId)
        {
            var admin = _salondbcontext.Admins.FirstOrDefault(item => item.Id == adminId);
            if (admin != null)
            {
                _salondbcontext.Admins.Remove(admin);
                _salondbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAdmin(Admin admin)
        {
            var adminToUpdate = _salondbcontext.Admins.FirstOrDefault(a => a.Id == admin.Id);
            if (adminToUpdate != null)
            {
                adminToUpdate.Id = admin.Id;
                adminToUpdate.PhoneNo = admin.PhoneNo;
                adminToUpdate.SalonId = admin.SalonId;
                adminToUpdate.SalonName = admin.SalonName;
                adminToUpdate.UserName = admin.UserName;
                _salondbcontext.Entry(adminToUpdate).State = EntityState.Modified;
                _salondbcontext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
