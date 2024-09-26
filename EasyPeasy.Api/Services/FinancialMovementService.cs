using AutoMapper;
using EasyPeasy.Api.Data;
using EasyPeasy.Api.Domain;
using EasyPeasy.Api.Domain.Dtos.FinancialMovement;
using EasyPeasy.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Api.Services;

public class FinancialMovementService : IFinancialMovementService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public FinancialMovementService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<FinancialMovementDTO>> GetAll()
    {
        var movements = await _context.FinancialMovements
            .AsNoTracking()
            .ToListAsync();
        
        var movementsDto = _mapper.Map<List<FinancialMovementDTO>>(movements);
        
        return movementsDto;
    }

    public async Task<FinancialMovementDTO?> GetById(long id)
    {
        var movement = await _context.FinancialMovements
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        
        var movementDto = _mapper.Map<FinancialMovementDTO>(movement);
        
        return movementDto;
    }

    public async Task<List<FinancialMovementDTO>?> GetByCategory(long id)
    {
        var movements = await _context.FinancialMovements
            .AsNoTracking()
            .Where(x => x.CategotyId == id)
            .ToListAsync();
        
        var movementsDto = _mapper.Map<List<FinancialMovementDTO>>(movements);
        
        return movementsDto;
    }

    public async Task<FinancialMovementDTO> Post(FinancialMovementDTO dto)
    {
        var movement = _mapper.Map<FinancialMovement>(dto);
        
        _context.FinancialMovements.Add(movement);
        await _context.SaveChangesAsync();
        var movementDto = _mapper.Map<FinancialMovementDTO>(movement);
        
        return movementDto;
    }

    public async Task<FinancialMovementDTO?> Put(FinancialMovementDTO dto)
    {
        var movement = _mapper.Map<FinancialMovement>(dto);
        
        _context.FinancialMovements.Update(movement);
        await _context.SaveChangesAsync();
        var movementDto = _mapper.Map<FinancialMovementDTO>(movement);
        
        return movementDto;
    }

    public async Task<FinancialMovementDTO?> Delete(FinancialMovementDTO dto)
    {
        var movement = _mapper.Map<FinancialMovement>(dto);
        
        _context.FinancialMovements.Remove(movement);
        await _context.SaveChangesAsync();
        var deletedFinancialMovement = _mapper.Map<FinancialMovementDTO>(movement);
        
        return deletedFinancialMovement;
    }
}