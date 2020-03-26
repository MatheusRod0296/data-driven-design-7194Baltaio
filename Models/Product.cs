using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class Product
    {
         [Key]
        public  int Id {get; set;}
        [Required(ErrorMessage ="campo obrigatorio")]
        [MaxLength(60, ErrorMessage ="campo deve conter de 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage ="campo deve conter de 3 a 60 caracteres")]
        public  string Title {get; set;}
        [MaxLength(1024, ErrorMessage ="campo deve conter ate 1024 caracteres")]

        public string Description { get; set; }

        [Required(ErrorMessage = "campo obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "o preço deve ser maior que zero")]
        [Column( TypeName="decimal")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "campo obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "categoria invalida")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}