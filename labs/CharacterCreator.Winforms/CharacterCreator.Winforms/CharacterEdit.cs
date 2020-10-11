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
    public partial class CharacterEdit : Form
    {
        private Character EditCharacter { get; set; }
        public CharacterEdit(object characterName)
        {
            EditCharacter = (Character)characterName;//CharacterService.lstCharacter.Find(x=>x.Name.Equals(characterName));
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



                ValidationContext context1 = new ValidationContext(attr, null, null);
                IList<ValidationResult> errors1 = new List<ValidationResult>();
                Validator.TryValidateObject(attr, context1, errors1, true);

                Character updateCharacter = CharacterService.CreateCharacter(txtCharacterName.Text, cbProfession?.SelectedItem.ToString(), cbRace?.SelectedItem.ToString(), attr, txtDescription.Text);


                ValidationContext context = new ValidationContext(updateCharacter, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                Validator.TryValidateObject(updateCharacter, context, errors, true);
                var errorCombined = errors.Concat(errors1);
                if (errorCombined.Any())
                {

                    foreach (ValidationResult result in errorCombined)
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
                    CharacterService.UpdateListCharacter(EditCharacter, updateCharacter);
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
       

        private void CharacterEdit_Load(object sender, EventArgs e)
        {
            
            BindData();

        }

        private void BindData()
        {
            txtCharacterName.Text = EditCharacter.Name;
            cbProfession.SelectedItem = EditCharacter.Profession;
            cbRace.SelectedItem = EditCharacter.Race;
            txtAgility.Text = EditCharacter.Attributes.Agility;
            txtCharisma.Text = EditCharacter.Attributes.Charisma;
            txtConstitution.Text = EditCharacter.Attributes.Constitution;
            txtIntelligent.Text = EditCharacter.Attributes.Intelligence;
            txtStrength.Text = EditCharacter.Attributes.Strength;
            txtDescription.Text = EditCharacter.Description;

        }

        private void btnCharacterCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            ResetErrorStatus();
            this.Close();
        }


}
}
