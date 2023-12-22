using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.General_Services
{
    public class ActorService : IActorService
    {
        #region Constructor
        private readonly IRepository<Actor> _actorRepository;

        public ActorService(IRepository<Actor> actorRepository)
        {
            _actorRepository = actorRepository;
        }
        #endregion

        #region getAll

        public async Task<IEnumerable<ActorViewModel>> GetAllAsync()
        {
            var actors = await _actorRepository.GetAllAsync();
            return actors.Select(actor => new ActorViewModel
            {
                ActId = actor.ActId,
                ActFirstName = actor.ActFirstName,
                ActLastName = actor.ActLastName,
                ActGender = actor.ActGender,
                ActDob = actor.ActDob,
               
            });
        }
        #endregion

        #region  GetBy ID
        public async Task<ActorViewModel> GetByIdAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            return actor != null ? new ActorViewModel
            {
                ActId = actor.ActId,
                ActFirstName = actor.ActFirstName,
                ActLastName = actor.ActLastName,
                ActGender = actor.ActGender,
                ActDob = actor.ActDob,
            } : null;
        }
        #endregion

        #region Post
        public async Task AddAsync(ActorInsertModel entity)
        {
            var actor = new Actor
            {
                ActFirstName = entity.ActFirstName,
                ActLastName = entity.ActLastName,
                ActGender = entity.ActGender,
                ActDob = entity.ActDob,
            };

            await _actorRepository.AddAsync(actor);
        }
        #endregion

        #region Update
        public async Task UpdateAsync(ActorInsertModel entity)
        {
            var actor = await _actorRepository.GetByIdAsync(entity.ActId);
            if (actor != null)
            {
                actor.ActFirstName = entity.ActFirstName;
                actor.ActLastName = entity.ActLastName;
                actor.ActGender = entity.ActGender;
                actor.ActDob = entity.ActDob;

                await _actorRepository.UpdateAsync(actor);
            }
        }
        #endregion

        #region Delete 
        public async Task DeleteAsync(int id)
        {
            await _actorRepository.DeleteAsync(id);
        }
        #endregion
    }
}
