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
using System.Windows.Shapes;

namespace MITRA
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        IEnumerable<Сотрудник> element;
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string password = PasswordTB.Password;
            try
            {
                Учётная_запись account = db_mitraEntities.GetContext().Учётная_запись.ToList().Where(x => x.Логин == login && x.Пароль == password).First();
                if(account != null)
                {
                    MainWindow mainWindow = new MainWindow(account);
                    mainWindow.Show();
                    this.Close();
                }
            }

            catch (Exception d)
            {
                MessageBox.Show("" + d.Message.ToString());
                MessageBox.Show("Ошибка авторизации");
            }
                

        }
    }
}
