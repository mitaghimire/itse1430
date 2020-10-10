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



                ValidationContext context1 = new ValidationContext(attr, null, null);
                IList<ValidationResult> errors1 = new List<ValidationResult>();
                Validator.TryValidateObject(attr, context1, errors1, true);

                Character newCharacter = CharacterService.CreateCharacter(txtCharacterName.Text, (ProfessionEnum)Enum.Parse(typeof(ProfessionEnum), cbProfession.SelectedItem.ToString()), (RaceEnum)Enum.Parse(typeof(RaceEnum), cbRace.SelectedValue.ToString()), attr, txtDescription.Text);


                ValidationContext context = new ValidationContext(newCharacter, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                Validator.TryValidateObject(newCharacter, context, errors, true);
                var errorCombined = errors.Concat(errors1);
                if (errorCombined.Any())
                {

                    foreach (ValidationResult result in errorCombined)
                    {
                        if (result.MemberNames.Contains("Name"))
                            errCharacterNew.SetError(txtCharacterName, result.ErrorMessage);
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
                    CharacterService.AddtoListCharacter(newCharacter);                   
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
            cbProfession.DataSource = Enum.GetValues(typeof(ProfessionEnum));
            cbRace.DisplayMember = "Description";
            cbRace.ValueMember = "Value";
            cbRace.DataSource = Enum.GetValues(typeof(RaceEnum))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

        }

        private void btnCharacterCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            ResetErrorStatus();
            this.Close();
        }
    }
}
