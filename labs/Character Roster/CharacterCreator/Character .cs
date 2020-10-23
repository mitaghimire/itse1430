/*
 * ITSE 1430
 * Mita Ghimire
 * Lab3
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    public class Character : IValidatableObject
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

        [Required(ErrorMessage = "Unique Identifier has not been set!")]
        public int UniqueIdentifier { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateProperty(this.Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(this.Profession,
                new ValidationContext(this, null, null) { MemberName = "Profession" },
                results);
            Validator.TryValidateProperty(this.Race,
               new ValidationContext(this, null, null) { MemberName = "Race" },
               results);
            Validator.TryValidateProperty(this.Attributes,
                new ValidationContext(this, null, null) { MemberName = "Attributes" },
                results); 
            Validator.TryValidateProperty(this.UniqueIdentifier,
                new ValidationContext(this, null, null) { MemberName = "UniqueIdentifier" },
                results);

            return results;
        }
    }



    public class Attributes : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateProperty(this.Strength,
                new ValidationContext(this, null, null) { MemberName = "Strength" },
                results);
            Validator.TryValidateProperty(this.Intelligence,
                new ValidationContext(this, null, null) { MemberName = "Intelligence" },
                results);
            Validator.TryValidateProperty(this.Agility,
               new ValidationContext(this, null, null) { MemberName = "Agility" },
               results);
            Validator.TryValidateProperty(this.Constitution,
                new ValidationContext(this, null, null) { MemberName = "Constitution" },
                results); 
            Validator.TryValidateProperty(this.Charisma,
                new ValidationContext(this, null, null) { MemberName = "Charisma" },
                results);
     
            return results;

        }
    }


}

