using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsMenuItemExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void tsMenuItemAbout_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.ShowDialog();
        }

        private void tsMenuCharacterNew_Click(object sender, EventArgs e)
        
        {
            CharacterNew chrNew = new CharacterNew();
            chrNew.ShowDialog();
            BindListBox();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {           
            BindListBox();
        }

        private void BindListBox()
        {

            BindingSource bs = new BindingSource();
            bs.DataSource = CharacterService.lstCharacter;
            lstCharacter.DataSource = bs;
            lstCharacter.DisplayMember = "Name";
            lstCharacter.Refresh();
            lstCharacter.Update();
        }

        private void tsMenuCharacterEdit_Click(object sender, EventArgs e)
        {
            CharacterEdit chrEdit = new CharacterEdit(lstCharacter.SelectedValue);
            chrEdit.ShowDialog();
            BindListBox();
        }

        private void tsMenuCharacterDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show($"Are you sure to delete {((Character)lstCharacter.SelectedValue).Name}?", "Deletion", MessageBoxButtons.YesNo);
            if(confirmation == DialogResult.Yes)
            {
                CharacterService.DeleteListCharacter((Character)lstCharacter.SelectedValue);
                BindListBox();
            }

        }
    }
}
