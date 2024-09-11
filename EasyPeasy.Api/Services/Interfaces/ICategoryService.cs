using EasyPeasy.Api.Domain;
using EasyPeasy.Api.Domain.Dtos;

namespace EasyPeasy.Api.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDTO>> GetAll();
    Task<CategoryDTO> GetById(long id);
    Task<CategoryDTO> Post(CategoryDTO dto);
    Task<CategoryDTO> Put(long id, CategoryDTO dto);
    Task<CategoryDTO> Delete(long id);
}