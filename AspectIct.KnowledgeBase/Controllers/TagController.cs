using AspectIct.KnowledgeBase.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AspectIct.KnowledgeBase.Infrastructure.Tags;
using AspectIct.KnowledgeBase.Domain;

namespace AspectIct.KnowledgeBase.Controllers
{
    public class TagController : ApiController
    {
        // GET: api/Tag
        public IEnumerable<TagViewModel> Get()
        {
            using (var context = new AspectKnowledgebaseContext())
            {
                return context.Tags.Select(s => new TagViewModel
                {
                    Name = s.Name,
                    Id = s.Id
                }).ToList();
            }
        }

        // GET: api/Snippets/5
        public Tag Get(int id)
        {
            using (var context = new AspectKnowledgebaseContext())
            {
                return context.Tags.FirstOrDefault(o => o.Id == id);
            }
        }
    }

}
