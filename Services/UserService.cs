using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Models;

namespace SimpleApi.Services
{
    public class UserService : IUserService
    {
        private ModelStateDictionary _modelState;
        private IUserRepository _userRepository;

        public UserService(ModelStateDictionary modelState, IUserRepository userRepository)
        {
            _modelState = modelState;
            _userRepository = userRepository;
        }

        protected bool ValidateUser(User user)
        {
            if (user.Name == null)
            {
                _modelState.AddModelError("Name", "Name is required.");
            }

            return _modelState.IsValid;
        }

        public IEnumerable<User> ListUsers()
        {
            return _userRepository.GetAll();
        }

        public bool CreateUser(User user)
        {
            if (!ValidateUser(user))
            {
                return false;
            }

            _userRepository.Create(user);
            return true;
        }
    }

    public interface IUserService
    {
        bool CreateUser(User productToCreate);
        IEnumerable<User> ListUsers();
    }
}
