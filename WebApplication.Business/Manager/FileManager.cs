using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Interfaces.Business;

namespace WebApplication.Business.Manager
{
    public class FileManager : ManagerBase, IFileManager
    {
        public void SaveImage(Stream fileStream, string fileName, string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using(MagickImage image = new MagickImage(fileStream))
            {
                image.Format = MagickFormat.Png;
                image.Resize(600, 0);
                image.Write(Path.Combine(filePath, fileName));
            }
        }
    }
}
