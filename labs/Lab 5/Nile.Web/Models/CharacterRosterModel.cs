using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRoster.Web.Models
    {
        public class CharacterRosterModel // : IValidatableObject
        {

        public CharacterRosterModel ()
        { }
        public CharacterRosterModel ( CharacterRoster character )
        {
            //transform from business object to model
            Id = character.Id;
            Name = character.Name;
            Race = character.Race;
            Profession = character.Profession;
            
        }

        public CharacterRoster ToCharacterRoster ()
        {
            return new CharacterRoster() {
                Id = Id,
                Name = Name,
                Race = Race,
                Profession = Profession,
               
            };

        }
         
        [Range(0, Int32.MaxValue)]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }
           
            [Required]
            public string Race { get; set; }
          
            [Required]
            public string Profession  { get; set; } 
            

        }
    }


