using EasyPeasy.Api.Domain.Dtos.FinancialMovement;

namespace EasyPeasy.Api.Services.Interfaces;

public interface IFinancialMovementService
{
    Task<List<FinancialMovementDTO>> GetAll();
    Task<FinancialMovementDTO?> GetById(long id);
    Task<List<FinancialMovementDTO>?> GetByCategory(long id);
    Task<FinancialMovementDTO> Post(FinancialMovementDTO dto);
    Task<FinancialMovementDTO?> Put(FinancialMovementDTO dto);
    Task<FinancialMovementDTO?> Delete(FinancialMovementDTO dto);
}