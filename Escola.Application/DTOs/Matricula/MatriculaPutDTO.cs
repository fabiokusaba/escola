namespace Escola.Application.DTOs.Matricula;

public class MatriculaPutDTO
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int TurmaId { get; set; }
    public DateTime DataMatricula { get; set; }
    public DateTime DataExpiracao { get; set; } // Vencimento da matrícula
    public bool Ativa { get; set; }
}