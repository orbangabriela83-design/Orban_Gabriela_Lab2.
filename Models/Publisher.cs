using System.ComponentModel.DataAnnotations;
namespace Orban_Gabriela_Lab2.Models;
public class Publisher {
 public int ID {get;set;}
 [Required, StringLength(100)] public string PublisherName {get;set;} = "";
 public ICollection<Book> Books {get;set;} = new List<Book>();
}