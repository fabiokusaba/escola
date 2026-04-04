namespace Escola.Application.DTOs.Nota;

public class NotaPostDTO
{
    public int MatriculaId { get; set; }
    public int ValorNota { get; set; }
    public bool Aprovado { get; set; }
    public DateTime DataNota { get; set; }
}