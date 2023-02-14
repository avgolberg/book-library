using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class BookLibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookType> BookTypes { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<CoverType> CoverTypes { get; set; }

    public DbSet<User> Users { get; set; }

    public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
        : base(options)
    {
    }
}