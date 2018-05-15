using System.Collections.Generic;
using System.Linq;
using AspectIct.KnowledgeBase.Infrastructure.Tags;

namespace AspectIct.KnowledgeBase.Infrastructure.Snippets
{
    public class NewSnippetViewModel
    {
        public NewSnippetViewModel()
        {
            Tags = Enumerable.Empty<TagViewModel>();
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}