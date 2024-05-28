using System.ComponentModel.DataAnnotations;

namespace Simulacro1.Models{

    public class Author {
        public int Id { get; set; }

        [Required]
        [StringLength(125)]
        public string? Name { get; set; }

        [Required]
        [StringLength(45)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(125)]
        public string? Email { get; set; }

        [Required]
        [StringLength(1255)]
        public string? Nationality { get; set; }
        public bool IsDeleted { get; set; }

    }
}