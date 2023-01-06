using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Article
    {
        [Column("ArticleId")]
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "State is a required field.")]
        public string State { get; set; }
        [ForeignKey(nameof(Museum))]
        public Guid AssociatedMuseumId { get; set; }
        public Museum Museum { get; set; }
    }
}
