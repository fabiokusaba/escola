namespace Escola.Application.DTOs.Usuario;

public class UsuarioPutDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Perfil { get; set; }
}