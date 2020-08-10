using System;
using System.IO;
using System.Web;

namespace OnlineStore.WebPLL.Helpers
{
    public static class ImageHelper
    {
        public static string SaveImage(HttpPostedFileBase image, string folderName,
            HttpServerUtilityBase server, string modelName)
        {
            if (image == null) return null;

            var fileExtension = Path.GetExtension(image.FileName);
            var shortFolderPath = $"~/Images/Logos/{folderName}/";
            var folderPath = server.MapPath(shortFolderPath);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = String.Concat(modelName, Guid.NewGuid().ToString(), fileExtension);
            string filePath = Path.Combine(folderPath, fileName);

            image.SaveAs(filePath);

            return String.Concat(shortFolderPath, fileName);
        }
    }
}