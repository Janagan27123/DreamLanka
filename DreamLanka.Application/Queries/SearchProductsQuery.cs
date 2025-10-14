using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Queries;

public class SearchProductsQuery : IRequest<List<ProductDto>>
{
    public string SearchTerm { get; set; } = string.Empty;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}