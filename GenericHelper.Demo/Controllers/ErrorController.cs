using GenericHelper.Core.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GenericHelper.Demo.Controllers
{
    
    [ApiController]
   // [Route("api/[controller]")]
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }

}
