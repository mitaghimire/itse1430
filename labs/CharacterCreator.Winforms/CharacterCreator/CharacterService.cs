using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterCreator
{
    public class CharacterService
    {
        public static List<Character> lstCharacter = new List<Character>();
               

        public static void AddtoListCharacter(Character character)
        {
            lstCharacter.Add(character);
        }

        public static void UpdateListCharacter(Character delCharacter, Character updateCharacter)
        {
            lstCharacter.Remove(delCharacter);
            lstCharacter.Add(updateCharacter);
        }

        public static void DeleteListCharacter(Character delCharacter)
        {
            lstCharacter.Remove(delCharacter);
        }

        public static Character CreateCharacter(string name, ProfessionEnum profession, RaceEnum race, Attributes attribute, string description)
        {
            Character chr = new Character();
            chr.Name = name;
            chr.Profession = profession;
            chr.Race = race;
            chr.Attributes = attribute;
            chr.Description = description;
            return chr;
        }

    }
}
