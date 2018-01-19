using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VermillionSkate2.Models;

namespace VermillionSkate2.Controllers
{
    [SetAppTitles]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = AppSettings.Instance.HomeInfo.Title; 
            ViewData["Message"] = AppSettings.Instance.HomeInfo.Message;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = AppSettings.Instance.AboutInfo.Title;
            ViewData["Message"] = AppSettings.Instance.AboutInfo.Message;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = AppSettings.Instance.ContactInfo.Title;
            ViewData["Message"] = AppSettings.Instance.ContactInfo.Message; 

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
