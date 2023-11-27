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
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{roomNumber}")]
        public async Task<IActionResult> GetRoomByNumber(int roomNumber)
        {
            var room = await _roomService.GetRoomByIdAsync(roomNumber);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] RoomViewModel roomViewModel)
        {
            // Convert RoomViewModel to Room entity
            var room = new Room
            {
                // Map properties accordingly
                RoomNumber = roomViewModel.RoomNumber,
                RoomType = roomViewModel.RoomType,
                RatePerNight = roomViewModel.RatePerNight,
                Availability = roomViewModel.Availability,
                // Map other properties as needed
            };

            await _roomService.AddRoomAsync(room);
            return CreatedAtAction(nameof(GetRoomByNumber), new { roomNumber = room.RoomNumber }, room);
        }

        [HttpPut("{roomNumber}")]
        public async Task<IActionResult> UpdateRoom(int roomNumber, [FromBody] RoomViewModel roomViewModel)
        {
            var existingRoom = await _roomService.GetRoomByIdAsync(roomNumber);

            if (existingRoom == null)
            {
                return NotFound();
            }

            // Map properties accordingly
            existingRoom.RoomType = roomViewModel.RoomType;
            existingRoom.RatePerNight = roomViewModel.RatePerNight;
            existingRoom.Availability = roomViewModel.Availability;
            // Map other properties as needed

            await _roomService.UpdateRoomAsync(existingRoom);
            return NoContent();
        }

        [HttpDelete("{roomNumber}")]
        public async Task<IActionResult> DeleteRoom(int roomNumber)
        {
            await _roomService.DeleteRoomAsync(roomNumber);
            return NoContent();
        }
    }
}
