using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW_RaidCreator.Models;

namespace WoW_RaidCreator.ViewModels
{
    class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(HomePage homePage)
        {
            this.HomePage = homePage;
        }

        public HomePage HomePage { get; private set; }

        public string PageTitle
        {
            get => this.HomePage.PageTitle;
            set
            {
                this.HomePage.PageTitle = value;
                this.OnPropertyChanged(nameof(PageTitle));
            }
        }

        public string AuthorInformation
        {
            get => this.HomePage.AuthorInformation;
            set
            {
                this.HomePage.AuthorInformation = value;
                this.OnPropertyChanged(nameof(AuthorInformation));
            }
        }
    }
}
