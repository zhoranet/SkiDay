using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SkiDay.WebApp.Models;
using SkiDay.WebApp.Services;

namespace SkiDay.WebApp.Controllers
{
    [Authorize]
    [RoutePrefix("home")]
    public class HomeController : ControllerBase
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

        [HttpGet]
        [Route("resorts/{name}")]
        public JsonResult GetResorts(string name = null)
        {
            if (!_context.SkiResorts.Any())
                _skiService.ImportSkiResorts();

            var resorts = _skiService.GetAllResortsByName(name);

            return Json(resorts.Select(x => x.Name), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("skidays")]
        public JsonResult GetSkiDays()
        {
            var days = _skiService.GetAllDays(User.Identity.GetUserId());

            return Json(days, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("skidays")]
        public JsonResult AddNewSkiDay(MySkiDay skiDay)
        {
            skiDay.UserId = User.Identity.GetUserId();
            _skiService.AddSkiDay(skiDay);

            return new JsonResult();
        }
    }
}