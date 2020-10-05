using System;        //DO NOT DELETE
using System.Windows.Forms;

//Hierarchical namespaces
//namespace MovieLibrary
//{
//    namespace WindformsHost
//    {
//    }
//}
//namespace Company.Product.<area>
//namespace Microsoft.Office.Word
//    namespace Microsoft.Office.Excel

namespace MovieLibrary.WindformsHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Types - Movie
            // Variable - movie
            // value - instance ( or an object )
            Movie movie;
            movie = new Movie(); //Creat an instance ::= new T()


            //label2.Text = "A label";

            //var movie2 = new Movie(); //New instance

            //member access operator ::= E . M
            movie.Name = "Jaws";
            movie.Description = "Shark movie";
            //var str = movie.description;

            // Hooks up an event handler to an event
            // Event += method
            // Event -= method
            toolStripMenuItem5.Click += OnMovieAdd;
            toolStripMenuItem7.Click += OnMovieDelete;
        }

        //Event - a notification to interested parties that something has happened

        private void OnMovieAdd (object sender, EventArgs e)
        {
            var form = new MovieForm();
            
           // ShowDialog - model :: = user must interact with child form, cannot acess parent
           // Show - modeless :: = multiple window open and acessible at same time
           var result =  form.ShowDialog(this);  //Block until is dismissed
            if (result == DialogResult.Cancel)
                return;

            // After form is gone

            //TOOO: Save movie
            MessageBox.Show("Save successful");

        }

        private void OnMovieDelete ( object sender, EventArgs e)
        {
            //TOO: Verify movie exists

            //DialogResult
           switch (MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No:return;
                 
            };

            //TOOO: Delete movie
        }

    }
}
//namespace OtherNamesspace
//{
//    public class MainForm
//    {
//    }
//}