using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProject.Controllers
{
    public class AgeCalculatorController : Controller
    {
        // GET: AgeCalculator
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUsersAge(string date)
        {
            DateTime startTime = DateTime.Parse(date, CultureInfo.CreateSpecificCulture("en-US"));
            DateTime endTime = DateTime.Today;
            TimeSpan timespan = endTime.Subtract(startTime);
            DateTime Age = DateTime.MinValue.AddDays(timespan.Days);
            var calculatedAge = string.Format(" {0} Years {1} Month {2} Days", Age.Year - 1, Age.Month - 1, Age.Day - 1);

            var json = Json(new
            {
                calculatedAge
            });
            return json;
        }
    }
}