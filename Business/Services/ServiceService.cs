using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Exceptions;

namespace Services
{
    public class ServiceService : IServiceService
    {

        private readonly IServiceRepository _repository;

        
        public ServiceService(IServiceRepository repo)
        {
            _repository = repo;
        }

        public Service AddService(Service service)
        {
            return _repository.AddService(service);
        }

        public bool DeleteService(Service service)
        {
            if (_repository.DeleteService(service))
            {
                return true;
            }
            else
            {
                throw new ServiceNotFoundException($"Category with service: {service} does not exist");
            }
        }

        public List<Service> GetAllService()
        {
            return _repository.GetAllService();
        }
    }
}



//namespace Services
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;
//        public UserService(IUserRepository repository)
//        {
//            _userRepository = repository;
//        }


//public User CreateUser(User user)
//{

//    if (_userRepository.CreateUser(user.UserId) != null)
//    {
//        throw new ArgumentNullException($"This userid: {user.UserId} already exists");
//    }
//    else
//    {
//        return _userRepository.CreateUser(user);
//    }
//}

//public bool DeleteUser(string phoneNo)
//{
//    return _userRepository.DeleteUser(phoneNo);
//}