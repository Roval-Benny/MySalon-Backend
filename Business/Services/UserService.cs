using DAL;
using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;
using Exceptions;


namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }
        //public string CreateJWToken(User user)
        //{
        //    return _userRepository.CreateJWToken(user);
        //}

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public bool DeleteUser(string phoneNo)
        {
            if (_userRepository.DeleteUser(phoneNo))
            {
                return true;
            }
            else
            {
                throw new UserNotFoundException($"Admin with phone number:{phoneNo} does not exist");
            }
        }

        public User GetUser(string phoneNo)
        {
            if (_userRepository.GetUser(phoneNo) != null)
            {
                return _userRepository.GetUser(phoneNo);
            }
            else
            {
                throw new UserNotFoundException($"The user with phone no: {phoneNo} not exists");
            }
        }

        //public string ValidateJWTToken(User user)
        //{

        //    if (_userRepository.ValidateJWTToken(user) != null)
        //    {
        //        throw new JWTValidationException($"This userid: {user.UserId} already exists");
        //    }
        //    else
        //    {
        //        return (string)_userRepository.ValidateJWTToken(user);
        //    }
        //}
    }
}