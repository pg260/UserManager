using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels;

public class AuthViewModel
{
    [Required(ErrorMessage = "O login não pode ser vazio")]
    public string Login { get; set; }
    
    
    public string Password { get; set; }
    
    
}