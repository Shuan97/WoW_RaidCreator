using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WoW_RaidCreator.Annotations;

namespace WoW_RaidCreator.Models
{
    public class MenuPanel
    {
        public string Title { get; set; }

        public MenuPanel(string title)
        {
            Title = title;
        }      
    }
}
