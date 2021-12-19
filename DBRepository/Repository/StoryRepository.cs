using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class StoryRepository:Repository<Story>, IStoryRepository
    {
        public StoryRepository(NaveenReddyDbContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public async Task<B_Story> AddStory(B_Story story)
        {
            Story _story = new Story()
            {
                Description = story.Description,
                Name = story.Name,
                Marriagedate = story.MarriageDate,
                PersonId = story.PersonId,
                Createddatetime=DateTime.Now
            };
            await CreateAsync(_story);
            return story;
        }

        public async Task<B_Story> UpdateStory(B_Story story)
        {
            var _story = await SelectById(story.PersonId);
            if (_story != null)
            {
                _story.Description = story.Description;
                _story.Name = story.Name;
                _story.Marriagedate = story.MarriageDate;
                _story.PersonId = story.PersonId;
                _story.Updateddatetime = DateTime.Now;

                await UpdateAsync(_story);
                return story;
            }
            else
            {
                throw new NoDetailsFoundException();
            }
        }
    }
}
