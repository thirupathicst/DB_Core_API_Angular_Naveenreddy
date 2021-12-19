using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class ImageRepository : Repository<Images>, IImageRepository
    {
        public ImageRepository(NaveenReddyDbContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public async Task<B_Images> AddImage(B_Images images)
        {
            Images _image = new Images()
            {
                Physicalpath = images.PhysicalPath,
                Shortpath = images.ShortPath,
                PersonId = images.PersonId,
                Createddatetime=DateTime.Now
            };
            await CreateAsync(_image);
            return images;
        }

        public async Task<B_Images> UpdateImage(B_Images images)
        {
           var _image= await SelectById(images.PersonId);
            if (_image!=null)
            {
                _image.Physicalpath = images.PhysicalPath;
                _image.Shortpath = images.ShortPath;
                _image.Updateddatetime = DateTime.Now;
                await UpdateAsync(_image);
                return images;
            }
            else
            {
                throw new NoDetailsFoundException();
            }
        }
    }
}
