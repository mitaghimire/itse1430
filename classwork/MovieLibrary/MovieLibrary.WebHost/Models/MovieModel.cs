
/*
 * ITSE 1430
 * Mita Ghimire
 * Classwork
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace MovieLibrary.WebHost.Models
{

    public class MovieModel //: IValidatableObject
    {
        public MovieModel ()
        { }
        public MovieModel( Movie movie)
        {
            //transform from business object to model
            Id = movie.Id;
            Name = movie.Name;
            Description = movie.Description;
            Rating = movie.Rating;
            RunLength = movie.RunLength;
            ReleaseYear = movie.ReleaseYear;
            IsClassic = movie.IsClassic;
        }

        public Movie ToMovie ()
        {
            return new Movie() {
                Id = Id,
                Name = Name,
                Description = Description,
                Rating = Rating,
                RunLength = RunLength,
                ReleaseYear = ReleaseYear,
                IsClassic = IsClassic,
            };
         
        }

        //Metadata - data about data

        public int Id { get; set; }

        //Attributes are metadata
        //[][] -multiple attributes
        //[XAttribute()], [XAttribute], [X]
        //Attributes may be limited to certain types or members

        //Required - value cannot be null
        //[RequiredAttribute()]
        //[RequiredAttribute]
        [Required(AllowEmptyStrings = false)]
        [StringLength(Movie.MaximumNameLength)]
        public string Name { get; set; }

        [StringLength(Movie.MaximumNameLength)]
        public string Description { get; set; }

        public string Rating { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Run length must be greater than or equal to 0.")]
        public int RunLength { get; set; }

        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        public bool IsClassic { get; set; }


    } 
}
