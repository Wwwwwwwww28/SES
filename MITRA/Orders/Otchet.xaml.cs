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

namespace MITRA.Orders
{
    /// <summary>
    /// Логика взаимодействия для Otchet.xaml
    /// </summary>
    public partial class Otchet : Page
    {
        private Отчёт otch = new Отчёт();
        Наряд order;
        Учётная_запись acc = new Учётная_запись();
        private int isCompleted;
        Материал selected_mat;
        List<Материал> selected_mats;
        List<string> wastes;

        public Otchet(Учётная_запись account, Наряд order)
        {
            InitializeComponent();
            acc = account;
            this.order = order;
            DataContext = otch;
            InitializeComponent();
            cmb_materials.ItemsSource = db_mitraEntities1.GetContext().Материал.ToList();
            InitializeUI();
        }

        private void InitializeUI()
        {
            numOrd.Text = Convert.ToString(order.Номер);
            //lbmat.ItemsSource = db_mitraEntities1.GetContext().Материал.ToList();
        }

        private void btn_add_material_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_materials.SelectedItem != null && txt_wasted.Text != "")
            {
                selected_mat = cmb_materials.SelectedItem as Материал;
                selected_mats = new List<Материал>();
                wastes = new List<string>();
                selected_mats.Add(selected_mat);
                wastes.Add(txt_wasted.Text);
                lv_used_materials.Items.Add(selected_mat.Название.ToString() + " – " + txt_wasted.Text.ToString());
            }
        }

        private void btnTrue_Click(object sender, RoutedEventArgs e)
        {
            isCompleted = 1;
            db_mitraEntities1.GetContext().Отчёт.Add(new Отчёт {
                Номер_Наряда = order.Номер,
                Дата = DateTime.Now,
                Описание = discTextBox.Text,
                Результат = isCompleted });

            db_mitraEntities1.GetContext().SaveChanges();
            MessageBox.Show("Отчёт успешно сформирован!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnFalse_Click(object sender, RoutedEventArgs e)
        {
            isCompleted = 0;
            db_mitraEntities1.GetContext().Отчёт.Add(new Отчёт
            {
                Номер_Наряда = order.Номер,
                Дата = DateTime.Now,
                Описание = discTextBox.Text,
                Результат = isCompleted
            });

            var last_otchet = db_mitraEntities1.GetContext().Отчёт.ToList();

            for (int i = 0; i < selected_mats.Count; i++)
            {
                db_mitraEntities1.GetContext().Расход.Add(new Расход
                {
                    ID_Отчёта = last_otchet[last_otchet.Count - 1].ID,
                    ID_Материала = selected_mats[i].ID,
                    Кол_во = Int32.Parse(wastes[i])

                });
                db_mitraEntities1.GetContext().SaveChanges();
            }

            MessageBox.Show("Отчёт успешно сформирован!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
