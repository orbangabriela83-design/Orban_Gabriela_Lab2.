using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Orban_Gabriela_Lab2.Data;
public class SqliteLibraryContext(DbContextOptions<SqliteLibraryContext> options):LibraryContext(options) { }
public class SqliteLibraryFactory:IDesignTimeDbContextFactory<SqliteLibraryContext> {
 public SqliteLibraryContext CreateDbContext(string[] args)=>new(new DbContextOptionsBuilder<SqliteLibraryContext>().UseSqlite("Data Source=library.db").Options);
}
