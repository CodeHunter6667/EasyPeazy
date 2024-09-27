using EasyPeasy.Api.Domain;
using EasyPeasy.Api.Domain.Dtos;
using EasyPeasy.Api.Domain.Dtos.Category;
using EasyPeasy.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyPeasy.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Tags("Categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [EndpointName("Categories = Get All")]
    [EndpointSummary("Recupera todas as categorias")]
    [EndpointDescription("Recupera todas as categorias")]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAll();
        
        return Ok(categories);
    }

    [HttpGet("{id:long}", Name = "GetCategory")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var category = await _categoryService.GetById(id);
        if (category == null) return NotFound();
        
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryDTO dto)
    {
        if(dto == null) return BadRequest();
        var category = await _categoryService.Post(dto);
        
        return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] CategoryDTO dto)
    {
        if (id != dto.Id && dto == null) return BadRequest();
        var category = await _categoryService.GetById(id);
        if(category == null) return NotFound();
        
        category = await _categoryService.Put(dto);
        
        return Ok(category);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var category = await _categoryService.GetById(id);
        if(category == null) return NotFound();
        
        await _categoryService.Delete(category);
        
        return NoContent();
    }
}