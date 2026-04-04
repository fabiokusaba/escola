using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Curso;

public class CursoPostDTO
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo descrição é obrigatório.")]
    [MaxLength(150, ErrorMessage = "A descrição deve ter no máximo 150 caracteres.")]
    public string Descricao { get; set; }
}