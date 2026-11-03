using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Data;
using Orban_Gabriela_Lab2.Models;
namespace Orban_Gabriela_Lab2.Pages.Authors;
public class CreateModel(LibraryContext context):PageModel {
 private readonly LibraryContext _context=context;
 [BindProperty] public Author Item {get;set;}=new();
 public async Task<IActionResult> OnGetAsync(int? id){
Item=new();
return Page();}
public async Task<IActionResult> OnPostAsync(int? id) {
if(!ModelState.IsValid){return Page();}
Item.ID=0;_context.Author.Add(Item);
try {await _context.SaveChangesAsync();} catch(DbUpdateException){ModelState.AddModelError("","Unable to save. Check that email is unique and related records still exist.");return Page();}
return RedirectToPage("./Index");
}
}