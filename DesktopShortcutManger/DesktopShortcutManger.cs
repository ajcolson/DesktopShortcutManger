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
        public DesktopShortcutManger(string currentUser, string desktopDir , bool includePublicDesktop = true)
        {
            CurrentUser = currentUser;
            CurrentUserDesktopDir = desktopDir;
            CanCheckPublicDesktopForShortcuts = includePublicDesktop;
        }

        public string CurrentUser { get; }
        public bool CanCheckPublicDesktopForShortcuts { get; set; }
        public string CurrentUserDesktopDir { get; }

        private readonly List<ShortcutFile> FoundShortcutFiles = new List<ShortcutFile>();
        public ReadOnlyCollection<ShortcutFile> FoundShortcuts;

        public void ScanForShortcuts()
        {
            FoundShortcutFiles.Clear();
            string[] userDesktopShortcuts = Directory.GetFiles(CurrentUserDesktopDir, "*.lnk");
            foreach (string path in userDesktopShortcuts)
            {
                FoundShortcutFiles.Add(new ShortcutFile(path,$"[{CurrentUser}'s Desktop] "));
            }

            if (CanCheckPublicDesktopForShortcuts)
            {
                string[] publicDesktopShortcuts = Directory.GetFiles(@"C:\Users\Public\Desktop\", "*.lnk");
                foreach (string path in publicDesktopShortcuts)
                {
                    FoundShortcutFiles.Add(new ShortcutFile(path, "[Public Desktop] "));
                }
            }

            FoundShortcuts = new ReadOnlyCollection<ShortcutFile>(FoundShortcutFiles);
        }

    }
}
