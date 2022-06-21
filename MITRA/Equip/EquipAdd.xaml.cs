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
        Учётная_запись acc;

        private Материал equip = new Материал();
        public EquipAdd(Материал _selectEquip, Учётная_запись acc)
        {
            InitializeComponent();
            s = 0;
            this.acc = acc;
            if (_selectEquip != null)
            {
                s = 1;
                equip = _selectEquip;
            }
            DataContext = equip;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(equip.Название))
                errors.AppendLine("Укажите Название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (equip.ID == 0)
                db_mitraEntities.GetContext().Материал.Add(equip);
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

                App.ParentWindowRef.ParentFrame.Navigate(new EquipPage(acc));
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
