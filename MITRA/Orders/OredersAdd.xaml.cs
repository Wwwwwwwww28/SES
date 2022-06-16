﻿using System;
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
        List<Сотрудник> addsEmpls; 

        private Оборудование machin = new Оборудование();
        private Наряд order;

        public OredersAdd(Наряд order)
        {
            InitializeComponent();
            this.order = order;
            DataContext = machin;
            cmbType.ItemsSource = db_mitraEntities.GetContext().Шаблон.ToList();
            cmbEnv.ItemsSource = db_mitraEntities.GetContext().Оборудование.ToList();
            lbEmpl.ItemsSource = db_mitraEntities.GetContext().Сотрудник.ToList();
            addsEmpls = new List<Сотрудник>();
            if (order == null)
            { s = 0; }
            else
            {
                s = 1;
                
            }
            InitializeUI();
        }

        private void InitializeUI()
        {
            Шаблон x = order.Шаблон;
            cmbType.SelectedItem = x;
            cmbEnv.SelectedItem = order.Оборудование;
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
            try
            {
                Наряд order = new Наряд();
                order.Дата = DateTime.Parse(Calendar.DisplayDate.ToShortDateString());
                order.ID_Оборудования = (cmbEnv.SelectedItem as Оборудование).ID;
                order.ID_Шаблона = (cmbType.SelectedItem as Шаблон).ID;
                order.ID_Состояния = 1;
                order.ID_Исполнителя = 1;

                db_mitraEntities.GetContext().Наряд.Add(order);
                db_mitraEntities.GetContext().SaveChanges();
                for (int i = 0; i < addsEmpls.Count; i++)
                {
                    db_mitraEntities.GetContext().Database.ExecuteSqlCommand("INSERT INTO Наряд_Сотрудник (ID_Наряда, ID_Сотрудника) VALUES (" + order.Номер + ", " + addsEmpls[i].ID + ")");
                }
                MessageBox.Show("Успешно!");

            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void btnAddEmpl_Click(object sender, RoutedEventArgs e)
        {
            if (lbEmpl != null)
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
            var empl = lbEmp2.SelectedItem as Сотрудник;
            addsEmpls.Remove(empl);
            refreshAddsEmlp();
        }
    }
}
