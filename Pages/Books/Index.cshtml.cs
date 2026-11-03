using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Data;
using Orban_Gabriela_Lab2.Models;
namespace Orban_Gabriela_Lab2.Pages.Books;
public class IndexModel(LibraryContext context):PageModel {
 private readonly LibraryContext _context=context;
 public List<Book> Items {get;set;}=new();
 public int? SelectedID {get;set;}
public SelectList Authors {get;set;} = default!;
 public int? AuthorID {get;set;}
 public string CurrentFilter {get;set;}="";
 public string SortOrder {get;set;}="";
 public string TitleSort {get;set;}="";
 public string AuthorSort {get;set;}="";
 public Book? SelectedBook {get;set;}
 public async Task OnGetAsync(int? id,int? authorID,string? searchString,string? sortOrder){
SelectedID=id;
AuthorID=authorID; CurrentFilter=searchString??"";SortOrder=sortOrder??"";
 Authors=new SelectList(await _context.Author.OrderBy(a=>a.LastName).ToListAsync(),"ID","FullName",authorID);
 var query=_context.Book.Include(x=>x.Author).Include(x=>x.Publisher).AsNoTracking();
 if(authorID.HasValue)query=query.Where(b=>b.AuthorID==authorID);
query=query.OrderBy(b=>b.Title);
Items=await query.ToListAsync();
 }
}