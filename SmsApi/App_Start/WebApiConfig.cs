using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace SmsApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi.DOT.Requests.GetStatistics",
                routeTemplate: "api/{controller}/{action}/{dateFrom}/{dateTo}/{mccList}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi.DOT.Requests.SendSms",
                routeTemplate: "api/{controller}/{action}/{from}/{to}/{text}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi.DOT.Requests.params",
                routeTemplate: "api/{controller}/{action}/{dateTimeFrom}/{dateTimeTo}/{skip}/{take}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi.DOT.Requests",
                routeTemplate: "api/{controller}/{action}"                
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
