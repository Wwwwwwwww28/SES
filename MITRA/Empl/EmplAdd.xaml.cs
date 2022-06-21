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
    /// Логика взаимодействия для MachineAdd.xaml
    /// </summary>
    public partial class EmplAdd : Page
    {
        int s = 0;
        Учётная_запись acc;

        private Сотрудник empl = new Сотрудник();
        public EmplAdd(Сотрудник _selectedEmpl, Учётная_запись acc)
        {
            InitializeComponent();
            s = 0;
            this.acc = acc;
            if (_selectedEmpl != null)
            {
                s = 1;
                empl = _selectedEmpl;
            }
            DataContext = empl;
            ComboPost.ItemsSource = db_mitraEntities.GetContext().Должность.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(empl.ФИО))
                errors.AppendLine("Укажите Название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (empl.ID == 0)
                db_mitraEntities.GetContext().Сотрудник.Add(empl);
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

                App.ParentWindowRef.ParentFrame.Navigate(new EmplPage(acc));
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
