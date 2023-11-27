using Hotel_Domain.Models;
using Hotel_Domain.ViewModels;
using Hotel_Repository.Services.Custom_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly Reservation_Service _reservationService;

        public ReservationController(Reservation_Service reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsWithDetailsAsync();
            return Ok(reservations);
        }

        [HttpGet("{reservationId}")]
        public async Task<IActionResult> GetReservationById(int reservationId)
        {
            var reservation = await _reservationService.GetReservationWithDetailsByIdAsync(reservationId);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }


        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] ReservationViewModel reservationViewModel)
        {
            // Convert ReservationViewModel to Reservation entity
            var reservation = new Reservation
            {
                // Map properties accordingly
                ReservationId=reservationViewModel.ReservationId,
                GuestId = reservationViewModel.GuestId,
                RoomNumber = reservationViewModel.RoomNumber,
                CheckInDate = reservationViewModel.CheckInDate,
                CheckOutDate = reservationViewModel.CheckOutDate,
                ReservationDate = reservationViewModel.ReservationDate,
                // Map other properties as needed
            };

            await _reservationService.AddReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservationById), new { reservationId = reservation.ReservationId }, reservation);
        }

        [HttpPut("{reservationId}")]
        public async Task<IActionResult> UpdateReservation(int reservationId, [FromBody] ReservationViewModel reservationViewModel)
        {
            var existingReservation = await _reservationService.GetReservationByIdAsync(reservationId);

            if (existingReservation == null)
            {
                return NotFound();
            }

            // Map properties accordingly
            existingReservation.ReservationId = reservationViewModel.ReservationId;
            existingReservation.GuestId = reservationViewModel.GuestId;
            existingReservation.RoomNumber = reservationViewModel.RoomNumber;
            existingReservation.CheckInDate = reservationViewModel.CheckInDate;
            existingReservation.CheckOutDate = reservationViewModel.CheckOutDate;
            existingReservation.ReservationDate = reservationViewModel.ReservationDate;
     
            // Map other properties as needed

            await _reservationService.UpdateReservationAsync(existingReservation);
            return NoContent();
        }

        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            await _reservationService.DeleteReservationAsync(reservationId);
            return NoContent();
        }
    }
}
