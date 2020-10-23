/*
 * ITSE 1430
 * Mita Ghimire
 * Lab3
 */
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class CharacterNew : Form
    {
        ICharacterRoster roster = new Roster();
        public CharacterNew()
        {
            InitializeComponent();
        }

        private void btnCharacterSave_Click(object sender, EventArgs e)
        {
            try
            {
                ResetErrorStatus();

                Attributes attr = new Attributes();
                attr.Agility = txtAgility.Text;
                attr.Charisma = txtCharisma.Text;
                attr.Constitution = txtConstitution.Text;
                attr.Intelligence = txtIntelligent.Text;
                attr.Strength = txtStrength.Text;

                bool validateAllProperties = false;

                var results = new List<ValidationResult>();

                bool isValidAttr = Validator.TryValidateObject(
                    attr,
                    new ValidationContext(attr, null, null),
                    results,
                    validateAllProperties);


                Character newCharacter = roster.CreateCharacter(txtCharacterName.Text, cbProfession.SelectedItem?.ToString(), cbRace.SelectedItem?.ToString(), attr, txtDescription.Text);


                bool isValidUpdateCharacter = Validator.TryValidateObject(
                    newCharacter,
                    new ValidationContext(newCharacter, null, null),
                    results,
                    validateAllProperties);


                if (!isValidUpdateCharacter || !isValidAttr)
                {
                    foreach (ValidationResult result in results)
                    {
                        if (result.MemberNames.Contains("Name"))
                            errCharacterNew.SetError(txtCharacterName, result.ErrorMessage);
                        if (result.MemberNames.Contains("Profession"))
                            errCharacterNew.SetError(cbProfession, result.ErrorMessage);
                        if (result.MemberNames.Contains("Race"))
                            errCharacterNew.SetError(cbRace, result.ErrorMessage);
                        if (result.MemberNames.Contains("Strength"))
                            errCharacterNew.SetError(txtStrength, result.ErrorMessage);
                        if (result.MemberNames.Contains("Agility"))
                            errCharacterNew.SetError(txtAgility, result.ErrorMessage);
                        if (result.MemberNames.Contains("Charisma"))
                            errCharacterNew.SetError(txtCharisma, result.ErrorMessage);
                        if (result.MemberNames.Contains("Constitution"))
                            errCharacterNew.SetError(txtConstitution, result.ErrorMessage);
                        if (result.MemberNames.Contains("Intelligence"))
                            errCharacterNew.SetError(txtIntelligent, result.ErrorMessage);
                    }
                }
                else
                {
                    roster.Add(newCharacter);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        private void ResetErrorStatus()
        {
            foreach (Control ctrl in this.Controls)
            {
                errCharacterNew.SetError(ctrl, string.Empty);
            }
        }

        private void ResetControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if(ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                if(ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedIndex = 0;
                }

            }
        }


        private void CharacterNew_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCharacterCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            ResetErrorStatus();
            this.Close();
        }
    }
}
