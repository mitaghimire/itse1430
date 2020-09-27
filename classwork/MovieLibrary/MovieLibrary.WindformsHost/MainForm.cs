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
            //var str = movie.description;

            toolStripMenuItem5.Click += OnMovieAdd;
        }

        private void OnMovieAdd (object sender, EventArgs e)
        {
            var form = new MovieForm();
            form.ShowDialog();
        }
    }
}
//namespace OtherNamesspace
//{
//    public class MainForm
//    {
//    }
//}