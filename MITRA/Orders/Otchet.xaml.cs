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

        public Otchet(Учётная_запись account, Наряд order)
        {
            InitializeComponent();
            acc = account;
            this.order = order;
            DataContext = otch;
            InitializeUI();
        }

        private void InitializeUI()
        {
            numOrd.Text = Convert.ToString(order.Номер);
            //lbmat.ItemsSource = db_mitraEntities1.GetContext().Материал.ToList();
        }
    }
}
