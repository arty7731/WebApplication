using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.Interfaces.Business
{
    public interface IFileManager
    {
        void SaveImage(Stream fileStream, string fileName, string filePath);
    }
}
