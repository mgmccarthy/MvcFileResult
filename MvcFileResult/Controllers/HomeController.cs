using System.Collections.Generic;
using System.Web.Mvc;
using MvcFileResult.FileResultClasses;
using MvcFileResult.Models;

namespace MvcFileResult.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = new List<Model>
            {
                new Model {Prop1 = "Prop1Value", Prop2 = 1, Prop3 = true},
                new Model {Prop1 = "Prop2Value", Prop2 = 2, Prop3 = false}
            };

            return new CsvResult<Model>(data){ FileDownloadName = "comma-delimited.csv" };
            //return new TabDelimitedResult<Model>(data) { FileDownloadName = "tab-delimited.txt" };
            //return new PipeDelimitedResult<Model>(data) { FileDownloadName = "pipe-delimited.txt" };
        }
    }
}