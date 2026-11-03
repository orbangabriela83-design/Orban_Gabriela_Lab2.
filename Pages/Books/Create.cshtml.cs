using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Data;
using Orban_Gabriela_Lab2.Models;
namespace Orban_Gabriela_Lab2.Pages.Books;
public class CreateModel(LibraryContext context):PageModel {
 private readonly LibraryContext _context=context;
 [BindProperty] public Book Item {get;set;}=new();
public SelectList AuthorIDList {get;set;}=default!; public SelectList PublisherIDList {get;set;}=default!;
 public async Task<IActionResult> OnGetAsync(int? id){
Item=new();
AuthorIDList=new SelectList(await _context.Author.OrderBy(a=>a.LastName).ToListAsync(),"ID","FullName",Item.AuthorID); PublisherIDList=new SelectList(await _context.Publisher.OrderBy(p=>p.PublisherName).ToListAsync(),"ID","PublisherName",Item.PublisherID);
return Page();}
public async Task<IActionResult> OnPostAsync(int? id) {
if(Item.AuthorID.HasValue&&!await _context.Author.AnyAsync(x=>x.ID==Item.AuthorID))ModelState.AddModelError("Item.AuthorID","Select an existing author.");
if(Item.PublisherID.HasValue&&!await _context.Publisher.AnyAsync(x=>x.ID==Item.PublisherID))ModelState.AddModelError("Item.PublisherID","Select an existing publisher.");
if(!ModelState.IsValid){AuthorIDList=new SelectList(await _context.Author.OrderBy(a=>a.LastName).ToListAsync(),"ID","FullName",Item.AuthorID); PublisherIDList=new SelectList(await _context.Publisher.OrderBy(p=>p.PublisherName).ToListAsync(),"ID","PublisherName",Item.PublisherID);
return Page();}
Item.ID=0;_context.Book.Add(Item);
try {await _context.SaveChangesAsync();} catch(DbUpdateException){ModelState.AddModelError("","Unable to save. Check that email is unique and related records still exist.");AuthorIDList=new SelectList(await _context.Author.OrderBy(a=>a.LastName).ToListAsync(),"ID","FullName",Item.AuthorID); PublisherIDList=new SelectList(await _context.Publisher.OrderBy(p=>p.PublisherName).ToListAsync(),"ID","PublisherName",Item.PublisherID);
return Page();}
return RedirectToPage("./Index");
}
}