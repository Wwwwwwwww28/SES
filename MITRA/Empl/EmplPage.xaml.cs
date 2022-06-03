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

namespace MITRA.Empl
{
    /// <summary>
    /// Логика взаимодействия для MachinePage.xaml
    /// </summary>
    public partial class EmplPage : Page
    {
        int form;
        private Оборудование worker = new Оборудование();
        public EmplPage(int _form)
        {
            form = _form;
            if (form == 0)
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnDel.Visibility = Visibility.Hidden;
            }
            DataContext = worker;
            оборудованиеDataGrid.ItemsSource = db_mitraEntities.GetContext().Оборудование.ToList();
            ComboType.ItemsSource = db_mitraEntities.GetContext().Тип_оборудования.ToList();
        }
        private void ComboPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = ComboType.SelectedItem as Тип_оборудования;
            var filteredData = db_mitraEntities.GetContext().Оборудование.Local.ToList().Where(x => x.ID_ТипОборудования == db.ID);
            оборудованиеDataGrid.ItemsSource = filteredData.Count() > 0 ? filteredData : filteredData.ToArray();
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string belfast = Search.Text;
            var biba = db_mitraEntities.GetContext().Оборудование.Where(x => x.Название.Contains(belfast)).ToList();
            оборудованиеDataGrid.ItemsSource = biba;
        }
        private void BtnCansel_Click(object sender, RoutedEventArgs e)
        {
            оборудованиеDataGrid.ItemsSource = db_mitraEntities.GetContext().Оборудование.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new EmplAdd(null, form));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (оборудованиеDataGrid.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new EmplAdd((оборудованиеDataGrid.SelectedItem as Оборудование), form));
            }
            else
            {
                MessageBox.Show("Выберите Сотрудника!");
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (оборудованиеDataGrid.SelectedItem != null)
            {
                var WorkersForRemoving = оборудованиеDataGrid.SelectedItems.Cast<Оборудование>().ToList();
                if (MessageBox.Show($"Вы точно хотите удалить следующее {WorkersForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        db_mitraEntities.GetContext().Оборудование.RemoveRange(WorkersForRemoving);
                        db_mitraEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");


                        оборудованиеDataGrid.ItemsSource = db_mitraEntities.GetContext().Оборудование.ToList();
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
            if (Visibility == Visibility.Visible)
            {
                db_mitraEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                оборудованиеDataGrid.ItemsSource = db_mitraEntities.GetContext().Оборудование.ToList();
            }
        }
    }
}
