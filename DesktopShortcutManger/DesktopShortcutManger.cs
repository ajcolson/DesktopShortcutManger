using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopShortcutManger
{
    class DesktopShortcutManger
    {
        public DesktopShortcutManger(string currentUser, bool includePublicDesktop = true)
        {
            CurrentUser = currentUser;
            CanPublicDesktopForShortcuts = includePublicDesktop;
        }

        public string CurrentUser { get; set; }
        public bool CanPublicDesktopForShortcuts { get; set; }
        private readonly List<ShortcutFile> FoundShortcutFiles = new List<ShortcutFile>();
        public ReadOnlyCollection<ShortcutFile> FoundShortcuts;

        public void ScanForShortcuts()
        {
            FoundShortcutFiles.Clear();
            string[] userDesktopShortcuts = Directory.GetFiles($"C:\\Users\\{CurrentUser}\\Desktop\\", "*.lnk");
            foreach (string path in userDesktopShortcuts)
            {
                FoundShortcutFiles.Add(new ShortcutFile(path));
            }

            if (CanPublicDesktopForShortcuts)
            {
                string[] publicDesktopShortcuts = Directory.GetFiles(@"C:\Users\Public\Desktop\", "*.lnk");
                foreach (string path in publicDesktopShortcuts)
                {
                    FoundShortcutFiles.Add(new ShortcutFile(path));
                }
            }

            FoundShortcuts = new ReadOnlyCollection<ShortcutFile>(FoundShortcutFiles);
        }

    }
}
