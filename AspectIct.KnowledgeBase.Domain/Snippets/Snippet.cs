using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace AspectIct.KnowledgeBase.Domain
{


    [Table("Snippets")]
    public class Snippet
    {
        public Snippet()
        {
            Tags = new List<Tag>();
        }

        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        public DateTime TimeAdded { get; set; }

        public DateTime TimeEdited { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}