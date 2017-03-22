using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace SkiDay.WebApp.Controllers
{
    public class ResortsController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var text = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/resort-names.json"));
            return new HttpResponseMessage
            {
                Content = new StringContent(text, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}