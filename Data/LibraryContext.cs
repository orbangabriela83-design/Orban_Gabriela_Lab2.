using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Models;
namespace Orban_Gabriela_Lab2.Data;
public class LibraryContext:DbContext {
 public LibraryContext(DbContextOptions<LibraryContext> options):base(options) {}
 protected LibraryContext(DbContextOptions options):base(options) {}
 public DbSet<Book> Book => Set<Book>();
 public DbSet<Publisher> Publisher => Set<Publisher>();
 public DbSet<Author> Author => Set<Author>();
 protected override void OnModelCreating(ModelBuilder modelBuilder) {
 base.OnModelCreating(modelBuilder);
 modelBuilder.Entity<Book>().HasOne(b=>b.Author).WithMany(a=>a.Books).HasForeignKey(b=>b.AuthorID).OnDelete(DeleteBehavior.SetNull);
 modelBuilder.Entity<Book>().HasOne(b=>b.Publisher).WithMany(p=>p.Books).HasForeignKey(b=>b.PublisherID).OnDelete(DeleteBehavior.SetNull);
 }
}