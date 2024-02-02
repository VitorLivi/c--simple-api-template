using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApi.Models
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }
    }
}
