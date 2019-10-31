using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW_RaidCreator.Models;

namespace WoW_RaidCreator.ViewModels
{
    class MenuPanelViewModel
    {
        public MenuPanel MenuPanel { get; set; }

        public MenuPanelViewModel()
        {
            MenuPanel = new MenuPanel("ELO") {Title = "halo"};
        }
    }
}
