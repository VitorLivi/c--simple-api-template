using Microsoft.AspNetCore.Mvc;

namespace SimpleWebApp.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("json")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "World" };
        }

        [HttpGet]
        [Route("string/{id}")]
        public string Get(int id)
        {
            return $"Hello World {id}";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine(value);
        }

        [HttpPut]
        public void Put([FromBody] string value)
        {
            Console.WriteLine(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine($"Delete {id}");
        }
    }
}
