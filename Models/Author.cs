using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [Length(5, 100)]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; } // Relasjon til mange bøker

    }
}