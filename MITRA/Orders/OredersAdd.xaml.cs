using MITRA.Dialogs;
using MITRA.Orders;
using MITRA.Plan.Model;
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

namespace MITRA.Oreders
{
    /// <summary>
    /// Логика взаимодействия для MachineAdd.xaml
    /// </summary>
    public partial class OredersAdd : Page
    {
        int s = 0;
        int oldcount;
        List<Сотрудник> addsEmpls;
        Учётная_запись acc;

        private Оборудование machin = new Оборудование();
        Наряд order;

        public OredersAdd(Наряд order)
        {
            InitializeComponent();
            this.order = order;
            acc = acc;
            DataContext = machin;
            cmbType.ItemsSource = db_mitraEntities1.GetContext().Шаблон.ToList();
            cmbEnv.ItemsSource = db_mitraEntities1.GetContext().Оборудование.ToList();
            lbEmpl.ItemsSource = db_mitraEntities1.GetContext().Сотрудник.ToList();
            addsEmpls = new List<Сотрудник>();
            if (order == null)
            { s = 0; }
            else
            {
                StatePart();
                InitializeUI();
                s = 1;

            }
        }
        public OredersAdd(Chain chain)
        {
            InitializeComponent();
            this.order = order;
            acc = acc;
            DataContext = machin;
            cmbType.ItemsSource = db_mitraEntities1.GetContext().Шаблон.ToList();
            cmbEnv.ItemsSource = db_mitraEntities1.GetContext().Оборудование.ToList();
            lbEmpl.ItemsSource = db_mitraEntities1.GetContext().Сотрудник.ToList();
            addsEmpls = new List<Сотрудник>();
            if (chain.order != null)
            {
                cmbEnv.SelectedItem = chain.order.Оборудование;
                cmbType.SelectedItem = chain.order.Шаблон;
                calendar.SelectedDate = chain.order.Дата.Date;
            }
            if(chain.Оборудование != null)
            {
                cmbEnv.SelectedItem = chain.Оборудование;
                cmbType.SelectedItem = db_mitraEntities1.GetContext().Шаблон.Where(x=> x.Название == "ППР");
                calendar.SelectedDate = chain.date.Date;
            }

        }

        private void InitializeUI()
        {
            cmbType.SelectedItem = order.Шаблон;
            cmbEnv.SelectedItem = order.Оборудование;
            btnAdd.Content = "Редактировать";
            Grid.SetColumnSpan(btnAdd, 1);
            btnOtch.Visibility = Visibility.Visible;
            calendar.SelectedDate = order.Дата;
            discTextBox.Text = order.Описание;
            lbEmp2.ItemsSource = db_mitraEntities1.GetContext().Database.SqlQuery<Сотрудник>("SELECT * FROM Сотрудник INNER JOIN Наряд_Сотрудник ON Сотрудник.ID=Наряд_Сотрудник.ID_Сотрудника WHERE Наряд_Сотрудник.ID_Наряда=" + order.Номер).ToList();
            addsEmpls = lbEmp2.ItemsSource as List<Сотрудник>;
            int oldcount = addsEmpls.Count;
        }

