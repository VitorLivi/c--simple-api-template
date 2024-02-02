using Microsoft.AspNetCore.Mvc;
using SimpleApi.Models;
using SimpleApi.Repository;
using SimpleApi.Services;

namespace SimpleApi.Controllers
{
    public class CreateUserDto
    {
        public string name { get; set; }
    }

    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;


        public UserController()
        {
            _service = new UserService(this.ModelState, new UserRepository(new ApplicationDbContext()));
        }

        [HttpPost]
        [Route("user")]
        public void CreateUser([FromBody] CreateUserDto dto)
        {
                this._service.CreateUser(dto.name);
        }


        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get()
        {
            return this._service.ListUsers();
        }
    }
}
