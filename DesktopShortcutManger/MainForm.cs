using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DesktopShortcutManger
{
    public partial class MainForm : Form
    {
        /*
         * Custom Title Bar Helpers
         */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        public void MoveWindowAtCursorPos()
        {
            ReleaseCapture();
            _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        /*
         * End Helpers
         */


        public bool INVOKED_AS_SYSTEM = (Environment.UserName == "SYSTEM");
        DesktopShortcutManger dsm;
        CurrentUserInfo cui;
        
        void RescanForShortcuts()
        {
            ShortcutCheckedListBox.Items.Clear();
            dsm.ScanForShortcuts();

            foreach (ShortcutFile shortcutFile in dsm.FoundShortcuts)
            {
                ShortcutCheckedListBox.Items.Add(shortcutFile.Name);
            }
            CheckAllBoxes();
        }

        void CheckAllBoxes()
        {
            for (int i = 0; i < ShortcutCheckedListBox.Items.Count; i++)
            {
                ShortcutCheckedListBox.SetItemChecked(i, true);
            }
        }

        void UncheckAllBoxes()
        {
            for (int i = 0; i < ShortcutCheckedListBox.Items.Count; i++)
            {
                ShortcutCheckedListBox.SetItemChecked(i, false);
            }
        }


        public MainForm()
        {
            InitializeComponent();
        }

        private void AppTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MoveWindowAtCursorPos();
        }

        private void AppTitleBarCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AppTitleBarTextLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MoveWindowAtCursorPos();
        }

        private void AppTitleBarIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MoveWindowAtCursorPos();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (INVOKED_AS_SYSTEM)
            {
                SystemAccountWarningPanel.Hide();
            }
            try
            {
                cui = new CurrentUserInfo(INVOKED_AS_SYSTEM);
                dsm = new DesktopShortcutManger(cui.Username, cui.DesktopDir);
                RescanForShortcuts();
            }
            catch (Exception ex)
            {
                if (ex.Message == "ERROR_USERNAME_NOT_FOUND")
                {
                    MessageBox.Show($"There was a problem with detecting the currently signed in user. We will not be able to locate shortcuts on the desktop.\n\nPlease contact your system administrator about this for more assistance.\n\nThis application will now close.", "Unable To Find Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else if (ex.Message == "ERROR_USERSID_NOT_FOUND")
                {
                    MessageBox.Show($"There was a problem with detecting the currently signed in user. We will not be able to locate shortcuts on the desktop.\n\nPlease contact your system administrator about this for more assistance.\n\nThis application will now close.", "Unable To Find User SID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else if (ex.Message == "ERROR_DESKTOP_DIR_NOT_FOUND")
                {
                    MessageBox.Show($"There was a problem with detecting the currently signed in user. We will not be able to locate shortcuts on the desktop.\n\nPlease contact your system administrator about this for more assistance.\n\nThis application will now close.", "Unable To Find User Desktop Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            
        }

        private void RescanButton_Click(object sender, EventArgs e)
        {
            RescanForShortcuts();
        }

        private void RemoveCheckedItemsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dsm.FoundShortcuts.Count; i++)
            {
                if (ShortcutCheckedListBox.GetItemChecked(i))
                {
                    try
                    {
                        dsm.FoundShortcuts[i].Delete();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"There was a problem with deleting the shortcut called \"{ShortcutCheckedListBox.Items[i]}\". This is most likely because you attempted to delete a file that you do not have permission to delete.\n\nPlease contact your system administrator about this for more assistance.", "Shortcut Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            RescanForShortcuts();
        }

        private void SelectAllItemsButton_Click(object sender, EventArgs e)
        {
            CheckAllBoxes();
        }

        private void UnselectAllItemsButton_Click(object sender, EventArgs e)
        {
            UncheckAllBoxes();
        }

        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ajcolson/DesktopShortcutManger");
        }

        private void AppVersionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MoveWindowAtCursorPos();
        }

        private void WarnNotRunningAsSystemAccount()
        {
            MessageBox.Show("This program may not work correctly as it was not started by the SYSTEM account for this computer. Some shortcuts may not delete correctly right now.\n\nPlease contact your system administrator about this for more assistance.", "Desktop Shortcut Manager may not be working correctly...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void SystemAccountWarningPanel_Click(object sender, EventArgs e)
        {
            WarnNotRunningAsSystemAccount();
        }

        private void SystemAccountWarningLabel_Click(object sender, EventArgs e)
        {
            WarnNotRunningAsSystemAccount();
        }
    }
}
