namespace BlazeUTS.Models
{
    public class Category
    {
        // Properti ini merupakan primary key untuk entitas Category.
        public int CategoryId { get; set; }  // Primary key

        // Nama kategori, misalnya "Web Programming".
        public string Name { get; set; } = string.Empty;  // Diinisialisasi dengan string kosong

        // Deskripsi kategori, memberikan informasi lebih lanjut tentang kategori tersebut.
        public string Description { get; set; } = string.Empty;  // Diinisialisasi dengan string kosong

        // Koleksi kursus yang termasuk dalam kategori ini.
        public ICollection<Course> Courses { get; set; } = new List<Course>();  // Diinisialisasi dengan list kosong
    }
}
