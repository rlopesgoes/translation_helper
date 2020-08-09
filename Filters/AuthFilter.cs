using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMLEditor;
using XMLEditor.Models;

namespace XMLEditor.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObjectFromJson<User>("user") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Users", action = "Index" }));
            }
        }
        public AuthFilter()
        {
        }


    }
}
