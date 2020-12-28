using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yo.Models;
using Yo.WebApi.Models;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//using Yo.Api.Client.Models;

namespace Yo.WebApi.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
