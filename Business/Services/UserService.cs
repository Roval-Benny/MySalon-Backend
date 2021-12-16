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
            if (_userRepository.DeleteUser(phoneNo) == false)
            {
                throw new UserNotFoundException($"This userid: {phoneNo} already exists");
            }
            else
            {
                return _userRepository.DeleteUser(phoneNo);
            }
        }

        public User GetUser(string phoneNo)
        {
            if (_userRepository.GetUser(phoneNo) != null)
            {
                throw new UserAlreadyExistsException($"This userid: {phoneNo} already exists");
            }
            else
            {
                return _userRepository.GetUser(phoneNo);
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