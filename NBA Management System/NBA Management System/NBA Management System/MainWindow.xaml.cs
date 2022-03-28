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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Window1 work = new Window1();
            work.Show();
            this.Close();
        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            Window1 work = new Window1();
            work.Show();
            this.Close();
        }
    }
}
