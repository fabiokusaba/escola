namespace Escola.Application.DTOs.Turma;

public class TurmaPutDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int CursoId { get; set; }
}