using System;
namespace EasyPeasy.Api.Domain.Dtos;

public class CategoryDTO
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}