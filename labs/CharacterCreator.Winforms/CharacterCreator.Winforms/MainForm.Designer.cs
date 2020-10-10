namespace CharacterCreator.Winforms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msFile = new System.Windows.Forms.MenuStrip();
            this.tsMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuCharacter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuCharacterNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuCharacterEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuCharacterDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lstCharacter = new System.Windows.Forms.ListBox();
            this.msFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // msFile
            // 
            this.msFile.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuFile,
            this.tsMenuCharacter,
            this.tsMenuHelp});
            this.msFile.Location = new System.Drawing.Point(0, 0);
            this.msFile.Name = "msFile";
            this.msFile.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.msFile.Size = new System.Drawing.Size(222, 28);
            this.msFile.TabIndex = 0;
            this.msFile.Text = "File";
            // 
            // tsMenuFile
            // 
            this.tsMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemExit});
            this.tsMenuFile.Name = "tsMenuFile";
            this.tsMenuFile.Size = new System.Drawing.Size(46, 24);
            this.tsMenuFile.Text = "File";
            // 
            // tsMenuItemExit
            // 
            this.tsMenuItemExit.Name = "tsMenuItemExit";
            this.tsMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsMenuItemExit.Size = new System.Drawing.Size(169, 26);
            this.tsMenuItemExit.Text = "Exit";
            this.tsMenuItemExit.Click += new System.EventHandler(this.tsMenuItemExit_Click);
            // 
            // tsMenuCharacter
            // 
            this.tsMenuCharacter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuCharacterNew,
            this.tsMenuCharacterEdit,
            this.tsMenuCharacterDelete});
            this.tsMenuCharacter.Name = "tsMenuCharacter";
            this.tsMenuCharacter.Size = new System.Drawing.Size(86, 24);
            this.tsMenuCharacter.Text = "Character";
            // 
            // tsMenuCharacterNew
            // 
            this.tsMenuCharacterNew.Name = "tsMenuCharacterNew";
            this.tsMenuCharacterNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsMenuCharacterNew.Size = new System.Drawing.Size(175, 26);
            this.tsMenuCharacterNew.Text = "New";
            this.tsMenuCharacterNew.Click += new System.EventHandler(this.tsMenuCharacterNew_Click);
            // 
            // tsMenuCharacterEdit
            // 
            this.tsMenuCharacterEdit.Name = "tsMenuCharacterEdit";
            this.tsMenuCharacterEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsMenuCharacterEdit.Size = new System.Drawing.Size(175, 26);
            this.tsMenuCharacterEdit.Text = "Edit";
            this.tsMenuCharacterEdit.Click += new System.EventHandler(this.tsMenuCharacterEdit_Click);
            // 
            // tsMenuCharacterDelete
            // 
            this.tsMenuCharacterDelete.Name = "tsMenuCharacterDelete";
            this.tsMenuCharacterDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsMenuCharacterDelete.Size = new System.Drawing.Size(175, 26);
            this.tsMenuCharacterDelete.Text = "Delete";
            this.tsMenuCharacterDelete.Click += new System.EventHandler(this.tsMenuCharacterDelete_Click);
            // 
            // tsMenuHelp
            // 
            this.tsMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemAbout});
            this.tsMenuHelp.Name = "tsMenuHelp";
            this.tsMenuHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tsMenuHelp.Size = new System.Drawing.Size(55, 24);
            this.tsMenuHelp.Text = "Help";
            // 
            // tsMenuItemAbout
            // 
            this.tsMenuItemAbout.Name = "tsMenuItemAbout";
            this.tsMenuItemAbout.Size = new System.Drawing.Size(133, 26);
            this.tsMenuItemAbout.Text = "About";
            this.tsMenuItemAbout.Click += new System.EventHandler(this.tsMenuItemAbout_Click);
            // 
            // lstCharacter
            // 
            this.lstCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCharacter.FormattingEnabled = true;
            this.lstCharacter.HorizontalScrollbar = true;
            this.lstCharacter.ItemHeight = 20;
            this.lstCharacter.Location = new System.Drawing.Point(0, 28);
            this.lstCharacter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstCharacter.Name = "lstCharacter";
            this.lstCharacter.Size = new System.Drawing.Size(222, 287);
            this.lstCharacter.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 315);
            this.Controls.Add(this.lstCharacter);
            this.Controls.Add(this.msFile);
            this.MainMenuStrip = this.msFile;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(212, 345);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Character Creator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.msFile.ResumeLayout(false);
            this.msFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem tsMenuCharacter;
        private System.Windows.Forms.ToolStripMenuItem tsMenuCharacterNew;
        private System.Windows.Forms.ListBox lstCharacter;
        private System.Windows.Forms.ToolStripMenuItem tsMenuCharacterEdit;
        private System.Windows.Forms.ToolStripMenuItem tsMenuCharacterDelete;
    }
}

