using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Orban_Gabriela_Lab2.Data;
public class LibraryContextFactory:IDesignTimeDbContextFactory<LibraryContext> { public LibraryContext CreateDbContext(string[] args) => new(new DbContextOptionsBuilder<LibraryContext>().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Orban_Gabriela_Lab2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True").Options); }
