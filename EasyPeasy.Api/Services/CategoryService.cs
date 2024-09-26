using System;
using System.Runtime.CompilerServices;
using AutoMapper;
using EasyPeasy.Api.Data;
using EasyPeasy.Api.Domain;
using EasyPeasy.Api.Domain.Dtos.Category;
using EasyPeasy.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CategoryDTO>> GetAll()
    {
        var categories = await _context.Categories.AsNoTracking().ToListAsync();

        var categoriesDto = _mapper.Map<List<CategoryDTO>>(categories);

        return categoriesDto;
    }

    public async Task<CategoryDTO?> GetById(long id)
    {
        var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (category == null) return null;

        var categoryDto = _mapper.Map<CategoryDTO>(category);

        return categoryDto;
    }

    public async Task<CategoryDTO> Post(CategoryDTO dto)
    {
        var category = new Category();

        category = _mapper.Map<Category>(dto);

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        var categoryDto = _mapper.Map<CategoryDTO>(category);

        return categoryDto;
    }

    public async Task<CategoryDTO?> Put(CategoryDTO dto)
    {
        var category = new Category();

        category = _mapper.Map<Category>(dto);

        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        var categoryDto = _mapper.Map<CategoryDTO>(category);

        return categoryDto;
    }

    public async Task<CategoryDTO?> Delete(CategoryDTO dto)
    {
        var category = new Category();
        
        category = _mapper.Map<Category>(dto);
        
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();   
            
        var deletedCategoryDto = _mapper.Map<CategoryDTO>(category);
        
        return deletedCategoryDto;

    }
}