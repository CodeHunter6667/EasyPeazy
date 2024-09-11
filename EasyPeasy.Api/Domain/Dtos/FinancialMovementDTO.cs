using System;
using EasyPeasy.Api.Domain.Enums;

namespace EasyPeasy.Api.Domain.Dtos;

public class FinancialMovementDTO
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public EMovementType Type { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
}

