using Microsoft.AspNetCore.Mvc;

namespace Payment.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
