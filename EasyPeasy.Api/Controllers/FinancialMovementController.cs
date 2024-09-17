using EasyPeasy.Api.Domain;
using EasyPeasy.Api.Domain.Dtos;
using EasyPeasy.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.Api.Controllers;

[ApiController]
[Route("movements")]
public class FinancialMovementController : ControllerBase
{
    private readonly IFinancialMovementService _service;

    public FinancialMovementController(IFinancialMovementService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var movements = await _service.GetAll();

        return Ok(movements);
    }
    
    [HttpGet("/{id:long}", Name = "NewFinancialMovement")]
    public async Task<ActionResult<FinancialMovementDTO>> GetById(int id)
    {
        var movement = await _service.GetById(id);
        if (movement == null) return NotFound();
        
        return Ok(movement);
    }

    [HttpGet("/category/{id:long}")]
    public async Task<ActionResult<FinancialMovementDTO>> GetMovementsByCategory([FromRoute] long categoryId)
    {
        var movements = await _service.GetByCategory(categoryId);
        
        return Ok(movements);
    }

    [HttpPost]
    public async Task<ActionResult<FinancialMovementDTO>> Create([FromBody] FinancialMovementDTO dto)
    {
        if (dto == null) return BadRequest();

        var movement = await _service.Post(dto);
        
        return new CreatedAtRouteResult("NewFinancialMovement", new { id = movement.Id }, movement);
    }

    [HttpPut("/{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] FinancialMovementDTO dto)
    {
        if (dto == null) return BadRequest();
        var movement = await _service.GetById(id);
        if (movement == null) return NotFound();
        
        movement = await _service.Put(dto);
        
        return Ok(movement);
    }

    [HttpDelete("/{id:long}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var movement = await _service.GetById(id);
        if(movement == null) return NotFound();
        
        await _service.Delete(movement);
        
        return NoContent();
    }
}