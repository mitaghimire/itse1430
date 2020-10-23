/*
 * ITSE 1430
 * Mita Ghimire
 * Lab3
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterCreator
{
    public class Roster : ICharacterRoster
    {
        private static int _uniqueIdentifier { get; set; }
        public static List<Character> _listCharacter = new List<Character>();

        public int Add(Character addCharacter)
        {
            addCharacter.UniqueIdentifier = ++_uniqueIdentifier;
            _listCharacter.Add(addCharacter);
            return _uniqueIdentifier;
        }

        public void Delete(int uniqueIdentifier)
        {
            _listCharacter.Remove(_listCharacter.Find(r => r.UniqueIdentifier == uniqueIdentifier));
        }

        public Character Get(int uniqueIdentifier)
        {
            return _listCharacter.Find(r => r.UniqueIdentifier == uniqueIdentifier);
        }

        public List<Character> GetAll()
        {
            return _listCharacter;
        }

        public void Update(int uniqueIdentifier, Character updateCharacter)
        {
            int index = _listCharacter.FindIndex(r => r.UniqueIdentifier == uniqueIdentifier);
            updateCharacter.UniqueIdentifier = uniqueIdentifier;
            _listCharacter[index] = updateCharacter;
        }

        public Character CreateCharacter(string name, string profession, string race, Attributes attribute, string description)
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
