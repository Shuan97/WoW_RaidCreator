using System.ComponentModel;
using System.Runtime.CompilerServices;
using WoW_RaidCreator.Annotations;

namespace WoW_RaidCreator.Models
{
    public class Character : INotifyPropertyChanged
    {
        private string _name;

        #region Enumerators

        public enum ClassType
        {
            DeathKnight,
            Druid,
            Hunter,
            Mage,
            Paladin,
            Priest,
            Rogue,
            Shaman,
            Warlock,
            Warrior
        }

        public enum Role
        {
            Tank,
            Melee,
            Range,
            Heal
        }

        #endregion


        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public ClassType Class { get; private set; }
        public float MainSpec { get; private set; }
        public float OffSpec { get; private set; }
        public float MainSpecGearScore { get; private set; }
        public float OffSpecGearScore { get; private set; }

        #endregion

        public Character(string name, ClassType classType, float mainSpec, float offSpec, float mainSpecGearScore, float offSpecGearScore)
        {
            this.Name = name;
            this.Class = classType;
            this.MainSpec = mainSpec;
            this.OffSpec = offSpec;
            this.MainSpecGearScore = mainSpecGearScore;
            this.OffSpecGearScore = offSpecGearScore;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
