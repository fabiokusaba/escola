namespace Escola.Application.DTOs.Matricula;

public class MatriculaPostDTO
{
    public int UsuarioId { get; set; }
    public int TurmaId { get; set; }
    public DateTime DataMatricula { get; set; }
    public DateTime DataExpiracao { get; set; }
    public bool Ativa { get; set; }
}