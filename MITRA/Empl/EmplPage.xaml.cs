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
        private Сотрудник equip = new Сотрудник();
        Учётная_запись acc = new Учётная_запись();
        public EmplPage(Учётная_запись account)
        {
            InitializeComponent();
            acc = account;
            DataContext = equip;
            ComboType.ItemsSource = db_mitraEntities.GetContext().Должность.ToList();
        }
        private void ComboPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = ComboType.SelectedItem as Должность;
            var filteredData = db_mitraEntities.GetContext().Сотрудник.Local.ToList().Where(x => x.ID_Должности == db.ID);
            сотрудникDataGrid.ItemsSource = filteredData.Count() > 0 ? filteredData : filteredData.ToArray();
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string belfast = Search.Text;
            var biba = db_mitraEntities.GetContext().Сотрудник.Where(x => x.ФИО.Contains(belfast)).ToList();
            сотрудникDataGrid.ItemsSource = biba;
        }
        private void BtnCansel_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = "";
            сотрудникDataGrid.ItemsSource = db_mitraEntities.GetContext().Сотрудник.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new EmplAdd(null, acc));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (сотрудникDataGrid.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new EmplAdd((сотрудникDataGrid.SelectedItem as Сотрудник), acc));
            }
            else
            {
                MessageBox.Show("Выберите Сотрудника!");
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (сотрудникDataGrid.SelectedItem != null)
            {
                var WorkersForRemoving = сотрудникDataGrid.SelectedItems.Cast<Сотрудник>().ToList();
                if (MessageBox.Show($"Вы точно хотите удалить следующее {WorkersForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        db_mitraEntities.GetContext().Сотрудник.RemoveRange(WorkersForRemoving);
                        db_mitraEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");


                        сотрудникDataGrid.ItemsSource = db_mitraEntities.GetContext().Сотрудник.ToList();
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
                сотрудникDataGrid.ItemsSource = db_mitraEntities.GetContext().Сотрудник.ToList();
            }
        }
    }
}
