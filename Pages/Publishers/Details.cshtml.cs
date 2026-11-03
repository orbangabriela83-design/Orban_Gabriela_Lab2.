using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Data;
using Orban_Gabriela_Lab2.Models;
namespace Orban_Gabriela_Lab2.Pages.Publishers;
public class DetailsModel(LibraryContext context):PageModel {
 private readonly LibraryContext _context=context;
 [BindProperty] public Publisher Item {get;set;}=new();
 public async Task<IActionResult> OnGetAsync(int? id){
var found=await _context.Publisher.FirstOrDefaultAsync(x=>x.ID==id);if(found==null)return NotFound();Item=found;
return Page();}

}