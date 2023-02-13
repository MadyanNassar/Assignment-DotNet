using FirstApp.Handler;
using FirstApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("fizzbuzz")]
    [ApiController]
    public class ResultController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Result> Get() {
            var resultObj = new ResultHandler();
            var result = resultObj.GetResult();
            return result;
        }

    }
}
