using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using ContactManagement.API.ExLogger;
using ContactManagement.API.InjectModules;
using ContactManagement.Services;
using PartialResponse.Net.Http.Formatting;

namespace ContactManagement.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Resolving the dependencies
            var container = RegisterModules.GetUnityContainer();
            config.DependencyResolver = new UnityResolver(container);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Output to be returned in JSON format always
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //Register exception handler 
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            config.Formatters.Clear();
            config.Formatters.Add(new PartialJsonMediaTypeFormatter() { IgnoreCase = true });

            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
    }
}
