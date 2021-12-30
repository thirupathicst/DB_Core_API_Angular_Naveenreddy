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

        public async Task<B_Images> UpdateAsync(B_Images images)
        {
           var _image= await base.GetSingle(x=>x.PersonId== images.PersonId);
            if (_image!=null)
            {
                _image.Physicalpath = images.PhysicalPath;
                _image.Shortpath = images.ShortPath;
                _image.Updateddatetime = DateTime.Now;
                await base.UpdateAsync(_image);
                return images;
            }
            else
            {
                throw new NoDetailsFoundException();
            }
        }
    }
}
