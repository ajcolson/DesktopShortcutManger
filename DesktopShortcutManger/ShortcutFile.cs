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
        public ShortcutFile(string pathToFile)
        {
            Location = pathToFile;

            string[] pathParts = pathToFile.Split('\\');
            Name = pathParts[pathParts.Length - 1].Split('.')[0];
        }

        public string Location{ get; }
        public string Name { get; }

        public bool Delete()
        {
            if (File.Exists(Location))
            {
                try
                {
                    File.Delete(Location);
                }
                catch
                {
                    return false;
                }
                
                return true;
            }
            else return false;
        }
    }
}
