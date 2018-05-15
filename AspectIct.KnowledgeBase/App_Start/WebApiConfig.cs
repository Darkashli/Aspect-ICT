using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using AspectIct.KnowledgeBase.Controllers;
using AspectIct.KnowledgeBase.Infrastructure;
using AspectIct.KnowledgeBase.Infrastructure.Snippets;
using AspectIct.KnowledgeBase.Infrastructure.Tags;

namespace AspectIct.KnowledgeBase
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
           // config.MapHttpAttributeRoutes();
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(1000);
            builder.EntitySet<SnippetViewModel>("Snippets");
            builder.EntitySet<TagViewModel>("Tags");
            // builder.EnableLowerCamelCase();
            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            
           }
    }
}
