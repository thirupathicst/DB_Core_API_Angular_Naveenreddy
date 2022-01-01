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
    public class ImageRepository : Repository<Images>, IImageRepository
    {
        public ImageRepository(NaveenReddyDbContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public async Task<B_Images> CreateAsync(B_Images images)
        {
            Images _image = new Images()
            {
                Physicalpath = images.PhysicalPath,
                Shortpath = images.ShortPath,
                PersonId = images.PersonId,
                Createddatetime=DateTime.Now
            };
            await base.CreateAsync(_image);
            return images;
        }

    }
}
