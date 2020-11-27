﻿
namespace DesktopShortcutManger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AppTitleBar = new System.Windows.Forms.Panel();
            this.AppTitleBarIcon = new System.Windows.Forms.PictureBox();
            this.AppTitleBarTextLabel = new System.Windows.Forms.Label();
            this.AppTitleBarCloseButton = new System.Windows.Forms.Button();
            this.ShortcutCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.RescanButton = new System.Windows.Forms.Button();
            this.RemoveCheckedItemsButton = new System.Windows.Forms.Button();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.SelectAllItemsButton = new System.Windows.Forms.Button();
            this.UnselectAllItemsButton = new System.Windows.Forms.Button();
            this.AppTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppTitleBarIcon)).BeginInit();
            this.ControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppTitleBar
            // 
            this.AppTitleBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AppTitleBar.BackColor = System.Drawing.SystemColors.Window;
            this.AppTitleBar.Controls.Add(this.AppTitleBarIcon);
            this.AppTitleBar.Controls.Add(this.AppTitleBarTextLabel);
            this.AppTitleBar.Controls.Add(this.AppTitleBarCloseButton);
            this.AppTitleBar.Location = new System.Drawing.Point(0, 0);
            this.AppTitleBar.Name = "AppTitleBar";
            this.AppTitleBar.Size = new System.Drawing.Size(550, 32);
            this.AppTitleBar.TabIndex = 0;
            this.AppTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppTitleBar_MouseDown);
            // 
            // AppTitleBarIcon
            // 
            this.AppTitleBarIcon.Image = ((System.Drawing.Image)(resources.GetObject("AppTitleBarIcon.Image")));
            this.AppTitleBarIcon.Location = new System.Drawing.Point(0, 0);
            this.AppTitleBarIcon.Name = "AppTitleBarIcon";
            this.AppTitleBarIcon.Size = new System.Drawing.Size(32, 32);
            this.AppTitleBarIcon.TabIndex = 2;
            this.AppTitleBarIcon.TabStop = false;
            this.AppTitleBarIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppTitleBarIcon_MouseDown);
            // 
            // AppTitleBarTextLabel
            // 
            this.AppTitleBarTextLabel.AutoSize = true;
            this.AppTitleBarTextLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppTitleBarTextLabel.Location = new System.Drawing.Point(35, 4);
            this.AppTitleBarTextLabel.Name = "AppTitleBarTextLabel";
            this.AppTitleBarTextLabel.Size = new System.Drawing.Size(237, 25);
            this.AppTitleBarTextLabel.TabIndex = 1;
            this.AppTitleBarTextLabel.Text = "Desktop Shortcut Manager";
            this.AppTitleBarTextLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppTitleBarTextLabel_MouseDown);
            // 
            // AppTitleBarCloseButton
            // 
            this.AppTitleBarCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AppTitleBarCloseButton.FlatAppearance.BorderSize = 0;
            this.AppTitleBarCloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.AppTitleBarCloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.AppTitleBarCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AppTitleBarCloseButton.Font = new System.Drawing.Font("Wingdings 2", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.AppTitleBarCloseButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AppTitleBarCloseButton.Location = new System.Drawing.Point(508, 0);
            this.AppTitleBarCloseButton.Name = "AppTitleBarCloseButton";
            this.AppTitleBarCloseButton.Size = new System.Drawing.Size(42, 32);
            this.AppTitleBarCloseButton.TabIndex = 0;
            this.AppTitleBarCloseButton.Text = "Í";
            this.AppTitleBarCloseButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.AppTitleBarCloseButton.UseVisualStyleBackColor = false;
            this.AppTitleBarCloseButton.Click += new System.EventHandler(this.AppTitleBarCloseButton_Click);
            // 
            // ShortcutCheckedListBox
            // 
            this.ShortcutCheckedListBox.CheckOnClick = true;
            this.ShortcutCheckedListBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortcutCheckedListBox.FormattingEnabled = true;
            this.ShortcutCheckedListBox.Location = new System.Drawing.Point(278, 34);
            this.ShortcutCheckedListBox.Name = "ShortcutCheckedListBox";
            this.ShortcutCheckedListBox.ScrollAlwaysVisible = true;
            this.ShortcutCheckedListBox.Size = new System.Drawing.Size(269, 356);
            this.ShortcutCheckedListBox.TabIndex = 1;
            this.ShortcutCheckedListBox.ThreeDCheckBoxes = true;
            // 
            // RescanButton
            // 
            this.RescanButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RescanButton.Location = new System.Drawing.Point(47, 73);
            this.RescanButton.Name = "RescanButton";
            this.RescanButton.Size = new System.Drawing.Size(180, 48);
            this.RescanButton.TabIndex = 2;
            this.RescanButton.Text = "Rescan For Shortcuts";
            this.RescanButton.UseVisualStyleBackColor = true;
            this.RescanButton.Click += new System.EventHandler(this.RescanButton_Click);
            // 
            // RemoveCheckedItemsButton
            // 
            this.RemoveCheckedItemsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveCheckedItemsButton.Location = new System.Drawing.Point(47, 235);
            this.RemoveCheckedItemsButton.Name = "RemoveCheckedItemsButton";
            this.RemoveCheckedItemsButton.Size = new System.Drawing.Size(180, 48);
            this.RemoveCheckedItemsButton.TabIndex = 3;
            this.RemoveCheckedItemsButton.Text = "Remove Checked Items";
            this.RemoveCheckedItemsButton.UseVisualStyleBackColor = true;
            this.RemoveCheckedItemsButton.Click += new System.EventHandler(this.RemoveCheckedItemsButton_Click);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Controls.Add(this.UnselectAllItemsButton);
            this.ControlsPanel.Controls.Add(this.SelectAllItemsButton);
            this.ControlsPanel.Controls.Add(this.RescanButton);
            this.ControlsPanel.Controls.Add(this.RemoveCheckedItemsButton);
            this.ControlsPanel.Location = new System.Drawing.Point(1, 34);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(274, 356);
            this.ControlsPanel.TabIndex = 4;
            // 
            // SelectAllItemsButton
            // 
            this.SelectAllItemsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllItemsButton.Location = new System.Drawing.Point(47, 127);
            this.SelectAllItemsButton.Name = "SelectAllItemsButton";
            this.SelectAllItemsButton.Size = new System.Drawing.Size(180, 48);
            this.SelectAllItemsButton.TabIndex = 5;
            this.SelectAllItemsButton.Text = "Select All Items";
            this.SelectAllItemsButton.UseVisualStyleBackColor = true;
            this.SelectAllItemsButton.Click += new System.EventHandler(this.SelectAllItemsButton_Click);
            // 
            // UnselectAllItemsButton
            // 
            this.UnselectAllItemsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnselectAllItemsButton.Location = new System.Drawing.Point(47, 181);
            this.UnselectAllItemsButton.Name = "UnselectAllItemsButton";
            this.UnselectAllItemsButton.Size = new System.Drawing.Size(180, 48);
            this.UnselectAllItemsButton.TabIndex = 6;
            this.UnselectAllItemsButton.Text = "Unselect All Items";
            this.UnselectAllItemsButton.UseVisualStyleBackColor = true;
            this.UnselectAllItemsButton.Click += new System.EventHandler(this.UnselectAllItemsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 392);
            this.Controls.Add(this.ControlsPanel);
            this.Controls.Add(this.ShortcutCheckedListBox);
            this.Controls.Add(this.AppTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.AppTitleBar.ResumeLayout(false);
            this.AppTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppTitleBarIcon)).EndInit();
            this.ControlsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AppTitleBar;
        private System.Windows.Forms.Button AppTitleBarCloseButton;
        private System.Windows.Forms.Label AppTitleBarTextLabel;
        private System.Windows.Forms.CheckedListBox ShortcutCheckedListBox;
        private System.Windows.Forms.Button RescanButton;
        private System.Windows.Forms.Button RemoveCheckedItemsButton;
        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.PictureBox AppTitleBarIcon;
        private System.Windows.Forms.Button UnselectAllItemsButton;
        private System.Windows.Forms.Button SelectAllItemsButton;
    }
}

