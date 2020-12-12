using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRoster
{
    public abstract class CharacterDatabase : ICharacterDatabase
    {
   
        public CharacterRoster Add ( CharacterRoster characterRoster)
        {
                        return AddCore(characterRoster);
        }

        public CharacterRoster Get ( int id )
        {
           

            return GetCore(id);
        }

        
        public IEnumerable<CharacterRoster> GetAll ()
        {
            return GetAllCore();
        }

       
        public void Delete ( int id )
        {
            

            DeleteCore(id);
        }

        public CharacterRoster Update ( CharacterRoster characterRoster )
        {
            
            
            var existing = GetCore(characterRoster.Id);

            return UpdateCore(existing, characterRoster);
        }

        #region Protected Members

        protected abstract CharacterRoster GetCore ( int id );

        protected abstract IEnumerable<CharacterRoster> GetAllCore ();

        protected abstract void DeleteCore ( int id );

        protected abstract CharacterRoster UpdateCore ( CharacterRoster existing, CharacterRoster newItem );

        protected abstract CharacterRoster AddCore ( CharacterRoster product );
        #endregion
    }
}
