using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.IServices
{
    public interface IPhotoRepository : ICrudRepository<IFormFile>
    {
        public Task<IFormFileCollection> Create(IFormFileCollection photos);
    }
}
