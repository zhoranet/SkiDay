using System.Text;
using System.Web.Mvc;
using SkiDay.WebApp.Infrastructure;

namespace SkiDay.WebApp.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding,
            JsonRequestBehavior behavior)
        {
            return new JsonDotNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}