using BlazeUTS.Models;

namespace BlazeUTS.Data
{
    public static class SeedData
    {
        // Fungsi untuk menginisialisasi data awal (seeding) ke dalam database.
        public static void Initialize(BlazeUTSContext db)
        {
            // Jika sudah ada data di tabel Categories atau Courses, tidak melakukan apa-apa.
            if (db.Categories.Any() || db.Courses.Any())
            {
                return; // Keluar dari fungsi jika data sudah ada.
            }

            // Membuat array kategori untuk data awal.
            var categories = new Category[]
            {
                new Category { Name = "Web Programming", Description = "Web Programming Course" },
                new Category { Name = "Desktop Programming", Description = "Desktop Programming Course" }
            };

            // Menambahkan kategori ke database.
            db.Categories.AddRange(categories);
            db.SaveChanges(); // Simpan kategori sebelum menggunakannya di data kursus

            // Membuat array kursus dengan referensi ke kategori yang baru dibuat.
            var courses = new Course[]
            {
                new Course { Name = "ASP Core Programming", ImageName = "aspcore.png", Duration = 3, Description = "ASP Core Programming Course", CategoryId = categories[0].CategoryId },
                new Course { Name = "Maui Programming", ImageName = "maui.png", Duration = 4, Description = "Maui Mobile Programming Course", CategoryId = categories[0].CategoryId },
                new Course { Name = "Java Programming", ImageName = "java.png", Duration = 3, Description = "Java Desktop Programming Course", CategoryId = categories[1].CategoryId }
            };

            // Menambahkan kursus ke database.
            db.Courses.AddRange(courses);
            db.SaveChanges(); // Simpan kursus ke database
        }
    }
}
