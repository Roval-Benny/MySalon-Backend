using Microsoft.IdentityModel.Tokens;
using MySalonModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly MySalonDbContext _context;
        public UserRepository(MySalonDbContext dbContext)
        {
            _context = dbContext;
        }
        //public User CreateJWToken(User user)
        //{
        //    _context.Users.Add(user);
        //    _context.SaveChanges();
        //    return user;
        //}

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(string phoneNo)
        {

            var user = _context.Users.FirstOrDefault(u => u.PhoneNo == phoneNo);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public User GetUser(string phoneNo)
        {
            return _context.Users.FirstOrDefault(item => item.PhoneNo == phoneNo);

        }

        //public string CreateJWToken(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public object ValidateJWT(User users)
        //{
        //    throw new NotImplementedException();
        //}
        //public bool IsValidUserInformation(LoginModel model)
        //{
        //    if (model.UserName.Equals("Jay") && model.Password.Equals("123456")) return true;
        //    else return false;
        //}

    }
}

