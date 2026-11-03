using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Data;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var connection=builder.Configuration.GetConnectionString("LibraryContext") ?? throw new InvalidOperationException("Missing LibraryContext");
var sqlite=builder.Configuration["DatabaseProvider"]=="Sqlite";
if(sqlite){
 builder.Services.AddDbContext<SqliteLibraryContext>(o=>o.UseSqlite("Data Source=library.db"));
 builder.Services.AddScoped<LibraryContext>(sp=>sp.GetRequiredService<SqliteLibraryContext>());
}else builder.Services.AddDbContext<LibraryContext>(o=>o.UseSqlServer(connection));

// Optional isolated development key storage for automated local verification.
if(builder.Environment.IsDevelopment() && builder.Configuration["DataProtectionDirectory"] is string keyDirectory)
 builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(keyDirectory));
builder.Services.Configure<RequestLocalizationOptions>(o=>o.SetDefaultCulture("en-US").AddSupportedCultures("en-US").AddSupportedUICultures("en-US"));
var app=builder.Build();
if(!app.Environment.IsDevelopment()){app.UseExceptionHandler("/Error");app.UseHsts();}
app.UseHttpsRedirection();
app.UseRequestLocalization();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();
if(!args.Contains("--skip-db-init")) {
 await using var scope=app.Services.CreateAsyncScope();
 var db=scope.ServiceProvider.GetRequiredService<LibraryContext>();
 await db.Database.MigrateAsync();
 await SeedData.InitializeAsync(db);
}
await app.RunAsync();
