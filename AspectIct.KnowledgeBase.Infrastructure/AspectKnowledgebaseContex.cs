using AspectIct.KnowledgeBase.Domain;
using System.Data.Entity;

namespace AspectIct.KnowledgeBase.Infrastructure
{
    public class AspectKnowledgebaseContext : DbContext
    {
        public AspectKnowledgebaseContext() : base("name=AspectKnowledgebase")
        {
        }

        public virtual DbSet<Snippet> Snippets { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
