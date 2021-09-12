using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models   
{
    [Table("Usuario")]
    public class User{
        [Key]
        public int Id {get;set;}

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]

        public string Name {get;set;}
        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres!")]

        public string Email {get;set;}

        public string Image {get;set;}

        public string Username {get;set;}
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]

        public string Password {get;set;}
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]

        public string Role {get;set;}

        public string Token{get;set;}

    }
}