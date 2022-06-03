using MITRA.Oreders;
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
        
        Учётная_запись account;
        MainWindow parent;
        public MainPage(MainWindow parent, Учётная_запись account)
        {
            InitializeComponent();
            this.account = account;
            this.parent = parent;
            narad.Visibility = Visibility.Collapsed;
            plan.Visibility = Visibility.Collapsed;
            oborudovanie.Visibility = Visibility.Collapsed;
            material.Visibility = Visibility.Collapsed;
            sotrudniki.Visibility = Visibility.Collapsed;
            

            Application.Current.MainWindow.Height = 350;
            switch (account.Сотрудник.Должность.ID)
            {
                case 1:
                        narad.Visibility = Visibility.Visible;
                        plan.Visibility = Visibility.Visible;
                        oborudovanie.Visibility = Visibility.Visible;
                        material.Visibility = Visibility.Visible;
                        sotrudniki.Visibility = Visibility.Visible;
                    break;
                case 2:
                        narad.Visibility = Visibility.Visible;
                    break;
                case 3:
                        material.Visibility = Visibility.Visible;
                    break;
                case 4:
                        plan.Visibility = Visibility.Visible;
                        oborudovanie.Visibility = Visibility.Visible;
                    break;
                case 5:
                    sotrudniki.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void OrderBC(object sender, RoutedEventArgs e)
        {
           
            ((MainWindow)parent).ParentFrame.Navigate(new OredersPage(account));
        }
        private void PlanBC(object sender, RoutedEventArgs e)
        {

        }
        private void MachinewBC(object sender, RoutedEventArgs e)
        {
            //App.ParentWindowRef.ParentFrame.Navigate(new Machin.MachinePage(account));
        }
        private void MaterialBC(object sender, RoutedEventArgs e)
        {

        }
        private void EmployeesBC(object sender, RoutedEventArgs e)
        {

        }
    }
}
