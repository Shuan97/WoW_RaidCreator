using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WoW_RaidCreator.Commands;
using WoW_RaidCreator.Models;

namespace WoW_RaidCreator.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            this.LoadHomePage();

            // Hook up Commands to associated methods
            this.LoadHomePageCommand = new DelegateCommand(o => this.LoadHomePage());
            this.LoadCharacterPageCommand = new DelegateCommand(o => this.LoadCharacterPage());
        }

        public ICommand LoadHomePageCommand { get; private set; }
        public ICommand LoadCharacterPageCommand { get; private set; }

        // ViewModel that is currently bound to the ContentControl
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                this.OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        private void LoadHomePage()
        {
            CurrentViewModel = new HomePageViewModel(
                new HomePage()
                {
                    PageTitle = "This is the Home Page." ,
                    AuthorInformation = "Made by Shuan"
                });
        }

        private void LoadCharacterPage()
        {
            CurrentViewModel = new CharacterViewModel();
        }
    }
}
