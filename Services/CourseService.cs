using BlazeUTS.Models;
using BlazeUTS.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazeUTS.Services
{
    public class CourseService : ICourseService
    {
        private readonly BlazeUTSContext _context;

        // Konstruktor untuk menginisialisasi konteks database
        public CourseService(BlazeUTSContext context)
        {
            _context = context;
        }

        // Mengambil semua kursus dari database
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _context.Courses.Include(c => c.Category).ToListAsync(); // Mengembalikan semua kursus beserta kategori terkait
        }

        // Mengambil kursus berdasarkan ID
        public async Task<Course> GetCourseById(int id)
        {
            return await _context.Courses.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id); // Mencari kursus berdasarkan ID
        }

        // Menambahkan kursus baru ke database
        public async Task AddCourse(Course course)
        {
            _context.Courses.Add(course); // Menambahkan kursus ke context
            await _context.SaveChangesAsync(); // Menyimpan perubahan ke database
        }

        // Memperbarui kursus yang ada
        public async Task UpdateCourse(Course course)
        {
            _context.Courses.Update(course); // Memperbarui kursus dalam context
            await _context.SaveChangesAsync(); // Menyimpan perubahan ke database
        }

        // Menghapus kursus berdasarkan ID
        public async Task DeleteCourse(int id)
        {
            var course = await GetCourseById(id); // Mencari kursus berdasarkan ID
            if (course != null) // Jika kursus ditemukan
            {
                _context.Courses.Remove(course); // Menghapus kursus dari context
                await _context.SaveChangesAsync(); // Menyimpan perubahan ke database
            }
        }
    }
}
