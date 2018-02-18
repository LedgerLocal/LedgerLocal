//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web.Mvc;
//using System.Web.Mvc.Html;

//namespace Common.Web.Mvc
//{
//    public static class NavHtmlHelpers
//    {
//        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
//        {
//            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
//            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

//            var builder = new TagBuilder("li")
//            {
//                InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToHtmlString()
//            };

//            if (controllerName == currentController && actionName == currentAction)
//            {
//                builder.AddCssClass("active");
//            }

//            return new MvcHtmlString(builder.ToString());
//        }
//    }
//}
