using System.Collections.Generic;
using AspectIct.KnowledgeBase.Infrastructure.Tags;

namespace AspectIct.KnowledgeBase.Infrastructure.Snippets
{
    public class SnippetViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}