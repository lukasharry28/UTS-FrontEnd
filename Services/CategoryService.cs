// CategoryService.cs
using BlazeUTS.Models;
using BlazeUTS.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazeUTS.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BlazeUTSContext _context;

        // Konstruktor untuk menginisialisasi konteks database
        public CategoryService(BlazeUTSContext context)
        {
            _context = context;
        }

        // Mengambil semua kategori dari database
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync(); // Mengembalikan semua kategori dalam bentuk list
        }

        // Mengambil kategori berdasarkan ID
        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id); // Mencari kategori berdasarkan ID
        }

        // Menambahkan kategori baru ke database
        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category); // Menambahkan kategori ke context
            await _context.SaveChangesAsync(); // Menyimpan perubahan ke database
        }

        // Memperbarui kategori yang ada
        public async Task UpdateCategory(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.CategoryId); // Mencari kategori yang ada
            if (existingCategory != null) // Jika kategori ditemukan
            {
                existingCategory.Name = category.Name; // Memperbarui nama kategori
                await _context.SaveChangesAsync(); // Menyimpan perubahan ke database
            }
        }

        // Menghapus kategori berdasarkan ID
        public async Task DeleteCategory(int id)
        {
            var category = await GetCategoryById(id); // Mencari kategori berdasarkan ID
            if (category != null) // Jika kategori ditemukan
            {
                _context.Categories.Remove(category); // Menghapus kategori dari context
                await _context.SaveChangesAsync(); // Menyimpan perubahan ke database
            }
        }
    }
}
