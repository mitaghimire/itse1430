using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MovieLibrary.WindformsHost
{
    // class -declaration :: = [acess ] [modifires] class identifier [: T ]
    public partial class MovieForm : Form
    {
        //Access
        //Public - accessible is derived type
        // protected - accessible in owing type and derived types
        // private - only owning type

        //Members : properties, methods
        // Virtual - Base type provides the base implementation but a derived type may override it 
        // Abstract - Base type defines it but does not implement, derived types must override it

        //Syntax
        // ctor -declaration :: = [acess] T () { S* }
        // Can call base constructor if needed, base defult constructor called if not specified
        public MovieForm () :base()// : base()
        {
            //DO NOT CALL virtual members inside of constructors
            InitializeComponent();
        }

        public MovieForm ( Movie movie ) : this(movie, null)
        {
            //Constructor chaining eliminates need for this dup initialization
            //Movie = movie;
        }

        //Constructor chaning - calling one constructor from another
        public MovieForm ( Movie movie, string title ) : this()
              
        {
            //InitializeComponent();
            Movie = movie;
            Text = title ?? "Add Movie'";
        }

        //properties can be virtual if needed but generally does not make sense
        public virtual Movie Movie { get; set; }

        //public virtual void OnLoad ( EventArgs e ) {}
        //Override indicates to compiler that you are overriding a virtual method
        protected override void OnLoad ( EventArgs e )
        {
            //Call the base member
            //this.OnLoad(e);
            base.OnLoad(e);

            if (Movie != null)

            {
                _txtName.Text = Movie.Name;
                _txtDescription.Text = Movie.Description;
                _comboRating.SelectedText = Movie.Rating;
                _chkClassic.Checked = Movie.IsClassic;
                _txtRunLength.Text = Movie.RunLength.ToString();
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();

            };

            //Go ahead and show validation errors
            ValidateChildren();
        }

        // Method - function inside a class
        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }

        //Event handlers - handles an event
        // This method is handling the button's Click event
        // void identifier ( object sender, EventArgs e )
        private void OnSave ( object sender, EventArgs e )
        {
            //Force validation of all controls
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            };
            //I want the button that was clicked
            //Type casting
            // WRONG: var button = (Button)sender; // C-style cast - crashes if wrong
            //var str = (string)10;
            //CORRECT: var button = sender as Button; // as operator - always safe returns typed version or null
            var button = sender as Button;
            if (button == null)
                return;

            var movie = new Movie();
            movie.Name = _txtName.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _comboRating.SelectedText;
            movie.IsClassic = _chkClassic.Checked;

            movie.RunLength = ReadAsInt32(_txtRunLength);
            movie.ReleaseYear = ReadAsInt32(_txtReleaseYear);

            //Using a constant
            // 1. Type name, not instance
            var nameLength = Movie.MaximumNameLength; //50
            // var nameLength = 50;

            //Won't compile
            //movie.Age =10;

            //TOO : Fix type Validate
            var ValidationResults = new ObjectValidator().TryValidateFullObject(movie);
            if(ValidationResults.Count() > 0)
            {
                //TOO : Fix this later using String.Join
                var builder = new System.Text.StringBuilder();
                foreach(var result in ValidationResults)
                {
                   builder.AppendLine(result.ErrorMessage);
                };

                //Show errormessage
                MessageBox.Show(this, builder.ToString(), "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;

            };
        // Return movie
        Movie = movie;
            Close();
        }

        private int ReadAsInt32(Control control)
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;

        }

        private void MovieForm_Load ( object sender, EventArgs e )
        {

        }

        private void OnValidatedName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            //Name is required
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required");
                e.Cancel = true; //Not validate
            } else
            {
                //Clear error from provider
                _errors.SetError(control, "");
            };

        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);

            //Run Length >=0
            if (value < 0)
            {
                _errors.SetError(control, "Run length must be >= 0");
                e.Cancel = true; //Not validate
            } else

            {
                //Clear error from provider
                _errors.SetError(control, "");
            };
        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);

            //Release Year >= 1900
            if (value < 1900)
            {
                _errors.SetError(control, "Release Year must be >= 1900");
                e.Cancel = true; //Not validate
            } else

            {
                //Clear error from provider
                _errors.SetError(control, "");
            };
        }

        private void PlayWithObject(object value)
        {
            //Common Types System (CTS) - there is 1 base type from which all other types derive
            // Systemobject => object
            // string ToString () :: = Converts avalue to a string
            // bool Equals (object) :: = Determines if the current instance equals another value
            // in GetHashCode( ) :: = Return an intergral value representing the object
            var str = 10.ToString(); //"10";
            var form = new Form();
            form.ToString(); // System.Windows.Forms.Form

            //Type checking or casting
            // 1. C-style cast :: (T)E
            // Runtime attempts convert value to T and if successful return value as T else crashes
            // Must be compile time validated
            string stringValue = (string)value;

            // 2. as operator :: = E as T
            // Runtime attempts to converts value to T and if successful returns value as T else return null
            stringValue = value as string;
            if (stringValue != null)
            { /* dealing with string*/}

            // 3. is - operator :: = E is T
            // Runtime verifies value is of the given T and return true if successful or false otherwise
            var isString = value is string; // true
            if (isString)
            {
                stringValue = (string)value;

            }
            // 4. patern- matching :: = E is T identifier
            // Runtime attempts to convert E to T and if successful stores in identifier else stores default(T)
            if (value is string sValue)
            {
                //string svalue = value as string
                // if (sValue ! = null)
            }

            // Dealing with null
            //1. Let it fall = instance.ToString() // errors if null
            //2. null- coalescing-operator :: = E1 ?? E2
            // if E1 is NOT null return E1 else return E2
            stringValue = stringValue ?? "";

            // 3. null -conditional - operator :: = E?.M
            // E is an instance, M is any member; if E is not null then call M else skop it
            stringValue = stringValue?.ToString() ?? "";
            // if (stringValue ! = null)
            //var temp = stringValue.ToString()
            // if (temp ! = null ) return ""
            // return""

            // 4. null reference types
        }
    }
}


