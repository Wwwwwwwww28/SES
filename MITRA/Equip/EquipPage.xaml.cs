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

namespace MITRA.Equip
{
    /// <summary>
    /// Логика взаимодействия для MachinePage.xaml
    /// </summary>
    public partial class EquipPage : Page
    {
        private Материал equip = new Материал();
        Учётная_запись acc = new Учётная_запись();
        public EquipPage(Учётная_запись account)
        {
            InitializeComponent();
            acc = account;
            DataContext = equip;
            материалDataGrid.ItemsSource = db_mitraEntities.GetContext().Материал.ToList();
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string belfast = Search.Text;
            var biba = db_mitraEntities.GetContext().Материал.Where(x => x.Название.Contains(belfast)).ToList();
            материалDataGrid.ItemsSource = biba;
        }
        private void BtnCansel_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = "";
            материалDataGrid.ItemsSource = db_mitraEntities.GetContext().Материал.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new EquipAdd(null, acc));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (материалDataGrid.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new EquipAdd((материалDataGrid.SelectedItem as Материал), acc));
            }
            else
            {
                MessageBox.Show("Выберите Материал!");
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (материалDataGrid.SelectedItem != null)
            {
                var WorkersForRemoving = материалDataGrid.SelectedItems.Cast<Материал>().ToList();
                if (MessageBox.Show($"Вы точно хотите удалить следующее {WorkersForRemoving.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        db_mitraEntities.GetContext().Материал.RemoveRange(WorkersForRemoving);
                        db_mitraEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");


                        материалDataGrid.ItemsSource = db_mitraEntities.GetContext().Материал.ToList();
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
                материалDataGrid.ItemsSource = db_mitraEntities.GetContext().Материал.ToList();
            }
        }
    }
}
