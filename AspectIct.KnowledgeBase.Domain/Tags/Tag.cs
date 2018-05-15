using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspectIct.KnowledgeBase.Domain
{
    [Table("Tags")]
    public class Tag
    {
        public Tag()
        {
             Snippets = new List<Snippet>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Snippet> Snippets { get; set; }
    }
}