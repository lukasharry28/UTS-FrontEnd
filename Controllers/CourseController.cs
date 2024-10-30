//using BlazeUTS.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace BlazeUTS.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CourseController : ControllerBase
//    {
//        private readonly BlazeUTSContext _context;

//        public CourseController(BlazeUTSContext context)
//        {
//            _context = context;
//        }

//        // Mendapatkan daftar semua kursus dari database, termasuk kategori terkait.
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
//        {
//            return await _context.Courses.Include(c => c.Category).ToListAsync();
//        }

//        // Mendapatkan satu kursus berdasarkan id yang diberikan, termasuk kategori terkait.
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Course>> GetCourse(int id)
//        {
//            var course = await _context.Courses.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
//            if (course == null)
//            {
//                // Mengembalikan status NotFound jika kursus tidak ditemukan.
//                return NotFound();
//            }
//            // Mengembalikan kursus yang ditemukan.
//            return course;
//        }

//        // Membuat kursus baru dengan data yang dikirimkan dalam request.
//        [HttpPost]
//        public async Task<ActionResult<Course>> CreateCourse(Course course)
//        {
//            // Memeriksa apakah kategori yang terkait dengan kursus ada di database.
//            if (!await _context.Categories.AnyAsync(c => c.CategoryId == course.CategoryId))
//            {
//                // Mengembalikan status BadRequest jika kategori tidak ada.
//                return BadRequest("Category does not exist.");
//            }

//            // Menambahkan kursus baru ke dalam context.
//            _context.Courses.Add(course);

//            // Menyimpan perubahan ke database.
//            await _context.SaveChangesAsync();

//            // Mengembalikan status Created dengan lokasi akses kursus yang baru dibuat.
//            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
//        }

//        // Memperbarui kursus yang ada berdasarkan id yang diberikan.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateCourse(int id, Course course)
//        {
//            // Jika id dalam parameter tidak cocok dengan id dari kursus yang dikirim, kembalikan status BadRequest.
//            if (id != course.Id)
//            {
//                return BadRequest();
//            }

//            // Memeriksa apakah kategori yang terkait dengan kursus ada di database.
//            if (!await _context.Categories.AnyAsync(c => c.CategoryId == course.CategoryId))
//            {
//                // Mengembalikan status BadRequest jika kategori tidak ada.
//                return BadRequest("Category does not exist.");
//            }

//            // Menandai entitas kursus sebagai dimodifikasi dalam context.
//            _context.Entry(course).State = EntityState.Modified;

//            try
//            {
//                // Menyimpan perubahan ke database.
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                // Memeriksa apakah kursus masih ada, jika tidak, kembalikan NotFound.
//                if (!CourseExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            // Mengembalikan status NoContent yang menandakan sukses tanpa ada konten yang dikembalikan.
//            return NoContent();
//        }

//        // Menghapus kursus berdasarkan id yang diberikan.
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCourse(int id)
//        {
//            var course = await _context.Courses.FindAsync(id);
//            if (course == null)
//            {
//                // Mengembalikan status NotFound jika kursus tidak ditemukan.
//                return NotFound();
//            }

//            // Menghapus kursus dari context.
//            _context.Courses.Remove(course);

//            // Menyimpan perubahan ke database.
//            await _context.SaveChangesAsync();

//            // Mengembalikan status NoContent yang menandakan penghapusan sukses tanpa ada konten yang dikembalikan.
//            return NoContent();
//        }

//        // Memeriksa apakah kursus dengan id tertentu ada di database.
//        private bool CourseExists(int id)
//        {
//            return _context.Courses.Any(e => e.Id == id);
//        }
//    }
//}
