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
            _miMovieEdit.Click += OnMovieEdit;
            _miMovieDelete.Click += OnMovieDelete;
            _miHelpAbout.Click += OnHelpAbout;

        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            RefreshUI();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        //Event - a notification to interested parties that something has happened

        //Array - T[] Array of movies
        // Instantiate ::= new T[Ei]
        // Index : 0 to Size - 1
        // private Movie[] _movies = new Movie[100]; //0.99
        private MovieDatabase _movies = new MovieDatabase();
       // private Movie[] _emptyMovies = new Movie[0]; // empty arrays and nulls to be equivalent so always use empty array instead of null

        private void AddMovie ( Movie movie )
        {
            var newMovie = _movies.Add(movie, out var message);
            if (newMovie == null)
            {
                MessageBox.Show(this, message, "Add Failed", MessageBoxButtons.OK);
                return;
            };

            RefreshUI();

            // Find first empty sport in array
            // for (EI; EC; EU ) S;
            //     EI :: = initializer expression (runs once before loop executes)
            //     EC :: = conditional expression => boolen (executes before loop statement is run, aborts if condition is false
            //     EU :: = update expression (runs at end of current iterate)
            // Length -> int(# of rows in the array)
            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    if (_movies[index] == null)
            //    {
            //        //Add movie to array
            //        _movies[index] = movie; //Movie is ref type thus movie and _movies[index] reference the same instance
            //        return;
            //    };
            //};
            //MessageBox.Show(this, "No more room for movies", "Add Failed", MessageBoxButtons.OK);
        }
        
        private void DeleteMovie ( int id )
        {
            _movies.Delete(id);
            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    //Array element acess :: = V[int]
            //    //if (_movies[index] != null && _movies{index].Id == id)
            //    if (_movies[index]?.Id == id) //null conditional ?. if instance != null acess the member
            //    {
            //        _movies[index] = null; 
            //        return;
            //    };
            //};
        }

        private void EditMovie ( int id, Movie movie )
        {
            var error = _movies.Update(id, movie);
            if (String.IsNullOrEmpty(error))
            {
                RefreshUI();
                return;
            };
            //for (var index = 0; index < _movies.Length; ++index)
            //{ 
            //    if (_movies[index]?.Id == id) //null conditional ?. if instance != null acess the member
            //    {
            //        //Just because we are doing this in memory
            //        movie.Id = id;
            //        _movies[index] = movie;
            //        return;
            //    };
            //};
            MessageBox.Show(this, error, "Edit Movie", MessageBoxButtons.OK);
        }

        private Movie GetSelectedMovie ()
        {
            return _lstMovies.SelectedItem as Movie;

 
        }

        private void RefreshUI ()
        {
            //_lstMovies.DisplayMember = nameof(Movie.Name); //"Name"

            _lstMovies.DataSource = null;
            _lstMovies.DataSource = _movies.GetAll();
        }

        private void OnMovieAdd (object sender, EventArgs e)
        {
            var form = new MovieForm();
            
           // ShowDialog - model :: = user must interact with child form, cannot acess parent
           // Show - modeless :: = multiple window open and acessible at same time
           var result =  form.ShowDialog(this);  //Block until is dismissed
            if (result == DialogResult.Cancel)
                return;
            
            //Save movie
            AddMovie(form.Movie);
            
        }

        private void OnMovieDelete ( object sender, EventArgs e)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;
            //DialogResult
            switch (MessageBox.Show(this, $"Are you sure you want to delete '{movie.Name}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No:return; 
            };

            DeleteMovie(movie.Id);
            RefreshUI();
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //object creation
            // 1. Allocate memory from instance, zero initialized
            // 2. Initialize fields
            // 3. Constructor (finish initialization)
            // 4. Return new instance
            var form = new MovieForm(movie, "Edit Movie");
           // form.Movie = _movie;
            
            var result = form.ShowDialog(this);  //Block until is dismissed
            if (result == DialogResult.Cancel)
                return;

            EditMovie(movie.Id, form.Movie);
        }

        private void _lstMovies_SelectedIndexChanged ( object sender, EventArgs e )
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