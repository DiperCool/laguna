using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;
namespace Tools
{
    public class SaveFile
    {
        public async Task<string> SaveAndResize(IFormFile file, string WebRootPath)
        {
            string ext = Path.GetExtension(file.FileName);
            string shortPath = "/Photos/" + Guid.NewGuid() + ".png";
            string path = WebRootPath + shortPath;
            var image = Image.Load(file.OpenReadStream());
            image.Mutate(x=>x.Resize(450,450));
            image.Save(path, new PngEncoder());
            return shortPath;
        }

        public async Task<string> Save(IFormFile file, string WebRootPath)
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