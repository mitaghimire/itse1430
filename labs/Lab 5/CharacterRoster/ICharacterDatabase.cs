using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRoster
{
   public interface ICharacterDatabase
    {
       
          CharacterRoster Add ( CharacterRoster characterRoster);

        
        CharacterRoster Get ( int id );

        
        IEnumerable<CharacterRoster> GetAll ();

       
        void Delete ( int id );

       
        CharacterRoster Update (CharacterRoster characterRoster );
    }
}
