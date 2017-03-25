using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SkiDay.WebApp.Models;
using SkiDay.WebApp.Services;

namespace SkiDay.WebApp.Controllers
{
    [System.Web.Mvc.Authorize]
    [System.Web.Mvc.RoutePrefix("home")]
    public class HomeController : Controller
    {
        private readonly SkiDayContext _context;
        private readonly ISkiResortsService _skiService;

        public HomeController(SkiDayContext context, ISkiResortsService skiService)
        {
            _context = context;
            _skiService = skiService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("resorts/{name}")]
        public JsonResult Resorts(string name = null)
        {
            if (!_context.SkiResorts.Any())
            {
                _skiService.ImportSkiResorts();
            }

            var resorts = _skiService.GetAllResortsByName(name);
           
            return Json(resorts.Select(x=>x.Name), JsonRequestBehavior.AllowGet) ;
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("skidays")]
        public JsonResult SkiDays()
        {
            var days = _skiService.GetAllDays(User.Identity.GetUserId());
           
            return Json(days, JsonRequestBehavior.AllowGet) ;
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("skidays")]
        public JsonResult SkiDays(MySkiDay skiDay)
        {
            skiDay.UserId = User.Identity.GetUserId();
            _skiService.AddSkiDay(skiDay);
           
            return new JsonResult();
        }
    }
}