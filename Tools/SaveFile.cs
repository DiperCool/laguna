using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
namespace Tools
{
    public class SaveFile
    {
        public string SaveAndResize(IFormFile file, string WebRootPath)
        {
            string ext = Path.GetExtension(file.FileName);
            string shortPath = "/Photos/" + Guid.NewGuid() + ".jpeg";
            string path = WebRootPath + shortPath;
            var image = Image.Load(file.OpenReadStream());
            image.Mutate(x=>x.Resize(450,450, KnownResamplers.Lanczos3));
            image.Save(path, new JpegEncoder());
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
        public string Save(string file, string WebRootPath)
        {
            string shortPath = "/Photos/" + Guid.NewGuid() + ".jpeg";
            string path = WebRootPath + shortPath;
            var image = Image.Load(WebRootPath+file);

            image.Save(path, new JpegEncoder());
            File.Delete(WebRootPath+file);
            return shortPath;
        }
    }
}