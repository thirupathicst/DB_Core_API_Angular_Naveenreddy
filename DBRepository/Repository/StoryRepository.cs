using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository
{
    public class StoryRepository:Repository<Story>, IStoryRepository
    {
        public StoryRepository(NaveenReddyDbContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public async Task<B_Story> SelectByIdAsync(int PersonId)
        {
            var story = await base.GetSingleAsync(x=>x.PersonId==PersonId);
            B_Story _story=new B_Story();
            if (_story != null)
            {
                _story.Description = story.Description;
                _story.Name = story.Name;
                _story.MarriageDate = story.Marriagedate;
                _story.PersonId = story.PersonId;
            }
             return _story;
        }

        public async Task<B_Story> CreateAsync(B_Story story)
        {
            Story _story = new Story()
            {
                Description = story.Description,
                Name = story.Name,
                Marriagedate = story.MarriageDate,
                PersonId = story.PersonId,
                Createddatetime=DateTime.Now
            };
            await base.CreateAsync(_story);
            return story;
        }

        public async Task<B_Story> UpdateAsync(B_Story story)
        {
            var _story = await base.GetSingleAsync(x=>x.PersonId==story.PersonId);
            if (_story != null)
            {
                _story.Description = story.Description;
                _story.Name = story.Name;
                _story.Marriagedate = story.MarriageDate;
                _story.PersonId = story.PersonId;
                _story.Updateddatetime = DateTime.Now;

                await base.UpdateAsync(_story);
                return story;
            }
            else
            {
                throw new NoDetailsFoundException();
            }
        }
    }
}
