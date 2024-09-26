using System;
using System.ComponentModel.DataAnnotations;
namespace EasyPeasy.Api.Domain.Dtos.Category;

public class CategoryDTO
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Titulo é obrigatório")]
    [MaxLength(80, ErrorMessage = "Título deve ter no máximo 80 caracteres")]
    [MinLength(5, ErrorMessage = "Título deve ter no mínimo 5 caracteres")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Descrição é obrigatória")]
    [MaxLength(255, ErrorMessage = "Descrição deve ter no máximo 255 caracteres")]
    [MinLength(10, ErrorMessage = "Descrição deve ter no mínimo 10 caracteres")]
    public string? Description { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}

public class CategoryMinDTO
{
    [Required(ErrorMessage = "Titulo é obrigatório")]
    [MaxLength(80, ErrorMessage = "Título deve ter no máximo 80 caracteres")]
    [MinLength(5, ErrorMessage = "Título deve ter no mínimo 5 caracteres")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Descrição é obrigatória")]
    [MaxLength(255, ErrorMessage = "Descrição deve ter no máximo 255 caracteres")]
    [MinLength(10, ErrorMessage = "Descrição deve ter no mínimo 10 caracteres")]
    public string? Description { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}