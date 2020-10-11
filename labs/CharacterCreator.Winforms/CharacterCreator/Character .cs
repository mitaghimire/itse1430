using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    public class Character
    {

        //•Name: (Required) The name of the character.
        //•	Profession: (Required) The profession of the character. The available professions are: Fighter, Hunter, Priest, Rogue and Wizard.
        //•	Race: (Required) The race of the character. The available races are: Dwarf, Elf, Gnome, Half Elf and Human.
        //•	Attributes: (Required) A set of numeric attributes that define a character. The attributes are: Strength, Intelligence, Agility, Constitution and Charisma.The values can be between 1 and 100.
        //•	Description: The optional, biographic details of the character.

        [Required(ErrorMessage = "Character Name is Required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Profession is Required!")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Race is Required!")]
        public string Race { get; set; }

        [Required(ErrorMessage = "Attribute is Required!")]
        
        public Attributes Attributes { get; set; }
        
        public string Description { get; set; }
    }


 

    
    public class Attributes
    {
        [Required]
        [Range(1, 100, ErrorMessage = "Value should be 1 to 100")]
        public string Strength { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Value should be 1 to 100")]
        public string Intelligence { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Value should be 1 to 100")]
        public string Agility { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Value should be 1 to 100")]
        public string Constitution { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Value should be 1 to 100")]
        public string Charisma { get; set; } 
    }

    
}

