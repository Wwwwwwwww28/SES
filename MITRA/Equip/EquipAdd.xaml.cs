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

        private Материал equip = new Материал();
        public EquipAdd(Материал _selectEquip, int _form)
        {
            InitializeComponent();
            s = 0;
            form = _form;
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
            try
            {
                string name;
                int quantity;

                name = txtMatName.Text;
                quantity = Int32.Parse(txtMatQuant.Text);

                db_mitraEntities.GetContext().Материал.Add(new Материал() { Название = name, Кол_во = quantity });
                db_mitraEntities.GetContext().SaveChanges();
                MessageBox.Show("Добавление успешно!");


                //db_mitraEntities.GetContext().SaveChanges();


                ////App.ParentWindowRef.ParentFrame.Navigate(new EquipPage(form));
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
