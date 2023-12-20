using Microsoft.EntityFrameworkCore;
using Personal_Details_Card_With_Image.Models;
using Personal_Details_Card_With_Image.Models.MainDbContext;
using System;

namespace Personal_Details_Card_With_Image.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            var user = new User
            {
                Full_Name = userDTO.Full_Name,
                Contact_number = userDTO.Contact_number,
                Email = userDTO.Email,
                Proffession = userDTO.Proffession,
                Qualification = userDTO.Qualification,
                Previeous_Company = userDTO.Previeous_Company,
                Previeous_CTC = userDTO.Previeous_CTC,
                Working_Domain = userDTO.Working_Domain,
                Resume = await ProcessFile(userDTO.Resume),
                ProfileImage = await ProcessFile(userDTO.ProfileImage)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(int id, UserDTO userDTO)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                
                return;
            }
            existingUser.Full_Name = userDTO.Full_Name;
            existingUser.Contact_number = userDTO.Contact_number;
            existingUser.Email = userDTO.Email;
            existingUser.Proffession = userDTO.Proffession;
            existingUser.Qualification = userDTO.Qualification;
            existingUser.Previeous_Company = userDTO.Previeous_Company;
            existingUser.Previeous_CTC = userDTO.Previeous_CTC;
            existingUser.Working_Domain = userDTO.Working_Domain;

            existingUser.Resume = await ProcessFile(userDTO.Resume);
            existingUser.ProfileImage = await ProcessFile(userDTO.ProfileImage);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<byte[]> ProcessFile(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}

