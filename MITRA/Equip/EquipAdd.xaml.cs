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
    /// Логика взаимодействия для MachineAdd.xaml
    /// </summary>
    public partial class EquipAdd : Page
    {
        int s = 0;
        int form;

        private Оборудование machin = new Оборудование();
        public EquipAdd(Оборудование _selectMachine, int _form)
        {
            InitializeComponent();
            s = 0;
            form = _form;
            if (_selectMachine != null)
            {
                s = 1;
                machin = _selectMachine;
            }
            DataContext = machin;
            ComboPost.ItemsSource = db_mitraEntities.GetContext().Тип_оборудования.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(machin.Название))
                errors.AppendLine("Укажите Название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (machin.ID_ТипОборудования == 0)
                db_mitraEntities.GetContext().Оборудование.Add(machin);
            try
            {
                db_mitraEntities.GetContext().SaveChanges();
                if (s == 1)
                {
                    MessageBox.Show("Изменение успешно!");
                }
                else
                {
                    MessageBox.Show("Добавление успешно!");
                }

                App.ParentWindowRef.ParentFrame.Navigate(new EquipPage(form));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void ComboPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
