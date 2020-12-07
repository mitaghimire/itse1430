/*
 * ITSE 1430
 * Mita Ghimire
 * Lab5
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterCreator
{
    public interface ICharacterRoster
    {
        Character CreateCharacter(string name, string profession, string race, Attributes attribute, string description);


        int Add(Character addCharacter);
        void Delete(int uniqueIdentifier);

        Character Get(int uniqueIdentifier);
        List<Character> GetAll();

        void Update(int uniqueIdentifier,Character updateCharacter);
    }
}
