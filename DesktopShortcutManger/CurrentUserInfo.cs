using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopShortcutManger
{
    class CurrentUserInfo
    {
        public string Username { get; }
        public string SID { get; }
        public string DesktopDir { get; }
        public CurrentUserInfo(bool InvokedAsSystem)
        {
            
            Username = GetUsernameFromWMI();
            SID = GetUserSIDFromWMI(Username);
            DesktopDir = GetUserDekstopDir(Username,SID,InvokedAsSystem);
        }

        private static string GetUserSIDFromWMI(string username)
        {
            string tempSID;
            string stdout_buff;
            Process QueryUserSIDProcess = new Process();

            QueryUserSIDProcess.StartInfo.FileName = @"cmd.exe";
            QueryUserSIDProcess.StartInfo.Arguments = $"/C wmic useraccount where name='{username}' get sid";
            QueryUserSIDProcess.StartInfo.CreateNoWindow = true;
            QueryUserSIDProcess.StartInfo.UseShellExecute = false;
            QueryUserSIDProcess.StartInfo.RedirectStandardOutput = true;

            QueryUserSIDProcess.Start();
            StreamReader reader = QueryUserSIDProcess.StandardOutput;
            stdout_buff = reader.ReadToEnd();
            QueryUserSIDProcess.WaitForExit();

            if (stdout_buff.Length == 0)
            {
                throw new Exception("ERROR_USERSID_NOT_FOUND");
            }
            tempSID = stdout_buff.Split(new string[] { "\n", "\r\n" },StringSplitOptions.RemoveEmptyEntries)[1];
            tempSID = tempSID.Replace("\r", "").Replace("\n", "").Trim();

            return tempSID;
        }
        private static string GetUsernameFromWMI()
        {
            string tempUsername;
            string stdout_buff;
            Process QueryUsernameProcess = new Process();

            QueryUsernameProcess.StartInfo.FileName = @"powershell.exe";
            QueryUsernameProcess.StartInfo.Arguments = @"(Get-WMIObject -class Win32_ComputerSystem | select username).username";
            QueryUsernameProcess.StartInfo.CreateNoWindow = true;
            QueryUsernameProcess.StartInfo.UseShellExecute = false;
            QueryUsernameProcess.StartInfo.RedirectStandardOutput = true;
            
            QueryUsernameProcess.Start();
            StreamReader reader = QueryUsernameProcess.StandardOutput;
            stdout_buff = reader.ReadToEnd();
            QueryUsernameProcess.WaitForExit();

            if (stdout_buff.Length == 0)
            {
                throw new Exception("ERROR_USERNAME_NOT_FOUND");
            }

            tempUsername = stdout_buff.Split('\\')[1];
            tempUsername = tempUsername.Substring(0, tempUsername.Length - 2);

            return tempUsername;
        }

        private static string GetUserDekstopDir(string username, string sid, bool InvokedAsSystem)
        {
            RegistryKey UserShellFoldersRegKey = Registry.Users.OpenSubKey($"{sid}" + @"\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders");
            string tempDirPath = UserShellFoldersRegKey.GetValue("Desktop").ToString();

            if (InvokedAsSystem)
            {
                if (tempDirPath == @"C:\WINDOWS\system32\config\systemprofile\Desktop")
                {
                    tempDirPath = $"C:\\Users\\{username}\\Desktop";
                }
            }

            if (Directory.Exists(tempDirPath))
            {
                return tempDirPath;
            }
            else throw new Exception("ERROR_DESKTOP_DIR_NOT_FOUND");
        }

    }
}
