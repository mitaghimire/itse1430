﻿using System;

namespace MovieLibrary.WindformsHost
{
    partial class MovieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._txtRunLength = new System.Windows.Forms.TextBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._chkClassic = new System.Windows.Forms.CheckBox();
            this._comboRating = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._txtReleaseYear = new System.Windows.Forms.TextBox();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Location = new System.Drawing.Point(110, 31);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(240, 27);
            this._txtName.TabIndex = 0;
            this._txtName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidatedName);
            // 
            // _txtDescription
            // 
            this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescription.Location = new System.Drawing.Point(110, 64);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(240, 100);
            this._txtDescription.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Run Length";
            // 
            // _txtRunLength
            // 
            this._txtRunLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtRunLength.Location = new System.Drawing.Point(101, 170);
            this._txtRunLength.Name = "_txtRunLength";
            this._txtRunLength.Size = new System.Drawing.Size(57, 27);
            this._txtRunLength.TabIndex = 2;
            this._txtRunLength.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRunLength);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.CausesValidation = false;
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(266, 360);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(94, 29);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnSave.Location = new System.Drawing.Point(150, 360);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(110, 29);
            this._btnSave.TabIndex = 6;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _chkClassic
            // 
            this._chkClassic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._chkClassic.AutoSize = true;
            this._chkClassic.Location = new System.Drawing.Point(101, 203);
            this._chkClassic.Name = "_chkClassic";
            this._chkClassic.Size = new System.Drawing.Size(96, 24);
            this._chkClassic.TabIndex = 3;
            this._chkClassic.Text = "Is Classic?";
            this._chkClassic.UseVisualStyleBackColor = true;
            // 
            // _comboRating
            // 
            this._comboRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._comboRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboRating.FormattingEnabled = true;
            this._comboRating.Items.AddRange(new object[] {
            "G",
            "PG",
            "PG-13",
            "R"});
            this._comboRating.Location = new System.Drawing.Point(101, 252);
            this._comboRating.Name = "_comboRating";
            this._comboRating.Size = new System.Drawing.Size(80, 28);
            this._comboRating.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rating";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Release Year";
            // 
            // _txtReleaseYear
            // 
            this._txtReleaseYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtReleaseYear.Location = new System.Drawing.Point(110, 286);
            this._txtReleaseYear.Name = "_txtReleaseYear";
            this._txtReleaseYear.Size = new System.Drawing.Size(48, 27);
            this._txtReleaseYear.TabIndex = 5;
            this._txtReleaseYear.Text = "1900";
            this._txtReleaseYear.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateReleaseYear);
            // 
            // _errors
            // 
            this._errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errors.ContainerControl = this;
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(393, 398);
            this.Controls.Add(this._txtReleaseYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._comboRating);
            this.Controls.Add(this._chkClassic);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._txtRunLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._txtName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(411, 445);
            this.Name = "MovieForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Movie";
            //this.Load += new System.EventHandler(this.MovieForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //private void MovieForm_Load ( object sender, EventArgs e )
        //{
        //    throw new NotImplementedException();
        //}

        //private void button2_Click ( object sender, EventArgs e )
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtRunLength;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.CheckBox _chkClassic;
        private System.Windows.Forms.ComboBox _comboRating;
        private System.Windows.Forms.Label label4;
       // private readonly EventHandler _txtDescription_TextChanged;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtReleaseYear;
        private System.Windows.Forms.ErrorProvider _errors;

        // public EventHandler TxtDescription_TextChanged => _txtDescription_TextChanged;
    }
}