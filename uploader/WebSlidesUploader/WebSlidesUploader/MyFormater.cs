using System.IO;

namespace WebSlidesUploader
{
    class MyFormater
    {
        // vérifie si le fichier est au format image jpg
        public static bool IsPictureFile(string filename)
        {
            string extension = Path.GetExtension(filename).ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
            }
            return false;
        }
    }
}
