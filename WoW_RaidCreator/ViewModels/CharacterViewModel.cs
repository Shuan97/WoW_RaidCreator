using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using WoW_RaidCreator.Annotations;
using WoW_RaidCreator.Commands;
using WoW_RaidCreator.Models;

namespace WoW_RaidCreator.ViewModels
{
    public class CharacterViewModel : ViewModelBase
    {
        public ICommand IsCheckedMainSpecCommand { get; set; }
        public ICommand IsCheckedOffSpecCommand { get; set; }
        public ICommand AddNewCharacterCommand { get; }
        public ICommand DeleteCharacterCommand { get; }
        

        private DataTable _dataTable;
        private Character _character;
        private Character _selectedCharacter;
        private DataRowView _selectedCharacterRow;
        private string _name;
        private string _mainSpec;
        private string _offSpec;


        #region Properties

        public DataTable DataTable
        {
            get => _dataTable;
            set
            {
                if (value == _dataTable) return;
                _dataTable = value;
                OnPropertyChanged(nameof(DataTable));
            }
        }

        public Character Character
        {
            get => _character;
            set
            {
                if (value == _character) return;
                _character = value;
                OnPropertyChanged(nameof(Character));
            }
        }

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

        public Character SelectedCharacter
        {
            get => _selectedCharacter;
            set => _selectedCharacter = value;
        }

        public DataRowView SelectedCharacterRow
        {
            get => _selectedCharacterRow;
            set
            {
                if (Equals(value, _selectedCharacterRow)) return;
                _selectedCharacterRow = value;
                OnPropertyChanged(nameof(SelectedCharacterRow));
            }
        }

        #endregion



        #region Cascaded ComboBox/RadioButton Add Character

        private List<CharacterClass> _classList;
        private string _selectedClass;
        private string _spec1;
        private string _spec2;
        private string _spec3;


        public bool[] MainSpecMode { get; } = { true, false, false };
        public int MainSpecSelectedMode => Array.IndexOf(MainSpecMode, true);
        public bool[] OffSpecMode { get; } = { true, false, false };
        public int OffSpecSelectedMode => Array.IndexOf(OffSpecMode, true);

        public string Spec1
        {
            get => _spec1;
            set
            {
                _spec1 = value;
                OnPropertyChanged(nameof(Spec1));
            }
        }

        public string Spec2
        {
            get => _spec2;
            set
            {
                _spec2 = value;
                OnPropertyChanged(nameof(Spec2));
            }
        }

        public string Spec3
        {
            get => _spec3;
            set
            {
                _spec3 = value;
                OnPropertyChanged(nameof(Spec3));
            }
        }

        public List<CharacterClass> ClassList
        {
            get => _classList;
            set
            {
                _classList = value;
                OnPropertyChanged(nameof(ClassList));
            }
        }
        public string SelectedClass
        {
            get => _selectedClass;
            set
            {
                _selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
                GetSpec();
            }
        }

        
        public void GetSpec()
        {
            foreach (var characterClass in ClassList)
            {
                if (characterClass.Class == SelectedClass)
                {
                    Spec1 = characterClass.Spec[0];
                    Spec2 = characterClass.Spec[1];
                    Spec3 = characterClass.Spec[2];

                    MainSpec = characterClass.Spec[MainSpecSelectedMode];
                    OffSpec = characterClass.Spec[OffSpecSelectedMode];
                }
            }
        }

        #endregion

        
        /// <summary>
        /// CharacterViewModel constructor
        /// </summary>
        public CharacterViewModel()
        { 
            CharacterClass characterClass= new CharacterClass();
            ClassList = characterClass.GetClasses();;
            DataTable = DatabaseConnectionHandler.GetTable();
            SelectedClass = Character.ClassType.DeathKnight.ToString();

            IsCheckedMainSpecCommand = new DelegateCommand(IsCheckedMainSpec);
            IsCheckedOffSpecCommand = new DelegateCommand(IsCheckedOffSpec);
            AddNewCharacterCommand = new DelegateCommand(o => AddNewCharacter());
            DeleteCharacterCommand = new DelegateCommand(o => DeleteCharacter());
        }



        
        private void IsCheckedMainSpec(object parameter)
        {
            MainSpec = (string)parameter;
        }

        private void IsCheckedOffSpec(object parameter)
        {
            OffSpec = (string)parameter;
        }

        private void AddNewCharacter()
        {
            Console.WriteLine(MainSpec + @" || " + OffSpec);
            Character = new Character(Name, SelectedClass, MainSpec, OffSpec, 2, 2);
            Name = null;
            DatabaseConnectionHandler.Insert(Character);
            DataTable = DatabaseConnectionHandler.GetTable();
        }

        private void DeleteCharacter()
        {
            var data = SelectedCharacterRow.Row.ItemArray as IList<object>;
            SelectedCharacter = new Character(data);
            Console.WriteLine(SelectedCharacter.Id);
            DatabaseConnectionHandler.Delete(SelectedCharacter);
            DataTable = DatabaseConnectionHandler.GetTable();
        }
    }
}
