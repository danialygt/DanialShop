using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.EndPoints.WebUI.FileServices
{
    public class FileSaver
    {

        public string Save (IFormFile formFile)
        {
            if(formFile != null && formFile.Length > 0)
            {
                var fileExtention = Path.GetExtension(formFile.FileName);
                var fileName = $"{Guid.NewGuid()}{fileExtention}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\photos", fileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
                return $"/photos/{fileName}";
            }
            return null;
        }

    }
}
