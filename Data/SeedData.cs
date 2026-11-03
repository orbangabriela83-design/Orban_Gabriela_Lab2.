using Microsoft.EntityFrameworkCore;
using Orban_Gabriela_Lab2.Models;
namespace Orban_Gabriela_Lab2.Data;
public static class SeedData {
 public static async Task InitializeAsync(LibraryContext db) {
 if(await db.Book.AnyAsync() || await db.Author.AnyAsync() || await db.Publisher.AnyAsync()) return;
 var publishers=new [] {new Publisher {PublisherName="Humanitas"},new Publisher {PublisherName="Nemira"},new Publisher {PublisherName="Arthur"}};
 var authors=new [] {new Author {FirstName="Mircea",LastName="Eliade"},new Author {FirstName="Mihail",LastName="Sadoveanu"},new Author {FirstName="Jules",LastName="Verne"}};
 var books=new [] {new Book {Title="Maitreyi",Author=authors[0],Publisher=publishers[0],Price=35.50m,PublishingDate=new DateTime(1933,1,1)},new Book {Title="Baltagul",Author=authors[1],Publisher=publishers[1],Price=29.90m,PublishingDate=new DateTime(1930,1,1)}};
 db.Publisher.AddRange(publishers);db.Author.AddRange(authors);db.Book.AddRange(books);
 await db.SaveChangesAsync();
 }
}