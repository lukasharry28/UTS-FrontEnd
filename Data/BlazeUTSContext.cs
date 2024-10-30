using BlazeUTS.Models;
using Microsoft.EntityFrameworkCore;

public class BlazeUTSContext : DbContext
{
    // Konstruktor yang menerima opsi dan meneruskannya ke konstruktor DbContext induk.
    public BlazeUTSContext(DbContextOptions<BlazeUTSContext> options) : base(options)
    {
    }

    // DbSet untuk kategori (Categories), yang merepresentasikan tabel Category dalam database.
    public DbSet<Category> Categories { get; set; }

    // DbSet untuk kursus (Courses), yang merepresentasikan tabel Course dalam database.
    public DbSet<Course> Courses { get; set; }

    // Metode yang digunakan untuk konfigurasi lebih lanjut model entitas saat membuat model.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Konfigurasi relasi antara entitas Course dan Category.
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Category)        // Setiap Course memiliki satu Category.
            .WithMany(c => c.Courses)       // Setiap Category memiliki banyak Courses.
            .HasForeignKey(c => c.CategoryId); // Foreign key adalah CategoryId di Course.
    }
}
