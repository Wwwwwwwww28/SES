using MITRA.Oreders;
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

namespace MITRA.Plan
{
    /// <summary>
    /// Логика взаимодействия для PlanPage.xaml
    /// </summary>
    /// 

    class test
    {
        public string env { get; set; }
        public DateTime currentDate;


    }
    public partial class PlanPage : Page
    {
        List<Оборудование> ls;
        public PlanPage()
        {
            InitializeComponent();
            DateTime currentTime = DateTime.Now;
            timeLine.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            for (int i = 1; i < 32; i++)
            {
                timeLine.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                TextBlock textBlock = new TextBlock();
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Margin = new Thickness(5);
                textBlock.IsEnabled = false;
                textBlock.Text = currentTime.ToLongDateString();
                timeLine.Children.Add(textBlock);
                Grid.SetColumn(textBlock, i);
                Grid.SetRow(textBlock, 0);
                currentTime = currentTime.AddDays(1);
            }
            kostyl.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            timeLine.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            ls = db_mitraEntities1.GetContext().Оборудование.ToList();
            for (int i = 0; i < ls.Count; i++)
            {
                timeLine.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                kostyl.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                TextBlock textBlock = new TextBlock();
                textBlock.Text = ls[i].Название;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Margin = new Thickness(5);
                textBlock.IsEnabled = false;
                kostyl.Children.Add(textBlock);
                Grid.SetColumn(textBlock, 0);
                Grid.SetRow(textBlock, i + 1);
            }
            DateTime date = DateTime.Now.Date;

           

            for (int i = 0; i < ls.Count; i++)
            {

                for (int j = 1; j < 32; j++)
                {

                    if (getDates(ls[i]).Contains(date.Date))
                    {

                        Button textBox = new Button();
                        textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                        textBox.VerticalAlignment = VerticalAlignment.Stretch;
                        textBox.Margin = new Thickness(5);
                        textBox.IsEnabled = true;
                        Chain chain = new Chain();

                        textBox.Click += TextBox_Click;
                        try
                        {

                            if (ls[i].Наряд.First().Дата.Date == date.Date)
                            {
                                if (ls[i].Наряд.First().ID_Шаблона == 2)
                                    textBox.Background = Brushes.SkyBlue;
                                if (ls[i].Наряд.First().ID_Шаблона == 3)
                                    textBox.Background = Brushes.SkyBlue;
                                
                                chain.order = ls[i].Наряд.First();

                            }
                            else
                            {
                                textBox.Background = Brushes.Gray;
                                chain.date = date.Date;
                                chain.Оборудование = ls[i];
                            }
                        }
                        catch
                        {
                            textBox.Background = Brushes.Gray;
                            chain.date = date.Date;
                            chain.Оборудование = ls[i];
                            
                        }
                        textBox.Tag = chain;
                        timeLine.Children.Add(textBox);
                        Grid.SetRow(textBox, i + 1);
                        Grid.SetColumn(textBox, j);
                        

                    }
                    else { }

                   
                    date = date.AddDays(1);

                }
                date = DateTime.Now.Date;

            }


        }

        private void TextBox_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new OredersAdd(((Button)sender).Tag as Chain));
        }

        private void TextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            
        }

        private List<DateTime> getDates(Оборудование i)
        {
            List<DateTime> datesWithPeriod = new List<DateTime>();
            DateTime d = i.Data;
            int period = i.Тип_оборудования.Периодичность;
            for (int j = 0; j < 365 / period; j++)
            {
                d = d.AddDays(period);
                datesWithPeriod.Add(d.Date);
            }
            try
            {
                datesWithPeriod.Add(i.Наряд.First().Дата);
            }
            catch { }


            return datesWithPeriod;
        }

        private void планDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
        private void edit_pnal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void timeLine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("changet");
        }
    }
}