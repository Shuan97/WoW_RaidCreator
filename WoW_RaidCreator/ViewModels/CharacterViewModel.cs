using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW_RaidCreator.Models;

namespace WoW_RaidCreator.ViewModels
{
    internal class CharacterViewModel : ViewModelBase
    {
        private Character _character;


        public Character Character
        {
            get { return _character; }
        }

        public CharacterViewModel()
        {
            _character = new Character("Shuan", Character.ClassType.Priest, 1, 1,1,1);
        }

        public void SaveChanges()
        {

        }


    }
}
