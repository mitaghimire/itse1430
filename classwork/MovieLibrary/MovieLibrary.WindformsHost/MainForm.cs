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
            _miMovieAdd.Click += OnMovieAdd;
            _miMovieEdit.Click +=_miMovieEdit_Click;
            _miMovieDelete.Click += OnMovieDelete;
            _miHelpAbout.Click += OnHelpAbout;

        }

        private void _miMovieEdit_Click ( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        //Event - a notification to interested parties that something has happened
        private Movie _movie;

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
            _movie = form.Movie;

            MessageBox.Show("Save successful");

        }

        private void OnMovieDelete ( object sender, EventArgs e)
        {
            // Verify movie exists
            if (_movie == null)
                return;

            //DialogResult
           switch (MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No:return;
                 
            };

            //TOOO: Delete movie
            _movie = null;
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            if (_movie == null)
                return;

            //object creation
            // 1. Allocate memory from instance, zero initialized
            // 2. Initialize fields
            // 3. Constructor (finish initialization)
            // 4. Return new instance
            var form = new MovieForm();
            form.Movie = _movie;
            
            var result = form.ShowDialog(this);  //Block until is dismissed
            if (result == DialogResult.Cancel)
                return;

            
            //TOOO: Update movie
            _movie = form.Movie;

            MessageBox.Show("Save successful");

        }
        private void MainForm_Load ( object sender, EventArgs e )
        {

        }
    }
}
//namespace OtherNamesspace
//{
//    public class MainForm
//    {
//    }
//}