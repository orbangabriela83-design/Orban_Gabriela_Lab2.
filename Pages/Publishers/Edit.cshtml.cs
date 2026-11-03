using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Data;
using Orban_Gabriela_Lab2.Models;
namespace Orban_Gabriela_Lab2.Pages.Publishers;
public class EditModel(LibraryContext context):PageModel {
 private readonly LibraryContext _context=context;
 [BindProperty] public Publisher Item {get;set;}=new();
 public async Task<IActionResult> OnGetAsync(int? id){
var found=await _context.Publisher.FirstOrDefaultAsync(x=>x.ID==id);if(found==null)return NotFound();Item=found;
return Page();}
public async Task<IActionResult> OnPostAsync(int? id) {
var existing=await _context.Publisher.FirstOrDefaultAsync(x=>x.ID==id);if(existing==null)return NotFound();
if(Item.ID!=id)return BadRequest();
if(!ModelState.IsValid){return Page();}
existing.PublisherName=Item.PublisherName;
try {await _context.SaveChangesAsync();} catch(DbUpdateException){ModelState.AddModelError("","Unable to save. Check that email is unique and related records still exist.");return Page();}
return RedirectToPage("./Index");
}
}