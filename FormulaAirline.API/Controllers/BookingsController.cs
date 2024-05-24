using FormulaAirline.API.Models;
using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ILogger<BookingsController> _logger;
        private readonly IMessageProducer _messageProducer;

        //in-memory db just for simulation
        public static readonly List<Booking> _bookings = new List<Booking>();

        public BookingsController(ILogger<BookingsController> logger, IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost("CreateBooking")]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateBooking(Booking booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _bookings.Add(booking);

            _messageProducer.SendingMessage<Booking>(booking);

            return CreatedAtAction(nameof(GetBookingDetails), new { id = booking.Id }, booking);
        
        }

        [HttpGet("GetBookingDetails")]
        public IActionResult GetBookingDetails(int id)
        {
            return Ok(); //TODO
        }
        
    }
}
