using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models   
{
    [Table("Produto")]
    public class Product{
        [Key]
        public int Id {get;set;}

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]

        public string Title {get;set;}

        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres!")]

        public string Brand {get;set;}

        public string Tag {get;set;}

        public decimal Price {get;set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        //[Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]

        public string Description {get;set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        //[Range(1, int.MaxValue, ErrorMessage = "Maior que zero")]

        public string Images {get;set;}

        public int CategoryId {get;set;}

        public Category Category {get;set;}


    }
}