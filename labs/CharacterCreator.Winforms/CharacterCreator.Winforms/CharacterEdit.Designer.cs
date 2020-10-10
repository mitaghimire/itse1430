namespace CharacterCreator.Winforms
{
    partial class CharacterEdit
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
            this.btnCharacterSave.Location = new System.Drawing.Point(36, 350);
            this.btnCharacterSave.Name = "btnCharacterSave";
            this.btnCharacterSave.Size = new System.Drawing.Size(112, 34);
            this.btnCharacterSave.TabIndex = 10;
            this.btnCharacterSave.Text = "Save";
            this.btnCharacterSave.UseVisualStyleBackColor = true;
            this.btnCharacterSave.Click += new System.EventHandler(this.btnCharacterSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // btnCharacterCancel
            // 
            this.btnCharacterCancel.Location = new System.Drawing.Point(190, 350);
            this.btnCharacterCancel.Name = "btnCharacterCancel";
            this.btnCharacterCancel.Size = new System.Drawing.Size(112, 34);
            this.btnCharacterCancel.TabIndex = 11;
            this.btnCharacterCancel.Text = "Cancel";
            this.btnCharacterCancel.UseVisualStyleBackColor = true;
            this.btnCharacterCancel.Click += new System.EventHandler(this.btnCharacterCancel_Click);
            // 
            // txtCharacterName
            // 
            this.txtCharacterName.Location = new System.Drawing.Point(158, 22);
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new System.Drawing.Size(245, 31);
            this.txtCharacterName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profession";
            // 
            // cbProfession
            // 
            this.cbProfession.FormattingEnabled = true;
            this.cbProfession.Location = new System.Drawing.Point(158, 84);
            this.cbProfession.Name = "cbProfession";
            this.cbProfession.Size = new System.Drawing.Size(245, 33);
            this.cbProfession.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Attribute";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Description";
            // 
            // cbRace
            // 
            this.cbRace.FormattingEnabled = true;
            this.cbRace.Location = new System.Drawing.Point(158, 152);
            this.cbRace.Name = "cbRace";
            this.cbRace.Size = new System.Drawing.Size(245, 33);
            this.cbRace.TabIndex = 3;
            // 
            // txtStrength
            // 
            this.txtStrength.Location = new System.Drawing.Point(158, 213);
            this.txtStrength.MaxLength = 3;
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.PlaceholderText = "Strength";
            this.txtStrength.Size = new System.Drawing.Size(108, 31);
            this.txtStrength.TabIndex = 4;
            // 
            // txtIntelligent
            // 
            this.txtIntelligent.Location = new System.Drawing.Point(284, 213);
            this.txtIntelligent.MaxLength = 3;
            this.txtIntelligent.Name = "txtIntelligent";
            this.txtIntelligent.PlaceholderText = "Intelligent";
            this.txtIntelligent.Size = new System.Drawing.Size(119, 31);
            this.txtIntelligent.TabIndex = 5;
            // 
            // txtAgility
            // 
            this.txtAgility.Location = new System.Drawing.Point(425, 213);
            this.txtAgility.MaxLength = 3;
            this.txtAgility.Name = "txtAgility";
            this.txtAgility.PlaceholderText = "Agility";
            this.txtAgility.Size = new System.Drawing.Size(115, 31);
            this.txtAgility.TabIndex = 6;
            // 
            // txtConstitution
            // 
            this.txtConstitution.Location = new System.Drawing.Point(561, 213);
            this.txtConstitution.MaxLength = 3;
            this.txtConstitution.Name = "txtConstitution";
            this.txtConstitution.PlaceholderText = "Constitution";
            this.txtConstitution.Size = new System.Drawing.Size(109, 31);
            this.txtConstitution.TabIndex = 7;
            // 
            // txtCharisma
            // 
            this.txtCharisma.Location = new System.Drawing.Point(688, 213);
            this.txtCharisma.MaxLength = 3;
            this.txtCharisma.Name = "txtCharisma";
            this.txtCharisma.PlaceholderText = "Charisma";
            this.txtCharisma.Size = new System.Drawing.Size(109, 31);
            this.txtCharisma.TabIndex = 8;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(158, 273);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(245, 31);
            this.txtDescription.TabIndex = 9;
            // 
            // errCharacterNew
            // 
            this.errCharacterNew.ContainerControl = this;
            // 
            // CharacterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(834, 416);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharacterEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Character";
            this.Load += new System.EventHandler(this.CharacterEdit_Load);
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
        private System.Windows.Forms.ErrorProvider errCharacterNew;
    }
}