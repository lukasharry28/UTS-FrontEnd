// ICategoryService.cs
using BlazeUTS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazeUTS.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
