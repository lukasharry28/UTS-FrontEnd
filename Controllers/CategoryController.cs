//using BlazeUTS.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace BlazeUTS.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CategoryController : ControllerBase
//    {
//        private readonly BlazeUTSContext _context;

//        public CategoryController(BlazeUTSContext context)
//        {
//            _context = context;
//        }

//        // Mendapatkan daftar semua kategori dari database.
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
//        {
//            return await _context.Categories.ToListAsync();
//        }

//        // Mendapatkan kategori berdasarkan id yang diberikan.
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Category>> GetCategory(int id)
//        {
//            var category = await _context.Categories.FindAsync(id);
//            if (category == null)
//            {
//                // Mengembalikan status NotFound jika kategori tidak ditemukan.
//                return NotFound();
//            }
//            // Mengembalikan kategori yang ditemukan.
//            return category;
//        }

//        // Membuat kategori baru dengan data yang dikirimkan dalam request.
//        [HttpPost]
//        public async Task<ActionResult<Category>> CreateCategory(Category category)
//        {
//            // Menambahkan kategori baru ke dalam context.
//            _context.Categories.Add(category);

//            // Menyimpan perubahan ke database.
//            await _context.SaveChangesAsync();

//            // Mengembalikan status Created dengan lokasi akses kategori yang baru dibuat.
//            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
//        }

//        // Mengubah data kategori yang ada berdasarkan id yang diberikan.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateCategory(int id, Category category)
//        {
//            // Jika id dalam parameter tidak cocok dengan id dari kategori yang dikirim, kembalikan status BadRequest.
//            if (id != category.CategoryId)
//            {
//                return BadRequest();
//            }

//            // Menandai entitas kategori sebagai dimodifikasi dalam context.
//            _context.Entry(category).State = EntityState.Modified;

//            // Menyimpan perubahan ke database.
//            await _context.SaveChangesAsync();

//            // Mengembalikan status NoContent yang menandakan sukses tanpa ada konten yang dikembalikan.
//            return NoContent();
//        }

//        // Menghapus kategori berdasarkan id yang diberikan.
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCategory(int id)
//        {
//            var category = await _context.Categories.FindAsync(id);
//            if (category == null)
//            {
//                // Mengembalikan status NotFound jika kategori tidak ditemukan.
//                return NotFound();
//            }

//            // Menghapus kategori dari context.
//            _context.Categories.Remove(category);

//            // Menyimpan perubahan ke database.
//            await _context.SaveChangesAsync();

//            // Mengembalikan status NoContent yang menandakan penghapusan sukses tanpa ada konten yang dikembalikan.
//            return NoContent();
//        }
//    }
//}
