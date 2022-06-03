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

namespace MITRA.Main
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        int form;
        public MainPage(int _form)
        {
            InitializeComponent();
            Application.Current.MainWindow.Height = 350;
            form = _form;
        }

        private void OrderBC(object sender, RoutedEventArgs e)
        {
//            App.ParentWindowRef.ParentFrame.Navigate(new (form));
        }
        private void PlanBC(object sender, RoutedEventArgs e)
        {

        }
        private void MachinewBC(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new Machin.MachinePage(form));
        }
        private void MaterialBC(object sender, RoutedEventArgs e)
        {

        }
        private void EmployeesBC(object sender, RoutedEventArgs e)
        {

        }
    }
}
