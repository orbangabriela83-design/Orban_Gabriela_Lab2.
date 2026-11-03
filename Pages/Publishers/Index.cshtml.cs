using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Data;
using Orban_Gabriela_Lab2.Models;
namespace Orban_Gabriela_Lab2.Pages.Publishers;
public class IndexModel(LibraryContext context):PageModel {
 private readonly LibraryContext _context=context;
 public List<Publisher> Items {get;set;}=new();
 public int? SelectedID {get;set;}
 public async Task OnGetAsync(int? id,int? authorID,string? searchString,string? sortOrder){
SelectedID=id;
Items=await _context.Publisher.AsNoTracking().ToListAsync();
 }
}