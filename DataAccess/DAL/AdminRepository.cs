using DAL;
using Microsoft.EntityFrameworkCore;
using MySalonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
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

        public bool DeleteAdmin(int id)
        {
            var admin = _salondbcontext.Admins.Find(id);
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
            Admin adminToUpdate = _salondbcontext.Admins.Find(admin.Id);
            if (adminToUpdate == null)
            {
                return false;
            }
            else
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
        }
    }
}
