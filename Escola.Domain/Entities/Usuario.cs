namespace Escola.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; } // Hash da senha criptografada
    public byte[] PasswordSalt { get; set; } // Verificação do PasswordHash
    public string Perfil { get; set; }
    public bool Excluido { get; set; }
    public ICollection<Matricula> Matriculas { get; set; } // Relacionamento many to many
}