        private void StatePart()
        {
            try { 
                int state = order.Состояние.ID;
                Console.WriteLine(order.Состояние);
                if (state == 1)
                {
                    btnOtch.Content = "Начать";
                }
                if (state == 2)
                {
                    btnOtch.Content = "Завершить";
                }
            }
            catch
            { }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void ComboPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            /* int count = addsEmpls.Count;
             try
             {
                 // Наряд order = new Наряд();

                 //order.Дата = System.DateTime.Parse(calendar.DisplayDate.ToShortDateString());
                 //  order.Дата = DateTime.Parse(calendar.SelectedDate.ToString());
                 order.Дата = (DateTime)calendar.SelectedDate;
                 order.ID_Оборудования = (cmbEnv.SelectedItem as Оборудование).ID;
                 order.ID_Шаблона = (cmbType.SelectedItem as Шаблон).ID;
                 order.Описание = (discTextBox.Text);
                 order.ID_Исполнителя = 1;

                 //db_mitraEntities1.GetContext().SaveChanges();
                 if (order.Номер == 0)
                 {
                     order.ID_Состояния = 1;
                     db_mitraEntities1.GetContext().Наряд.Add(order);
                 }
                 db_mitraEntities1.GetContext().Database.ExecuteSqlCommand("DELETE FROM Наряд_Сотрудник WHERE ID_Наряда = " + order.Номер);
                 for (int i = 0; i < count; i++)
                 {
                     db_mitraEntities1.GetContext().Database.ExecuteSqlCommand("INSERT INTO Наряд_Сотрудник (ID_Наряда, ID_Сотрудника) VALUES (" + order.Номер + ", " + addsEmpls[i].ID + ")");
                 }
                 //     db_mitraEntities1.GetContext().Наряд.Add(order);
                 db_mitraEntities1.GetContext().SaveChanges();
                 MessageBox.Show("Успешно!");
                 App.ParentWindowRef.ParentFrame.Navigate(new OredersPage(acc));
             }
             catch
             {
                 Наряд order = new Наряд();
                 try
                 {
                     // Наряд order = new Наряд();

                     //order.Дата = System.DateTime.Parse(calendar.DisplayDate.ToShortDateString());
                     //  order.Дата = DateTime.Parse(calendar.SelectedDate.ToString());
                     order.Дата = (DateTime)calendar.SelectedDate;
                     order.ID_Оборудования = (cmbEnv.SelectedItem as Оборудование).ID;
                     order.ID_Шаблона = (cmbType.SelectedItem as Шаблон).ID;
                     order.Описание = (discTextBox.Text);
                     order.ID_Исполнителя = 1;

                     //db_mitraEntities1.GetContext().SaveChanges();
                     if (order.Номер == 0)
                     {
                         order.ID_Состояния = 1;
                         db_mitraEntities1.GetContext().Наряд.Add(order);
                         for (int i = 0; i < addsEmpls.Count; i++)
                         {
                             db_mitraEntities1.GetContext().Database.ExecuteSqlCommand("INSERT INTO Наряд_Сотрудник (ID_Наряда, ID_Сотрудника) VALUES (" + order.Номер + ", " + addsEmpls[i].ID + ")");
                         }
                     }
                     //     db_mitraEntities1.GetContext().Наряд.Add(order);
                     db_mitraEntities1.GetContext().SaveChanges();
                     MessageBox.Show("Успешно!");
                     App.ParentWindowRef.ParentFrame.Navigate(new OredersPage(acc));
                 }
                 catch
                 {
                     MessageBox.Show("Ошибка!");
                 }
             }*/
            try
            {
                //Наряд order = new Наряд();

                if (order == null)
                {
                    order = new Наряд();
                }
                order.Дата = (DateTime)calendar.SelectedDate;
                order.ID_Оборудования = (cmbEnv.SelectedItem as Оборудование).ID;
                order.ID_Шаблона = (cmbType.SelectedItem as Шаблон).ID;
                order.Описание = (discTextBox.Text);
                order.ID_Состояния = 1;
                order.ID_Исполнителя = 1;

                db_mitraEntities1.GetContext().Наряд.Add(order);
                db_mitraEntities1.GetContext().SaveChanges();
                for (int i = 0; i < addsEmpls.Count; i++)
                {
                    db_mitraEntities1.GetContext().Database.ExecuteSqlCommand("INSERT INTO Наряд_Сотрудник (ID_Наряда, ID_Сотрудника) VALUES (" + order.Номер + ", " + addsEmpls[i].ID + ")");
                }
                MessageBox.Show("Успешно!");
                App.ParentWindowRef.ParentFrame.Navigate(new OredersPage(acc));

            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void btnAddEmpl_Click(object sender, RoutedEventArgs e)
        {
            if (lbEmpl != null && lbEmpl.SelectedItem != null)
            {
                var empl = lbEmpl.SelectedItem as Сотрудник;
                if (!addsEmpls.Contains(empl))
                {
                    addsEmpls.Add(empl);
                    refreshAddsEmlp();
                }
                
            }
        }

        private void refreshAddsEmlp()
        {
            lbEmp2.ItemsSource = addsEmpls;
            lbEmp2.Items.Refresh();
        }

        private void btnRemEmpl_Click(object sender, RoutedEventArgs e)
        {
            if(lbEmp2.SelectedItem != null)
            {
                var empl = lbEmp2.SelectedItem as Сотрудник;
                addsEmpls.Remove(empl);
                refreshAddsEmlp();
            }
        }

        private void btnOtch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (order == null)
                {
                    Наряд order = new Наряд();
                }
               // Наряд order = new Наряд();
                Console.WriteLine(order.Состояние.ID);
                if (order.Состояние.ID == 1)
                {
                    db_mitraEntities1.GetContext().Database.ExecuteSqlCommand("UPDATE Наряд SET ID_Состояния = 2 WHERE Номер = "+ order.Номер);
                    db_mitraEntities1.GetContext().SaveChanges();
                    App.ParentWindowRef.ParentFrame.Navigate(new OredersPage(acc));
                }
                else
                {
                    db_mitraEntities1.GetContext().Database.ExecuteSqlCommand("UPDATE Наряд SET ID_Состояния = 3 WHERE Номер = " + order.Номер);
                    db_mitraEntities1.GetContext().SaveChanges();
                    Used_Materials dialog = new Used_Materials();
                    App.ParentWindowRef.ParentFrame.Navigate(new Otchet(acc, order));
                }
            }
            catch
            { }
        }
    }
}