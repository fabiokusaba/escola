using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Usuario;

public class UsuarioPutDTO
{
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [MaxLength(250, ErrorMessage = "O nome deve ter no máximo 250 caracteres")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo e-mail é obrigatório")]
    [MaxLength(250, ErrorMessage = "O e-mail deve ter no máximo 250 caracteres")]
    [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo senha é obrigatório")]
    [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
    [MaxLength(250, ErrorMessage = "A senha deve ter no máximo 250 caracteres")]
    public string Senha { get; set; }
}