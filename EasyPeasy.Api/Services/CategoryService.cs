using System;
using System.Runtime.CompilerServices;
using AutoMapper;
using EasyPeasy.Api.Data;
using EasyPeasy.Api.Domain;
using EasyPeasy.Api.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Api.Services;

public class CategoryService
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

    public async Task<CategoryDTO> GetById(long id)
    {
        var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

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

    public async Task<CategoryDTO> Put(long id, CategoryDTO dto)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        category = _mapper.Map<Category>(dto);

        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        var categoryDto = _mapper.Map<CategoryDTO>(category);

        return categoryDto;
    }

    public async Task<CategoryDTO> Delete(long id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category != null)
        {
            var deletedCategoryDto = _mapper.Map<CategoryDTO>(category);
            
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();   
            
            return deletedCategoryDto;
        }

        return null;
    }
}