using MITRA.Main;
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

namespace MITRA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Учётная_запись account = new Учётная_запись();
        public MainWindow(Учётная_запись account)
        {
            InitializeComponent();
            BtnHome.Visibility = Visibility.Hidden;
            this.account = account;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef = this;
            this.ParentFrame.Navigate(new MainPage(this, account));
        }

        private void ParentFrame_ContentRendered(object sender, EventArgs e)
        {
            ParentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            if (ParentFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new MainPage(this, account));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.GoBack();
        }
    }
}
