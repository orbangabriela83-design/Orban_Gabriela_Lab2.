using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Orban_Gabriela_Lab2.Models;
public class Author {
 public int ID {get;set;}
 [Required, StringLength(80)] public string FirstName {get;set;} = "";
 [Required, StringLength(80)] public string LastName {get;set;} = "";
 [NotMapped, Display(Name="Full Name")] public string FullName => FirstName+" "+LastName;
 public ICollection<Book> Books {get;set;} = new List<Book>();
}