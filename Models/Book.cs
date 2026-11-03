using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Orban_Gabriela_Lab2.Models;
public class Book {
 public int ID {get;set;}
 [Required, StringLength(200), Display(Name="Book Title")] public string Title {get;set;} = "";
 [Column(TypeName="decimal(6, 2)"), Range(0,9999.99)] public decimal Price {get;set;}
 [DataType(DataType.Date)] public DateTime PublishingDate {get;set;} = DateTime.Today;
 [Display(Name="Author")] public int? AuthorID {get;set;}
 public Author? Author {get;set;}
 [Display(Name="Publisher")] public int? PublisherID {get;set;}
 public Publisher? Publisher {get;set;}
}