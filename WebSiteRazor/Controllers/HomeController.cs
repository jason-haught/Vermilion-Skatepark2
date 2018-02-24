using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using VermillionSkatePark.Models;

namespace VermillionSkatePark.Controllers
{
    [SetAppTitles]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }

    public class SetAppTitlesAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var result = filterContext.Result as ViewResult;
            if (result != null)
            {
                result.ViewData["ApplicationTitle"] = AppSettings.Instance.ApplicationTitle;
                result.ViewData["ApplicationFooter"] = AppSettings.Instance.ApplicationFooter;
            }
        }
    }
}