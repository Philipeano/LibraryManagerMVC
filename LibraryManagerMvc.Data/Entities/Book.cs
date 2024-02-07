using LibraryManagerMvc.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagerMvc.Data.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Book title must have 3 or more characters.")]
        [MaxLength(50, ErrorMessage = "Book title must not exceed 50 characters.")]
        public string Title { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Author's name must have 3 or more characters.")]
        [MaxLength(50, ErrorMessage = "Author's name must not exceed 50 characters.")]
        public string Author { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [Range(1900, 2024)]
        public int YearPublished { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
