using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetById(int id);
        User GetUser(string phoneNo);
        bool DeleteUser(string phoneNo);
        User CreateUser(User user);
        //string CreateJWToken(User user);
    }
}
