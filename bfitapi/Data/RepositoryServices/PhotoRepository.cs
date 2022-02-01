using bfitapi.Data.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.RepositoryServices
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly BfitContext _context;
        private readonly long _fileSizeLimit;

        public PhotoRepository(BfitContext context, IConfiguration config)
        {
            _context = context;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
        }

        public Task<IFormFile> Create()
        {
            throw new NotImplementedException();
        }

        public Task<IFormFileCollection> Create(IFormFileCollection photos)
        {

            throw new NotImplementedException();
        }

        public Task<IFormFile> Create(IFormFile photo)
        {
            throw new NotImplementedException();
        }

        public Task<IFormFile> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IFormFile> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IFormFile>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<IFormFile> Update(IFormFile photo)
        {
            throw new NotImplementedException();
        }
    }
}
