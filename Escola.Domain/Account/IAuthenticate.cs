using Escola.Domain.Entities;

namespace Escola.Domain.Account;

public interface IAuthenticate
{
    string GenerateToken(int usuarioId, string email, string role);
    Task<Usuario> GetUsuarioByEmail(string email);
    Task<bool> UsuarioExiste(string email);
    Task<bool> AuthenticateAsync(string email, string senha);

}