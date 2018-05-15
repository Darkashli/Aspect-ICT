using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using AspectIct.KnowledgeBase.Infrastructure;
using AspectIct.KnowledgeBase.Infrastructure.Tags;
using Microsoft.Data.OData;
using AspectIct.KnowledgeBase.Domain;

namespace AspectIct.KnowledgeBase.Controllers
{

    public class TagsController : ODataController
    {

        // GET: odata/Tags/
        [EnableQuery]
        public IQueryable<TagViewModel> GetTags()
        {
            using (var context = new AspectKnowledgebaseContext())
            {
                var tags = context.Tags.Select(t => new TagViewModel
                {
                    Name = t.Name,
                    Id = t.Id
                });
                return tags.ToList().AsQueryable();
            }
        }

        // GET: odata/Tags(5)
        public IHttpActionResult GetTag([FromODataUri] int key)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Tags(5)
        public IHttpActionResult Put([FromODataUri] int key)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Tags
        public IHttpActionResult Post(Tag tag)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Tags(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Tag> delta)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Tags(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
