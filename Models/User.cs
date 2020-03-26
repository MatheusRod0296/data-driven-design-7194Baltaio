using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string UserName { get; set; }

         [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}