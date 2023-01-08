using Microsoft.EntityFrameworkCore;

namespace lecture_4.Models;

public class AppDbContext: DbContext
{
    private string DbPath;
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "books.db");
        optionsBuilder.UseSqlite($"DATA SOURCE={DbPath}");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book() { Id = 1, Title = "ASP.NET 7.0.0", ReleaseDate = DateTime.Parse("2022-12-10"), PublisherId = 1},
            new Book() { Id = 2, Title = "Java", ReleaseDate = DateTime.Parse("2022-11-10"), PublisherId = 2},
            new Book() { Id = 3, Title = "C# 11", ReleaseDate = DateTime.Parse("2023-01-07"), PublisherId = 1}
        );
        modelBuilder.Entity<Author>().HasData(
            new Author() {Id = 1, FirstName = "Adam", LastName = "Kowal",    PESEL = "12345678901"},
            new Author() {Id = 2, FirstName = "Robert", LastName = "Martin", PESEL = "77777777777"},
            new Author() {Id = 3, FirstName = "Adam", LastName = "Freeman",    PESEL = "45678912344"}
        );
        modelBuilder.Entity<Book>(b =>
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Created)
                .HasColumnName("crated_at")
                .HasDefaultValueSql("datetime('now', 'localtime')");
            b.HasOne<Publisher>(e => e.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(e => e.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<Publisher>().HasData(
            new Publisher() {Id = 1, Name = "Helion", Address = "Gliwice"},
            new Publisher() {Id = 2, Name = "PWN", Address = "Warszawa"}
        );
        modelBuilder.Entity<Book>()
            .Property<DateTime>(b => b.Created)
            .HasDefaultValueSql("datetime('now', 'localtime')");
        modelBuilder.Entity<Book>()
            .HasMany<Author>(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity(join =>
                {
                    join.HasData(
                        new {BooksId = 1, AuthorsId = 1},
                        new {BooksId = 2, AuthorsId = 1},
                        new {BooksId = 3, AuthorsId = 2},
                        new {BooksId = 1, AuthorsId = 3}
                    );
                }
            );
    }
}