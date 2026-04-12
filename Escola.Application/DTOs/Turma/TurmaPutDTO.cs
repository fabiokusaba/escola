using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Turma;

public class TurmaPutDTO
{
    [Required(ErrorMessage = "O identificador da turma é obrigatório")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo descrição é obrigatório")]
    [MaxLength(150, ErrorMessage = "A descrição deve ter no máximo 150 caracteres")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "O curso é obrigatório")]
    public int CursoId { get; set; }
}