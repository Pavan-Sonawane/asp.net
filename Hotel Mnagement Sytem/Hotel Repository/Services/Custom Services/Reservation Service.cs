using Hotel_Domain.Models;
using Hotel_Domain.ViewModels;
using Hotel_Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Repository.Services.Custom_Services
{
    public class Reservation_Service
    {
        private readonly MainDBContext _context;

        public Reservation_Service(MainDBContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation1ViewModel>> GetAllReservationsWithDetailsAsync()
        {
            var reservations = await _context.Reservations
                .Include(r => r.Guest)
               
                .Include(r => r.Invoice)
                .ToListAsync();

            return reservations.Select(r => new Reservation1ViewModel
            {
                ReservationId = r.ReservationId,
                GuestId = r.GuestId,
                RoomType = r.RoomType,
                CheckInDate = r.CheckInDate,
                CheckOutDate = r.CheckOutDate,
                ReservationDate = r.ReservationDate,
                Guest = MapGuestViewModel(r.Guest),
               
                Invoice = MapInvoiceViewModel(r.Invoice)
            }).ToList();
        }

        public async Task<Reservation1ViewModel> GetReservationWithDetailsByIdAsync(int reservationId)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Guest)
              
                .Include(r => r.Invoice)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            if (reservation == null)
            {
                return null;
            }

            return new Reservation1ViewModel
            {
                ReservationId = reservation.ReservationId,
                GuestId = reservation.GuestId,
                RoomType = reservation.RoomType,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                ReservationDate = reservation.ReservationDate,
                Guest = MapGuestViewModel(reservation.Guest),
            
                Invoice = MapInvoiceViewModel(reservation.Invoice)
            };
        }

        // Helper methods to map nested properties

        private GuestViewModel MapGuestViewModel(Guest guest)
        {
            return guest != null ? new GuestViewModel
            {
                GuestId = guest.GuestId,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                PhoneNumber = guest.PhoneNumber
            } : null;
        }

        

        private InvoiceViewModel MapInvoiceViewModel(Invoice invoice)
        {
            return invoice != null ? new InvoiceViewModel
            {
                InvoiceId = invoice.InvoiceId,
                ReservationId = invoice.ReservationId,
                TotalAmount = invoice.TotalAmount,
                IssueDate = invoice.IssueDate,
                DueDate = invoice.DueDate,
                PaymentStatus = invoice.PaymentStatus
            } : null;
        }




        public async Task AddReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            return await _context.Reservations.FindAsync(reservationId);
        }

    }
}
