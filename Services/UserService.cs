using SimpleApi.Models;
using SimpleApi.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

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

        protected bool ValidateName(string name)
        {
            if (name == null || name.Trim().Length == 0)
            {
                _modelState.AddModelError("Name", "Name is required.");
            }

            return _modelState.IsValid;
        }

        public IEnumerable<User> ListUsers()
        {
            return this._userRepository.FindAll();
        }

        public bool CreateUser(string name)
        {
            if (!ValidateName(name))
            {
                System.Diagnostics.Debug.WriteLine("Invalid name");
                var problemDetails = new ValidationProblemDetails(_modelState);
                throw new BadHttpRequestException(problemDetails);

            }

            this._userRepository.Insert(new User(name));
            return true;
        }
    }

    public interface IUserService
    {
        bool CreateUser(string name);
        IEnumerable<User> ListUsers();
    }
}
