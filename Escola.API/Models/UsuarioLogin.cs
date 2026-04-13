using System.ComponentModel.DataAnnotations;

namespace Escola.API.Models;

public class UsuarioLogin
{
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [MaxLength(250, ErrorMessage = "O e-mail deve conter no máximo 250 caracteres")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
    [MaxLength(250, ErrorMessage = "A senha deve ter no máximo 250 caracteres")]
    public string Senha { get; set; }
}