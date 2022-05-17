using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ecommerce.Services
{
    public class EcommerceImage
    {

        public string SaveImage(string bitImage)
        {
           var imgData = bitImage?.Split(',');
            if (imgData == null || imgData.Length <= 1) return null;
           var fileExtension = imgData[0].Split('/')[1].Split(';')[0];
           byte[] bytes = Convert.FromBase64String(imgData[1]);
           var relativePath = $"Products/{Guid.NewGuid()}.{fileExtension}";
           var fullPath = Path.Combine("wwwroot", relativePath);

            FileStream stream = new FileStream(fullPath, FileMode.Append, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(stream);
           writer.Write(bytes, 0, bytes.Length);
           writer.Close();

           return relativePath;
        }

    }
}
