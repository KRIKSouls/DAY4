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

namespace NBA_Management_System
{
    /// <summary>
    /// Логика взаимодействия для VisitorMenu.xaml
    /// </summary>
    public partial class VisitorMenu : Page
    {
        public VisitorMenu()
        {
            InitializeComponent();
        }

        private void btnTeams_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamsMain());
        }

        private void btnPlayers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlayersPage());
        }
    }
}
