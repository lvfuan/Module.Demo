using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestDemo.Controllers
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerType = GetControllerType(requestContext, controllerName);
            if (controllerType == null)
            {
                var dynamicRoute = string.Join("/", requestContext.RouteData.Values.Values);
                controllerName = "Constom";
                controllerType = GetControllerType(requestContext, controllerName);
                requestContext.RouteData.Values["Controller"] = controllerName;
                requestContext.RouteData.Values["action"] = "Index";
                requestContext.RouteData.Values["dyName"] = dynamicRoute;
            }
            IController controller = GetControllerInstance(requestContext, controllerType);
            return controller;
        }
    }
}