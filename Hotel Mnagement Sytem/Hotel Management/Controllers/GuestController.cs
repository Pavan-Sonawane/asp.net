using Hotel_Domain.Models;
using Hotel_Repository.Services.Custom_Services;
using Hotel_Domain.ViewModels; // Import the GuestViewModel namespace
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly GuestService _guestService;

        public GuestController(GuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await _guestService.GetAllGuestsAsync();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> AddGuest([FromBody] GuestViewModel guestViewModel) // Use GuestViewModel
        {
            await _guestService.AddGuestAsync(guestViewModel); // Pass GuestViewModel to service
            return CreatedAtAction(nameof(GetGuestById), new { id = guestViewModel.GuestId }, guestViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] GuestViewModel guestViewModel) // Use GuestViewModel
        {
            if (id != guestViewModel.GuestId)
            {
                return BadRequest();
            }

            await _guestService.UpdateGuestAsync(guestViewModel); // Pass GuestViewModel to service
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _guestService.DeleteGuestAsync(id);
            return NoContent();
        }
    }
}
