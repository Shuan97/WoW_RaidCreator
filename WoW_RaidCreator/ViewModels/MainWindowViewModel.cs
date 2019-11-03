using System.Windows.Input;
using WoW_RaidCreator.Commands;
using WoW_RaidCreator.Models;

namespace WoW_RaidCreator.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        // ViewModel that is currently bound to the ContentControl
        private ViewModelBase _currentViewModel;

        public ICommand LoadHomePageCommand { get; }
        public ICommand LoadCharacterPageCommand { get; }

        public MainWindowViewModel()
        {
            LoadCharacterPage();
            //LoadHomePage();

            LoadHomePageCommand = new DelegateCommand(o => LoadHomePage());
            LoadCharacterPageCommand = new DelegateCommand(o => LoadCharacterPage());
        }
        
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        private void LoadHomePage()
        {
            CurrentViewModel = new HomePageViewModel(
                new HomePage
                {
                    PageTitle = "This is the Home Page.",
                    AuthorInformation = "Made by Shuan"
                });
        }

        private void LoadCharacterPage()
        {
            CurrentViewModel = new CharacterViewModel();
        }
    }
}