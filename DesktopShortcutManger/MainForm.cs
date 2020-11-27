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

        DesktopShortcutManger dsm;
        
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
            dsm = new DesktopShortcutManger(System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1]);
            RescanForShortcuts();
        }

        private void RescanButton_Click(object sender, EventArgs e)
        {
            RescanForShortcuts();
        }

        private void RemoveCheckedItemsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i< dsm.FoundShortcuts.Count; i++)
            {
                if (ShortcutCheckedListBox.GetItemChecked(i))
                {
                    bool deletedShortcut = dsm.FoundShortcuts[i].Delete();
                    if (!deletedShortcut)
                    {
                        MessageBox.Show($"There was a problem with deleting the shortcut called \"{ShortcutCheckedListBox.Items[i]}\". This is most likely because you attempted to delete a file that you do not have permission to delete. Please contact your system administrator about this for more assistance.", "Shortcut Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
