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

namespace MITRA.Machin
{
    /// <summary>
    /// Логика взаимодействия для MachineAdd.xaml
    /// </summary>
    public partial class MachineAdd : Page
    {
        int s = 0;
        Учётная_запись acc;

        private Оборудование machin = new Оборудование();
        public MachineAdd(Оборудование _selectMachine, Учётная_запись acc)
        {
            InitializeComponent();
            s = 0;
            this.acc = acc;
            if (_selectMachine != null)
            {
                s = 1;
                machin = _selectMachine;
            }
            DataContext = machin;
            ComboPost.ItemsSource = db_mitraEntities1.GetContext().Тип_оборудования.ToList();
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
                db_mitraEntities1.GetContext().Оборудование.Add(machin);
            try
            {
                db_mitraEntities1.GetContext().SaveChanges();
                if (s == 1)
                {
                    MessageBox.Show("Изменение успешно!");
                }
                else
                {
                    MessageBox.Show("Добавление успешно!");
                }

                App.ParentWindowRef.ParentFrame.Navigate(new MachinePage(acc));
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
