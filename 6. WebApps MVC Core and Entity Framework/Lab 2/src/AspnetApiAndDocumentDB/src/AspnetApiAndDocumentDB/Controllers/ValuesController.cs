using Microsoft.AspNet.Mvc;

namespace AspnetApiAndDocumentDB.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Hello ASPNET Core 1";
        }
    }
}
