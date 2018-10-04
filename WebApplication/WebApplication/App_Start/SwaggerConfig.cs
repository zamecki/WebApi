using System.Web.Http;
using WebActivatorEx;
using WebApplication;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Linq;
using System.Collections.Generic;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApplication
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {

                        c.SingleApiVersion("v1", "WebApplication");

                        c.OAuth2("oauth2")
                          .Description("OAuth2 Implicit Grant")
                          .Flow("password")
                          //.AuthorizationUrl("https://localhost:50774/core/connect/authorize")
                          .TokenUrl("https://localhost:50774/token")
                            .Scopes(scopes =>
                            {
                                scopes.Add("sampleapi", "try out the sample api");
                            })
                          ;

                        c.OperationFilter<AssignOAuth2SecurityRequirements>();

                    })
                .EnableSwaggerUi(c =>
                    {
                        c.EnableApiKeySupport("apiKey", "header");
                        c.EnableOAuth2Support("sampleapi", "samplerealm", "Swagger UI");

                    });
        }
    }
    public class AssignOAuth2SecurityRequirements : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var actFilters = apiDescription.ActionDescriptor.GetFilterPipeline();
            var allowsAnonymous = actFilters.Select(f => f.Instance).OfType<OverrideAuthorizationAttribute>().Any();
            if (allowsAnonymous)
                return; // must be an anonymous method


            //var scopes = apiDescription.ActionDescriptor.GetFilterPipeline()
            //    .Select(filterInfo => filterInfo.Instance)
            //    .OfType<AllowAnonymousAttribute>()
            //    .SelectMany(attr => attr.Roles.Split(','))
            //    .Distinct();

            if (operation.security == null)
                operation.security = new List<IDictionary<string, IEnumerable<string>>>();

            var oAuthRequirements = new Dictionary<string, IEnumerable<string>>
            {
                {"oauth2", new List<string> {"sampleapi"}}
            };

            operation.security.Add(oAuthRequirements);
        }    
    }
}