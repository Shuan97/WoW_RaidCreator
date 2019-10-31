using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WoW_RaidCreator.Models;
using WoW_RaidCreator.ViewModels;
using WoW_RaidCreator.Views;

namespace WoW_RaidCreator.UI_Models
{
    /// <summary>
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public MenuButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SetTextProperty =
            DependencyProperty.Register("SetText", typeof(string), typeof(MenuButton), new
                PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));

        public string SetText
        {
            get => (string)GetValue(SetTextProperty);
            set => SetValue(SetTextProperty, value);
        }

        private static void OnSetTextChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            MenuButton mb = d as MenuButton;
            mb?.OnSetTextChanged(e);
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            LblText.Content = e.NewValue.ToString();
            Console.WriteLine(LblText.Content);
        }
    }
}
