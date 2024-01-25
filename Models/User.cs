using System.ComponentModel.DataAnnotations;

namespace SimpleWebApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
