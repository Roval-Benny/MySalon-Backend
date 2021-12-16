using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        User GetUser(string phoneNo);
        bool DeleteUser(string phoneNo);
        User CreateUser(User user);
        //string CreateJWToken(User user);
    }
}