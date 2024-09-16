using System;
using EasyPeasy.Api.Domain.Enums;

namespace EasyPeasy.Api.Domain;

public class FinancialMovement : EntityBase
{
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public EMovementType Type { get; set; } = EMovementType.EXPENSE;
    public Category Category { get; set; } = null!;
    public long CategotyId { get; set; }
    public string UserId { get; set; } = string.Empty;
}