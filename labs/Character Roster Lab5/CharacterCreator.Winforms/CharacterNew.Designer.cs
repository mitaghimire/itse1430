namespace CharacterCreator.Winforms
{
    partial class CharacterNew
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
            this.components = new System.ComponentModel.Container();
            this.btnCharacterSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCharacterCancel = new System.Windows.Forms.Button();
            this.txtCharacterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProfession = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbRace = new System.Windows.Forms.ComboBox();
            this.txtStrength = new System.Windows.Forms.TextBox();
            this.txtIntelligent = new System.Windows.Forms.TextBox();
            this.txtAgility = new System.Windows.Forms.TextBox();
            this.txtConstitution = new System.Windows.Forms.TextBox();
            this.txtCharisma = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.errCharacterNew = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errCharacterNew)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCharacterSave
            // 
            this.btnCharacterSave.Location = new System.Drawing.Point(29, 280);
            this.btnCharacterSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnCharacterSave.Name = "btnCharacterSave";
            this.btnCharacterSave.Size = new System.Drawing.Size(90, 27);
            this.btnCharacterSave.TabIndex = 10;
            this.btnCharacterSave.Text = "Save";
            this.btnCharacterSave.UseVisualStyleBackColor = true;
            this.btnCharacterSave.Click += new System.EventHandler(this.btnCharacterSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // btnCharacterCancel
            // 
            this.btnCharacterCancel.Location = new System.Drawing.Point(152, 280);
            this.btnCharacterCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCharacterCancel.Name = "btnCharacterCancel";
            this.btnCharacterCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCharacterCancel.TabIndex = 11;
            this.btnCharacterCancel.Text = "Cancel";
            this.btnCharacterCancel.UseVisualStyleBackColor = true;
            this.btnCharacterCancel.Click += new System.EventHandler(this.btnCharacterCancel_Click);
            // 
            // txtCharacterName
            // 
            this.txtCharacterName.Location = new System.Drawing.Point(126, 18);
            this.txtCharacterName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new System.Drawing.Size(197, 27);
            this.txtCharacterName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profession";
            // 
            // cbProfession
            // 
            this.cbProfession.FormattingEnabled = true;
            this.cbProfession.Items.AddRange(new object[] {
            "Fighter",
            "Hunter",
            "Priest",
            "Rogue",
            "Wizard"});
            this.cbProfession.Location = new System.Drawing.Point(126, 71);
            this.cbProfession.Margin = new System.Windows.Forms.Padding(2);
            this.cbProfession.Name = "cbProfession";
            this.cbProfession.Size = new System.Drawing.Size(197, 28);
            this.cbProfession.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Attribute";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 223);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Description";
            // 
            // cbRace
            // 
            this.cbRace.FormattingEnabled = true;
            this.cbRace.Items.AddRange(new object[] {
            "Dwarf",
            "Elf",
            "Gnome",
            "Half Elf",
            "Human"});
            this.cbRace.Location = new System.Drawing.Point(126, 122);
            this.cbRace.Margin = new System.Windows.Forms.Padding(2);
            this.cbRace.Name = "cbRace";
            this.cbRace.Size = new System.Drawing.Size(197, 28);
            this.cbRace.TabIndex = 3;
            // 
            // txtStrength
            // 
            this.txtStrength.Location = new System.Drawing.Point(126, 170);
            this.txtStrength.Margin = new System.Windows.Forms.Padding(2);
            this.txtStrength.MaxLength = 3;
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.PlaceholderText = "Strength";
            this.txtStrength.Size = new System.Drawing.Size(87, 27);
            this.txtStrength.TabIndex = 4;
            this.txtStrength.Text = "50";
            // 
            // txtIntelligent
            // 
            this.txtIntelligent.Location = new System.Drawing.Point(227, 170);
            this.txtIntelligent.Margin = new System.Windows.Forms.Padding(2);
            this.txtIntelligent.MaxLength = 3;
            this.txtIntelligent.Name = "txtIntelligent";
            this.txtIntelligent.PlaceholderText = "Intelligent";
            this.txtIntelligent.Size = new System.Drawing.Size(96, 27);
            this.txtIntelligent.TabIndex = 5;
            this.txtIntelligent.Text = "50";
            // 
            // txtAgility
            // 
            this.txtAgility.Location = new System.Drawing.Point(340, 170);
            this.txtAgility.Margin = new System.Windows.Forms.Padding(2);
            this.txtAgility.MaxLength = 3;
            this.txtAgility.Name = "txtAgility";
            this.txtAgility.PlaceholderText = "Agility";
            this.txtAgility.Size = new System.Drawing.Size(93, 27);
            this.txtAgility.TabIndex = 6;
            this.txtAgility.Text = "50";
            // 
            // txtConstitution
            // 
            this.txtConstitution.Location = new System.Drawing.Point(449, 170);
            this.txtConstitution.Margin = new System.Windows.Forms.Padding(2);
            this.txtConstitution.MaxLength = 3;
            this.txtConstitution.Name = "txtConstitution";
            this.txtConstitution.PlaceholderText = "Constitution";
            this.txtConstitution.Size = new System.Drawing.Size(88, 27);
            this.txtConstitution.TabIndex = 7;
            this.txtConstitution.Text = "50";
            // 
            // txtCharisma
            // 
            this.txtCharisma.Location = new System.Drawing.Point(550, 170);
            this.txtCharisma.Margin = new System.Windows.Forms.Padding(2);
            this.txtCharisma.MaxLength = 3;
            this.txtCharisma.Name = "txtCharisma";
            this.txtCharisma.PlaceholderText = "Charisma";
            this.txtCharisma.Size = new System.Drawing.Size(88, 27);
            this.txtCharisma.TabIndex = 8;
            this.txtCharisma.Text = "50";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(126, 218);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(197, 27);
            this.txtDescription.TabIndex = 9;
            // 
            // errCharacterNew
            // 
            this.errCharacterNew.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errCharacterNew.ContainerControl = this;
            // 
            // CharacterNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(667, 333);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCharisma);
            this.Controls.Add(this.txtConstitution);
            this.Controls.Add(this.txtAgility);
            this.Controls.Add(this.txtIntelligent);
            this.Controls.Add(this.txtStrength);
            this.Controls.Add(this.cbRace);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbProfession);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCharacterName);
            this.Controls.Add(this.btnCharacterCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCharacterSave);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharacterNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            this.Load += new System.EventHandler(this.CharacterNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errCharacterNew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCharacterSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCharacterCancel;
        private System.Windows.Forms.TextBox txtCharacterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProfession;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbRace;
        private System.Windows.Forms.TextBox txtStrength;
        private System.Windows.Forms.TextBox txtIntelligent;
        private System.Windows.Forms.TextBox txtAgility;
        private System.Windows.Forms.TextBox txtConstitution;
        private System.Windows.Forms.TextBox txtCharisma;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.ErrorProvider errCharacterNew;
    }
}