using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using AspectIct.KnowledgeBase.Infrastructure;
using AspectIct.KnowledgeBase.Infrastructure.Snippets;
using AspectIct.KnowledgeBase.Infrastructure.Tags;
using Microsoft.Data.OData;
using AspectIct.KnowledgeBase.Domain;

namespace AspectIct.KnowledgeBase.Controllers
{

    public class SnippetsController : ODataController
    {

        // GET: odata/Snippets
        [EnableQuery]
        public IQueryable<SnippetViewModel> GetSnippets()
        {
            using (var context = new AspectKnowledgebaseContext())
            {
                var snippets = context.Snippets.Select(s => new SnippetViewModel
                {
                    Code = s.Code,
                    Id = s.Id,
                    Subject = s.Subject,
                    Tags = s.Tags.Select(t => new TagViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    })

                });
                return snippets.ToList().AsQueryable();
            }
        }

        // GET: odata/Snippets(5)
        public IHttpActionResult GetSnippet([FromODataUri] int key, ODataQueryOptions<SnippetViewModel> queryOptions)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Snippets(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<SnippetViewModel> delta)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Snippets
        public IHttpActionResult Post(SnippetViewModel snippet)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Snippets(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<SnippetViewModel> delta)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Snippets(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
