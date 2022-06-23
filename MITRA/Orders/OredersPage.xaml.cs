using MITRA.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MITRA.Oreders
{
    /// <summary>
    /// Логика взаимодействия для MachinePage.xaml
    /// </summary>
    public partial class OredersPage : Page
    {
        List<Наряд> gridList;
        private Наряд order = new Наряд();
        Учётная_запись acc = new Учётная_запись();
        public OredersPage(Учётная_запись acc)
        {
            InitializeComponent();
            DataContext = order;
            acc = acc;
            gridList = new List<Наряд>();
            нарядDataGrid.ItemsSource = db_mitraEntities1.GetContext().Наряд.ToList();
            ComboType.ItemsSource = db_mitraEntities1.GetContext().Шаблон.ToList();
            ComboStatus.ItemsSource = db_mitraEntities1.GetContext().Состояние.ToList();
            
        }
        
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = ((TextBox)sender).Text.Replace(new Regex(" *").ToString(), " ");
            
            Filter();
        }
        private void BtnCansel_Click(object sender, RoutedEventArgs e)
        {
            /*оборудованиеDataGrid.ItemsSource = db_mitraEntities.GetContext().Оборудование.ToList();*/
            нарядDataGrid.ItemsSource = db_mitraEntities1.GetContext().Наряд.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new OredersAdd(null, acc));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (нарядDataGrid.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new OredersAdd((нарядDataGrid.SelectedItem as Наряд), acc));
            }
            else
            {
                MessageBox.Show("Выберите наряд!");
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (нарядDataGrid.SelectedItem != null)
            {
                var WorkersForRemoving = нарядDataGrid.SelectedItems.Cast<Наряд>().ToList();
            //    var WorkersForRemoving2 = нарядDataGrid.SelectedItems.Cast<Наряд_Сотрудник>().ToList();
                if (MessageBox.Show($"Вы точно хотите удалить следующее {WorkersForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //  db_mitraEntities.GetContext().Наряд_Сотрудник.RemoveRange(WorkersForRemoving2);
                        db_mitraEntities1.GetContext().Наряд.RemoveRange(WorkersForRemoving);
                        //   db_mitraEntities.GetContext().Наряд_Сотрудник.RemoveRange(WorkersForRemoving2);
                        db_mitraEntities1.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");


                        нарядDataGrid.ItemsSource = db_mitraEntities1.GetContext().Наряд.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите Рабочего!");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           /* if (Visibility == Visibility.Visible)
            {
                db_mitraEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                оборудованиеDataGrid.ItemsSource = db_mitraEntities.GetContext().Оборудование.ToList();
            }*/
        }
        private void ComboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
        private void Filter()
        {
            gridList = db_mitraEntities1.GetContext().Наряд.ToList();
            try
            {
                if(ComboType.SelectedItem != null)
                {
                    var type = ComboType.SelectedItem as Шаблон;
                    gridList = gridList.Where(x => x.ID_Шаблона == type.ID).ToList();
                }
                
            }
            catch { }

            try
            {
                if(ComboStatus.SelectedItem != null)
                {
                    var status = ComboStatus.SelectedItem as Состояние;
                    gridList = gridList.Where(x => x.ID_Состояния == status.ID).ToList();
                }
                
            }
            catch { }
            try
            {
                gridList = gridList.Where(x => x.Оборудование.Название.Contains(Search.Text.ToString())).ToList();
            }
            catch { }
            
            нарядDataGrid.ItemsSource = gridList;
            нарядDataGrid.Items.Refresh();
        }
        private void Search_TextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
        private void Search_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
        private void нарядDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
/*            if (status.ID == 0)
            {
                Console.WriteLine(status.Название);
            }
            if (status.ID == 1)
            {
                Console.WriteLine(status.Название);
            }
            if (status.ID == 2)
            {
                Console.WriteLine(status.Название);
            }*/
        }

        private void нарядDataGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            db_mitraEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            нарядDataGrid.ItemsSource = db_mitraEntities1.GetContext().Наряд.ToList();
        }
    }
}
