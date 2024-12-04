using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tittel er påkrevd")]
        [StringLength(100, ErrorMessage = "Tittelen kan ikke være lengre enn 100 tegn")]
        public string Title { get; set; }

        [Range(1910, 2024, ErrorMessage = "Året må være mellom 1910 og 2024")]
        public int Year { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; } // Fremmednøkkel
        [ValidateNever]
        public Author Author { get; set; }
        [ValidateNever]
        public ICollection<Loan> Loans { get; set; }
    }
}