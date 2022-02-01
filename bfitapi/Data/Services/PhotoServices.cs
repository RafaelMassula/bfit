using bfitapi.Exceptions;
using bfitapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.Services
{
    public abstract class PhotoServices
    {
        private static readonly string[] _permittedExtensions = { ".jpeg", ".png", ".jpg" };
        private static readonly long _fileSizeLimit = 2097152;

        private static void CheckedFileExtensions(string pathFile)
        {
            var extension = Path.GetExtension(pathFile).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !_permittedExtensions.Contains(extension))
            {
                throw new ExtensionException($"Extension {extension} not allowed.");
            }
        }
        private static void CheckedFileSizeLimit(long fileSize)
        {
            if (fileSize > _fileSizeLimit)
            {
                throw new FileSizeLimitException(fileSize, _fileSizeLimit);
            }
        }
        public static IList<Photo> GetPhotos(IFormFileCollection files)
        {
            try
            {
                IList<Photo> photos = new List<Photo>();
                foreach (var photo in files)
                {
                    if (photo.Length > 0)
                    {
                        photos.Add(CreateNewObjectPhoto(photo).Result);
                    }
                }
                return photos;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }
        private static async Task<Photo> CreateNewObjectPhoto(IFormFile file)
        {
            using MemoryStream memoryStream = new();
            await file.CopyToAsync(memoryStream);
            CheckedFileExtensions(file.FileName);
            CheckedFileSizeLimit(memoryStream.Length);
            
            return new Photo(memoryStream.ToArray(), file.FileName, file.ContentType ,Path.GetExtension(file.FileName), file.Length);
        }
    }
}
