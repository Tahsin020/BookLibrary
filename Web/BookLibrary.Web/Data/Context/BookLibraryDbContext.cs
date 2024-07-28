using BookLibrary.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookLibrary.Web.Data.Context;

public class BookLibraryDbContext : DbContext
{
    public BookLibraryDbContext(DbContextOptions<BookLibraryDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookLibraryDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    public DbSet<Book> Books { get; set; }
}
