using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simulacro1.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string? Title { get; set; }


        [Required]
        [StringLength(45)]
        public int Pages { get; set; }


        [Required]
        [StringLength(45)]
        public string? Language { get; set; }


        [Required]
        [StringLength(45)]
        public DateTime PublicationDate { get; set; }


        [Required]
        [StringLength(45)]
        public string? Description { get; set; }
        public int? IdAuthor { get; set; }
        public virtual Author? Authors { get; set; }

        public bool IsDeleted { get; set; }


    }
}