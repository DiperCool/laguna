using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Tools
{
    public static class SaveFile
    {
        public static async Task<string> Save(IFormFile file, string WebRootPath)
        {
            string ext = Path.GetExtension(file.FileName);
            string shortPath = "/Photos/" + Guid.NewGuid() + ext;
            string path = WebRootPath + shortPath;
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return shortPath;
        }
    }
}