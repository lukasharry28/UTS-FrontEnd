namespace BlazeUTS.Models
{
    public class Course
    {
        // Properti ini merupakan primary key untuk entitas Course.
        public int Id { get; set; }

        // Nama kursus, misalnya "ASP Core Programming".
        public string Name { get; set; }

        // Nama file gambar yang terkait dengan kursus (misalnya, untuk thumbnail atau logo).
        public string ImageName { get; set; }

        // Durasi kursus dalam satuan waktu, misalnya dalam minggu atau jam.
        public int Duration { get; set; }

        // Deskripsi kursus, memberikan informasi lebih lanjut tentang konten atau tujuan kursus.
        public string Description { get; set; }

        // Foreign key yang mereferensikan kategori terkait, menghubungkan kursus dengan kategori.
        public int CategoryId { get; set; }

        // Properti navigasi yang merepresentasikan hubungan dengan entitas Category.
        // Menandakan bahwa setiap kursus memiliki satu kategori.
        public Category? Category { get; set; }
    }
}
