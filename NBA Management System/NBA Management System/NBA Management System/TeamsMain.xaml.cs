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
    /// Логика взаимодействия для TeamsMain.xaml
    /// </summary>
    public partial class TeamsMain : Page
    {
        public TeamsMain()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                btnAdd.Visibility = Visibility.Visible;
            }
            else
            {
                btnAdd.Visibility = Visibility.Collapsed;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tabItem = TabConrolConf.SelectedItem as TabItem;
            if (tabItem.Header.ToString() == "Западная")
            {
                LViewTeamsWest.ItemsSource = App.Context.Team.ToList().Where(c => c.Division.Conference.Name == "Западная");
            }
            else if (tabItem.Header.ToString() == "Восточная")
            {
                LViewTeamsEast.ItemsSource = App.Context.Team.ToList().Where(c => c.Division.Conference.Name == "Восточная");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddTeam());
            LViewTeamsEast.ItemsSource = App.Context.Team.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var currentTeam = (sender as Button).DataContext as Entites.Team;
            NavigationService.Navigate(new PageAddTeam());

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentTeam1 = (sender as Button).DataContext as Entites.Team;
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.Context.Team.Remove(currentTeam1);
                App.Context.SaveChanges();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = TabConrolConf.SelectedItem as TabItem;
            if (tabItem.Header.ToString() == "Западная")
            {
                LViewTeamsWest.ItemsSource = App.Context.Team.ToList().Where(c => c.Division.Conference.Name == "Западная");
            }
            else if (tabItem.Header.ToString() == "Восточная")
            {
                LViewTeamsEast.ItemsSource = App.Context.Team.ToList().Where(c => c.Division.Conference.Name == "Восточная");
            }
        }
    }
}
