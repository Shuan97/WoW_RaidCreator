using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using WoW_RaidCreator.Annotations;

namespace WoW_RaidCreator.Models
{
    public class Character : INotifyPropertyChanged
    {
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
        
        #endregion

        #region Fields

        private string _name;
        private string _class;
        private string _mainSpec;
        private string _offSpec;
        private float _mainSpecGearScore;
        private float _offSpecGearScore;

        #endregion

        #region Properties

        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Class
        {
            get => _class;
            set
            {

                if (value == _class) return;
                _class = value;
                OnPropertyChanged(nameof(Class));
            }
        }
 
        public string MainSpec
        {
            get => _mainSpec;
            set
            {
                if (value == _mainSpec) return;
                _mainSpec = value;
                OnPropertyChanged(nameof(MainSpec));
            }
        }

        public string OffSpec
        {
            get => _offSpec;
            set
            {
                if (value == _offSpec) return;
                _offSpec = value;
                OnPropertyChanged(nameof(OffSpec));
            }
        }

        public float MainSpecGearScore
        {
            get => _mainSpecGearScore;
            set
            {
                if (Math.Abs(value - _mainSpecGearScore) < 0.1f) return;
                _mainSpecGearScore = value;
                OnPropertyChanged(nameof(MainSpecGearScore));
            }
        }

        public float OffSpecGearScore
        {
            get => _offSpecGearScore;
            set
            {
                if (Math.Abs(value - _offSpecGearScore) < 0.1f) return;
                _offSpecGearScore = value;
                OnPropertyChanged(nameof(OffSpecGearScore));
            }
        }

        #endregion

        #region Constructors

        public Character()
        {
            this.Id = -1;
            this.Name = "foo";
            this.Class = ClassType.DeathKnight.ToString();
            this.MainSpec = "main";
            this.OffSpec = "off";
            this.MainSpecGearScore = 0;
            this.OffSpecGearScore = 0;
        }

        public Character( string name, string classType, string mainSpec, string offSpec, float mainSpecGearScore, float offSpecGearScore)
        {
            this.Name = name;
            this.Class = classType;
            this.MainSpec = mainSpec;
            this.OffSpec = offSpec;
            this.MainSpecGearScore = mainSpecGearScore;
            this.OffSpecGearScore = offSpecGearScore;
        }

        public Character(int id, string name, string classType, string mainSpec, string offSpec, float mainSpecGearScore, float offSpecGearScore)
        {
            this.Id = id;
            this.Name = name;
            this.Class = classType;
            this.MainSpec = mainSpec;
            this.OffSpec = offSpec;
            this.MainSpecGearScore = mainSpecGearScore;
            this.OffSpecGearScore = offSpecGearScore;
        }

        public Character(IList<string> list)
        {
            this.Id = Convert.ToInt32(list[0]);
            this.Name = list[1];
            this.Class = list[2];
            this.MainSpec = list[3];
            this.OffSpec = list[4];
            this.MainSpecGearScore = Convert.ToSingle(list[5]);
            this.OffSpecGearScore = Convert.ToSingle(list[6]);
        }

        public Character(IList<object> list)
        {
            this.Id = Convert.ToInt32(list[0]);
            this.Name = list[1].ToString();
            this.Class = list[2].ToString();
            this.MainSpec = list[3].ToString();
            this.OffSpec = list[4].ToString();
            this.MainSpecGearScore = Convert.ToSingle(list[5]);
            this.OffSpecGearScore = Convert.ToSingle(list[6]);
        }

        #endregion

        #region INotifyPropertyChanged region

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion
    }


    /// <summary>
    /// Struct stores class and specialization info
    /// </summary>
    public struct CharacterClass
    {
        public string Class { get; set; }
        public List<string> Spec { get; set; }

        [NotNull]
        public List<CharacterClass> GetClasses()
        {
            var returnClass = new List<CharacterClass>
            {
                new CharacterClass()
                {
                    Class = Character.ClassType.DeathKnight.ToString(),
                    Spec = new List<string>() {"Blood", "Frost", "Unholy"}
                },
                new CharacterClass()
                {
                    Class = Character.ClassType.Druid.ToString(),
                    Spec = new List<string>() {"Feral", "Balance", "Restoration"}
                },
                new CharacterClass()
                {
                    Class = Character.ClassType.Hunter.ToString(),
                    Spec = new List<string>() {"Marksmanship", "Beast Mastery", "Survival"}
                },
                new CharacterClass()
                {
                    Class = Character.ClassType.Mage.ToString(),
                    Spec = new List<string>() {"Fire", "Frost", "Arcane"}
                },
                new CharacterClass()
                {
                    Class = Character.ClassType.Paladin.ToString(),
                    Spec = new List<string>() {"Protection", "Retribution", "Holy"}
                },
                new CharacterClass()
                {
                    Class = Character.ClassType.Priest.ToString(),
                    Spec = new List<string>() {"Shadow", "Discipline", "Holy"}
                },
                new CharacterClass()
                {
                    Class = Character.ClassType.Rogue.ToString(),
                    Spec = new List<string>() {"Assassination", "Combat", "Subtlety"}
                },
                new CharacterClass()
                {
                    Class = Character.ClassType.Shaman.ToString(),
                    Spec = new List<string>() {"Enhancement", "Elemental", "Restoration"}
                },
                new CharacterClass()
                {
                    Class = Character.ClassType.Warlock.ToString(),
                    Spec = new List<string>() {"Affliction", "Demonology", "Destruction"}
                },
                new CharacterClass()
                {
                    Class = Character.ClassType.Warrior.ToString(),
                    Spec = new List<string>() {"Protection", "Fury", "Arms"}
                }
            };
            return returnClass;
        }
    }
}
