using System.ComponentModel.DataAnnotations;

namespace Escola.API.Models;

public class PaginationParams
{
    [Range(1, int.MaxValue, ErrorMessage = "A página deve ser maior que 1.")]
    public int PageNumber { get; set; }
    [Range(1, 50, ErrorMessage = "O tamanho da página deve ser maior que 1 e no máximo 50 itens.")]
    public int PageSize { get; set; }
}