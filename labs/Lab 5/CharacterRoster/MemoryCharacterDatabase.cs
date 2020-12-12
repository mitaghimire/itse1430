using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRoster
{
     public  class MemoryCharacterDatabase : CharacterDatabase
    {
        public MemoryCharacterDatabase(List<CharacterRoster> characters )
        {
            _characters = characters;
        }
        protected override CharacterRoster AddCore ( CharacterRoster characterRoster )
        {
            var newCharacterRoster = CopyCharacter(characterRoster);
            _characters.Add(newCharacterRoster);

            if (newCharacterRoster.Id <= 0)
                newCharacterRoster.Id = _nextId++;
            else if (newCharacterRoster.Id >= _nextId)
                _nextId = newCharacterRoster.Id + 1;

            return CopyCharacter(newCharacterRoster);
        }

       
        protected override CharacterRoster GetCore ( int id )
        {
            var characterRoster = FindCharacter(id);

            return (characterRoster != null) ? CopyCharacter(characterRoster) : null;
        }

        
        protected override IEnumerable<CharacterRoster> GetAllCore ()
        {
            foreach (var characterRoster in _characters)
                yield return CopyCharacter(characterRoster);
        }

        
        protected override void DeleteCore ( int id )
        {
            var characterRoster = FindCharacter(id);
            if (characterRoster != null)
                _characters.Remove(characterRoster);
        }

        
        protected override CharacterRoster UpdateCore ( CharacterRoster existing, CharacterRoster characterRoster )
        {
            //Replace 
            existing = FindCharacter(characterRoster.Id);
            _characters.Remove(existing);

            var newCharacterRoster = CopyCharacter(characterRoster);
            _characters.Add(newCharacterRoster);

            return CopyCharacter(newCharacterRoster);
        }
      

        private CharacterRoster CopyCharacter ( CharacterRoster characterRoster )
        {
            var newCharacterRoster = new CharacterRoster();
            newCharacterRoster.Id = characterRoster.Id;
            newCharacterRoster.Name = characterRoster.Name;
            newCharacterRoster.Race = characterRoster.Race;
            newCharacterRoster.Profession = characterRoster.Profession;
           

            return newCharacterRoster;
        }

       
        private CharacterRoster FindCharacter ( int id )
        {
            foreach (var character in _characters)
            {
                if (character.Id == id)
                    return character;
            };

            return null;
        }

        private List<CharacterRoster> _characters;
        private int _nextId = 1;
    }
}

