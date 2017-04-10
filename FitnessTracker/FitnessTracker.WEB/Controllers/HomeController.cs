using System.Web.Mvc;

namespace FitnessTracker.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}