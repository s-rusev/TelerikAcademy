using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Students.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "StudentsApi",
                routeTemplate: "api/students/{studentId}/marks",
                defaults: new
                {
                    controller = "students",
                    action = "marks"
                });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
