using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRoster
    {
        public class CharacterRoster : IValidatableObject
        {
            /// <summary>Gets or sets the unique identifier.</summary>
            public int Id { get; set; }

            /// <summary>Gets or sets the name.</summary>
            /// <value>Never returns null.</value>
            public string Name
            {
                get { return _name ?? ""; }
                set { _name = value?.Trim(); }
            }

            /// <summary>Gets or sets the description.</summary>
            public string Race
            {
                get { return _race ?? ""; }
                set { _race = value?.Trim(); }
            }

            /// <summary>Gets or sets the price.</summary>
            public string Profession  { get; set; } 
            /// <summary>Determines if discontinued.</summary>
            public bool IsDiscontinued { get; set; }

            public override string ToString ()
            {
                return Name;
            }
            public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
            {

                if (String.IsNullOrEmpty(Name))
                    yield return new ValidationResult("Name is required", new[] { nameof(Name) });


                if (Id < 0)
                    yield return new ValidationResult("Id must be greater than or equal to 0", new[] { nameof(Id) });

            if (String.IsNullOrEmpty(Profession))
                yield return new ValidationResult("Profession is required", new[] { nameof(Profession) });



        }
            #region Private Members

            private string _name;
            private string _race;
            #endregion
        }
    }


