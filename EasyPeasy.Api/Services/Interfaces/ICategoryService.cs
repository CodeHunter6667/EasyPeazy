using EasyPeasy.Api.Domain.Dtos.Category;

namespace EasyPeasy.Api.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDTO>> GetAll();
    Task<CategoryDTO?> GetById(long id);
    Task<CategoryDTO> Post(CategoryDTO dto);
    Task<CategoryDTO?> Put(CategoryDTO dto);
    Task<CategoryDTO?> Delete(CategoryDTO dto);
}