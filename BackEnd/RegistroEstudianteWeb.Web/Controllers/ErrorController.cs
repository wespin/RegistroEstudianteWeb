using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroEstudianteWeb.Api.Errors;

namespace RegistroEstudianteWeb.Api.Controllers
{
    [ApiController]
    [Route("errores/{codigo}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        public IActionResult Error(int codigo)
        {
            return new ObjectResult(new ApiErrorResponse(codigo));
        }

    }
}
