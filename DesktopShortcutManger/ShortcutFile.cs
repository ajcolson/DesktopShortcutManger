using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopShortcutManger
{
    class ShortcutFile
    {
        public ShortcutFile(string pathToFile, string displayBeforeFileName = "")
        {
            Location = pathToFile;
            Name = displayBeforeFileName;
            
            string[] pathParts = pathToFile.Split('\\');
            string[] filenameParts = pathParts[pathParts.Length - 1].Split('.');
            for (int i = 0; i < filenameParts.Length - 1; i++)
            {
                if (i > 0)
                {
                    Name += ".";
                }
                Name += filenameParts[i];
            }
                      
        }

        public string Location{ get; }
        public string Name { get; }

        public void Delete()
        {
            if (File.Exists(Location))
            {
                try
                {
                    File.Delete(Location);
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
        }
    }
}
