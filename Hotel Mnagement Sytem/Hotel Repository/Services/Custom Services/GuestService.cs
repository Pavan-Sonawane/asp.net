using Hotel_Domain.Models;
using Hotel_Domain.ViewModels;
using Hotel_Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Repository.Services.Custom_Services
{
    public class GuestService
    {
        private readonly MainDBContext _context;

        public GuestService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<List<GuestViewModel>> GetAllGuestsAsync()
        {
            var guests = await _context.Guests.ToListAsync();
            return MapGuestsToViewModels(guests);
        }

        public async Task<GuestViewModel> GetGuestByIdAsync(int guestId)
        {
            var guest = await _context.Guests.FindAsync(guestId);
            return MapGuestToViewModel(guest);
        }

        public async Task AddGuestAsync(GuestViewModel guestViewModel)
        {
            var guest = MapViewModelToGuest(guestViewModel);
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGuestAsync(GuestViewModel guestViewModel)
        {
            var guest = MapViewModelToGuest(guestViewModel);
            _context.Entry(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuestAsync(int guestId)
        {
            var guest = await _context.Guests.FindAsync(guestId);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
            }
        }

        private List<GuestViewModel> MapGuestsToViewModels(List<Guest> guests)
        {
            var guestViewModels = new List<GuestViewModel>();
            foreach (var guest in guests)
            {
                guestViewModels.Add(MapGuestToViewModel(guest));
            }
            return guestViewModels;
        }

        private GuestViewModel MapGuestToViewModel(Guest guest)
        {
            return new GuestViewModel
            {
                GuestId = guest.GuestId,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                PhoneNumber = guest.PhoneNumber
            };
        }

        private Guest MapViewModelToGuest(GuestViewModel guestViewModel)
        {
            return new Guest
            {
                GuestId = guestViewModel.GuestId,
                FirstName = guestViewModel.FirstName,
                LastName = guestViewModel.LastName,
                Email = guestViewModel.Email,
                PhoneNumber = guestViewModel.PhoneNumber
            };
        }
    }
}
