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
    /// Логика взаимодействия для PlayersPage.xaml
    /// </summary>
    public partial class PlayersPage : Page
    {
        Entites.PlayerStatistics playerStatistics;
        Entites.Team team;

        public PlayersPage()
        {
            InitializeComponent();
            dgPlayer.ItemsSource = App.Context.Player.ToList();
            cbTeam.ItemsSource = App.Context.Team.ToList();
            if (App.currentUser != null)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
            else
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddPlayer());
            dgPlayer.ItemsSource = App.Context.PlayerInTeam.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (playerStatistics == null)
            {
                MessageBox.Show("Выбирите игрока для изменения!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                NavigationService.Navigate(new PageAddPlayer());
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Entites.PlayerInTeam playerInTeam = dgPlayer.SelectedItem as Entites.PlayerInTeam;
            if (playerInTeam == null)
            {
                MessageBox.Show("Выбирите игрока для удаления!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                App.Context.Player.Remove(playerInTeam.Player);
                App.Context.SaveChanges();
                dgPlayer.ItemsSource = App.Context.PlayerInTeam.ToList();
            }
        }

        private void tbSearchPlayer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((tbSearchPlayer.Text != null) & team != null)
            {
                dgPlayer.ItemsSource = App.Context.PlayerStatistics.ToList().Where(c => c.Team.TeamId == team.TeamId & c.Player.LastName.Contains(tbSearchPlayer.Text));
            }
            else if (tbSearchPlayer.Text == null)
            {
                dgPlayer.ItemsSource = App.Context.PlayerStatistics.ToList();
            }
        }

        private void cbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            team = (Entites.Team)cbTeam.SelectedItem;
            if (cbTeam.SelectedIndex != -1)
            {
                dgPlayer.ItemsSource = App.Context.PlayerInTeam.ToList().Where(c => c.Team.TeamId == team.TeamId);
            }

        }

        private void dgPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //playerInTeamD = dgPlayer.SelectedItem as Entites.PlayerInTeam;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgPlayer.ItemsSource = App.Context.Player.ToList();
        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            tbSearchPlayer.Clear();
            dgPlayer.ItemsSource = App.Context.PlayerInTeam.ToList();
            cbTeam.SelectedIndex = -1;
        }
    }
}
