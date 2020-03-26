using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Category
    {
        [Key]
        public  int Id {get; set;}
        [Required(ErrorMessage ="campo obrigatorio")]
        [MaxLength(60, ErrorMessage ="campo deve conter de 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage ="campo deve conter de 3 a 60 caracteres")]
        public  string Title {get; set;}
    }
}