using System.ComponentModel.DataAnnotations;

namespace GalloFlix.DataTransferObjects
{
    public class RegisterDto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Por favor, informe seu Nome")]
        [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
        public string Name { get; set; }    

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Por favor, informe seu Email")]
        [EmailAddress(ErrorMessage = "Por favor, informe um Email válido")]
        [StringLength(100, ErrorMessage = "O nome deve possuir no máximo 100 caracteres")]
        public string Email { get; set; }    

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Por favor, informe sua Data de Nascimento")]
        public DateTime DateOfBirth { get; set; }    

        
       
       
        [DataType(DataType.Password)]
        [Display(Name = "Senha de Acesso")]
        [Required(ErrorMessage = "Por favor, informe sua Senha")]
        [StringLength(20, MinimumLength = 6,
         ErrorMessage = " A senha deve possuir no máximo 20 caracteres e no mínimo 6")]
        public DateTime Password { get; set; }  

        
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "As Senhas não conferem.")]
        public DateTime ConfirmPassword { get; set; }  
    }
}