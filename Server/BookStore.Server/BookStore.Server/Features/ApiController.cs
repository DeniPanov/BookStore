using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
