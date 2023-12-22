using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.General_Services.DirectorService
{
    public class DirectorService : IDirectorService
    {
        #region  Constructor
        private readonly IRepository<Directors> _directorRepository;

        public DirectorService(IRepository<Directors> directorRepository)
        {
            _directorRepository = directorRepository;
        }
        #endregion

        #region Get All
        public async Task<IEnumerable<DirectorViewModel>> GetAllAsync()
        {
            var directors = await _directorRepository.GetAllAsync();
            return directors.Select(director => new DirectorViewModel
            {
                DirId = director.DirId,
                DirFirstName = director.DirFirstName,
                DirLastName = director.DirLastName,
                DirDob = director.DirDob,
            });
        }
        #endregion

        #region Get BY ID 
        public async Task<DirectorViewModel> GetByIdAsync(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);
            return director != null ? new DirectorViewModel
            {
                DirId = director.DirId,
                DirFirstName = director.DirFirstName,
                DirLastName = director.DirLastName,
                DirDob = director.DirDob,
            } : null;
        }
        #endregion

        #region Post
        public async Task AddAsync(DirectorInsertModel entity)
        {
            var director = new Directors
            {
                DirFirstName = entity.DirFirstName,
                DirLastName = entity.DirLastName,
                DirDob = entity.DirDob,
            };

            await _directorRepository.AddAsync(director);
        }
        #endregion

        #region  Update
        public async Task UpdateAsync(DirectorInsertModel entity)
        {
            var director = await _directorRepository.GetByIdAsync(entity.DirId);
            if (director != null)
            {
                director.DirFirstName = entity.DirFirstName;
                director.DirLastName = entity.DirLastName;
                director.DirDob = entity.DirDob;

                await _directorRepository.UpdateAsync(director);
            }
        }
        #endregion

        #region  Delete
        public async Task DeleteAsync(int id)
        {
            await _directorRepository.DeleteAsync(id);
        }
        #endregion
    }
}
