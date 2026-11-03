using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Data;
using Orban_Gabriela_Lab2.Models;
namespace Orban_Gabriela_Lab2.Pages.Books;
public class DeleteModel(LibraryContext context):PageModel {
 private readonly LibraryContext _context=context;
 [BindProperty] public Book Item {get;set;}=new();
public SelectList AuthorIDList {get;set;}=default!; public SelectList PublisherIDList {get;set;}=default!;
 public async Task<IActionResult> OnGetAsync(int? id){
var found=await _context.Book.Include(x=>x.Author).Include(x=>x.Publisher).FirstOrDefaultAsync(x=>x.ID==id);if(found==null)return NotFound();Item=found;
return Page();}
public async Task<IActionResult> OnPostAsync(int? id){
var existing=await _context.Book.Include(x=>x.Author).Include(x=>x.Publisher).FirstOrDefaultAsync(x=>x.ID==id);if(existing==null)return NotFound();
_context.Book.Remove(existing);
try{await _context.SaveChangesAsync();}catch(DbUpdateException){Item=existing;ModelState.AddModelError("","This record is used by an existing borrowing. Delete that borrowing first.");return Page();}
return RedirectToPage("./Index");}

}