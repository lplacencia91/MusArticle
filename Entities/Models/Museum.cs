using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    
    public class Museum
    {
        [Column("MuseumId")]
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Theme is a required field.")]
        public string Theme { get; set; }

        public ICollection<Article> Articles { get; set; }
    }

}
