using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EasyPeasy.Api.Domain.Enums;

namespace EasyPeasy.Api.Domain.Dtos.FinancialMovement;

public class FinancialMovementDTO
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Titulo é obrigatório")]
    [MaxLength(80, ErrorMessage = "Título deve ter no máximo 80 caracteres")]
    [MinLength(5, ErrorMessage = "Titulo deve ter no mínimo 5 caracteres")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    public decimal Amount { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }
    [Required(ErrorMessage = "Tipo é obrigatório")]
    public EMovementType Type { get; set; }
    [Required(ErrorMessage = "Categoria é obrigatória")]
    public long CategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
}

