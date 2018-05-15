using AspectIct.KnowledgeBase.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Http;
using AspectIct.KnowledgeBase.Infrastructure.Snippets;
using AspectIct.KnowledgeBase.Infrastructure.Tags;
using AspectIct.KnowledgeBase.Domain;

namespace AspectIct.KnowledgeBase.Controllers
{
    public class SnippetController : ApiController
    {
        public SnippetController()
        {

        }

        /// <summary>
        /// Here where you get all of your Snippets 
        /// </summary>
        /// <returns></returns>
        // GET: api/Snippet
        public IEnumerable<SnippetViewModel> Get()
        {
            using (var context = new AspectKnowledgebaseContext())
            {
                var snippet = context.Snippets.Select(s => new SnippetViewModel
                {
                    Code = s.Code,
                    Id = s.Id,
                    Subject = s.Subject,
                    Tags = s.Tags.Select(t => new TagViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                }).ToList();
                return snippet;
            }
        }

        // POST: api/Snippet/SearchSnippets

        [HttpPost]
        [Route("api/Snippet/SearchSnippets")]

        public IEnumerable<SnippetViewModel> SearchSnippets(string search)
        {
            using (var context = new AspectKnowledgebaseContext())
            {
                return context.Snippets
                    .Where(s => s.Subject.Contains(search) || s.Tags.Any(tag => tag.Name.Contains(search)))
                    .Select(s => new SnippetViewModel
                    {
                        Code = s.Code,
                        Id = s.Id,
                        Subject = s.Subject,
                        Tags = s.Tags.Select(t => new TagViewModel
                        {
                            Id = t.Id,
                            Name = t.Name
                        })
                    }).ToList();
            }
        }

        // GET: api/Snippets/5
        public SnippetViewModel Get(int id)
        {
            using (var context = new AspectKnowledgebaseContext())
            {
                var snippet = context.Snippets.Where(s => s.Id == id).Select(s => new SnippetViewModel
                {
                    Code = s.Code,
                    Id = s.Id,
                    Subject = s.Subject,
                    Tags = s.Tags.Select(t => new TagViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                }).FirstOrDefault();
                return snippet;
            }
        }

        // POST: api/Default
        [HttpPost]
        public int Post(NewSnippetViewModel snippetViewModel)
        {
            using (var context = new AspectKnowledgebaseContext())
            {
                var snippet = new Snippet()
                {
                    Code = snippetViewModel.Code,
                    Subject = snippetViewModel.Subject
                };


                foreach (var tag in snippetViewModel.Tags)
                {

                    var foundTag = context.Tags.FirstOrDefault(t => t.Id == tag.Id);
                    if (foundTag != null)
                    {
                        snippet.Tags.Add(foundTag);
                    }
                    else
                    {
                        var newTag = new Tag() { Name = tag.Name };
                        context.Tags.Add(newTag);
                        snippet.Tags.Add(newTag);
                    }
                }


                context.Snippets.Add(snippet);
                context.SaveChanges();

                return snippet.Id;
            }
        }

        // PUT: api/Default/5
        public IHttpActionResult Put(SnippetViewModel snippet)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var context = new AspectKnowledgebaseContext())
            {
                // Linq
                var existingSnippet = context.Snippets.Where(s => s.Id == snippet.Id)
                                                    .FirstOrDefault<Snippet>();
                if (existingSnippet != null)
                {
                    existingSnippet.Code = snippet.Code;
                    existingSnippet.Subject = snippet.Subject;
                    //existingSnippet.Tags = snippet;

                }
                else
                {
                    return NotFound();
                }

                var newTags = snippet.Tags;

                var existingTags = existingSnippet.Tags.ToList();


                foreach (var tag in existingTags)
                {
                    var doesTagAlreadyExist = newTags.Any(o => o.Id == tag.Id);
                    if (!doesTagAlreadyExist)
                    {
                        existingSnippet.Tags.Remove(tag);
                    }
                }

                foreach (var tag in newTags)
                {
                    var doesTagAlreadyExist = existingTags.Any(o => o.Id == tag.Id);
                    if (!doesTagAlreadyExist)
                    {
                        var foundTag = context.Tags.FirstOrDefault(t => t.Id == tag.Id);
                        if (foundTag != null)
                        {
                            existingSnippet.Tags.Add(foundTag);
                        }
                        else
                        {
                            var newTag = new Tag() { Name = tag.Name };
                            context.Tags.Add(newTag);
                            existingSnippet.Tags.Add(newTag);
                        }
                    }
                }
                context.Entry(existingSnippet).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return Ok();
        }

        // DELETE: api/Default/5
        public IHttpActionResult Delete(int id, NewSnippetViewModel snippetViewModel)
        {
            using (var context = new AspectKnowledgebaseContext())
            {

                var snippet = context.Snippets
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                context.Entry(snippet).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

            }
            return Ok();
        }
    }
}