using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ILogger<BookingsController> _logger;

        public BookingsController(ILogger<BookingsController> logger)
        {
            _logger = logger;
        }
    }
}
