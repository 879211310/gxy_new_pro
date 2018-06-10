using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyProject.Controllers.InfoTest
{
    public class InfoTestController:BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
