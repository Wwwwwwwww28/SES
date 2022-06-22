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
                textBlock.Text = currentTime.ToLongDateString();
                timeLine.Children.Add(textBlock);
                Grid.SetColumn(textBlock, i);
                Grid.SetRow(textBlock, 0);
                currentTime = currentTime.AddDays(1);
            }
            timeLine.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ls = db_mitraEntities1.GetContext().Оборудование.ToList();
            for (int i = 0; i < ls.Count; i++)
            {
                timeLine.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                TextBlock textBlock = new TextBlock();
                textBlock.Text = ls[i].Название;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Margin = new Thickness(5);
                timeLine.Children.Add(textBlock);
                Grid.SetColumn(textBlock, 0);
                Grid.SetRow(textBlock, i+1);
            }
            DateTime date = DateTime.Now.Date;
           
            for (int i = 0; i < ls.Count; i++)
            {
                for (int j = 1; j < 32; j++)
                {
                    if (getDates(ls[i]).Contains(date.Date))
                    {
                        TextBox textBox = new TextBox();
                        textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                        textBox.VerticalAlignment = VerticalAlignment.Stretch;
                        textBox.Margin = new Thickness(5);
                        try
                        {
                            if(ls[i].Наряд.First().Дата.Date == date.Date)
                            {
                                if(ls[i].Наряд.First().ID_Шаблона == 2)
                                textBox.Background = Brushes.Blue;
                                if(ls[i].Наряд.First().ID_Шаблона == 3)
                                textBox.Background = Brushes.Blue;
                            }
                            else
                            {
                                textBox.Background = Brushes.Gray;
                            }
                        }
                        catch
                        {
                            textBox.Background = Brushes.Gray;
                        }
                        
                        timeLine.Children.Add(textBox);
                        Grid.SetRow(textBox, i+1);
                        Grid.SetColumn(textBox, j);
                        
                    }
                    else { }

                    date = date.AddDays(1);
                   
                }
                date = DateTime.Now.Date;
             //   }
                 //   else { }
            }
            

        }
        private List<DateTime> getDates(Оборудование i)
        {
            List<DateTime> datesWithPeriod2 = new List<DateTime>();
            List<DateTime> datesWithPeriod = new List<DateTime>();
            DateTime d = i.Data;
            int period = i.Тип_оборудования.Периодичность;
            for (int j = 0; j < 365/period; j++)
            {
                d = d.AddDays(period);
                datesWithPeriod.Add(d.Date);
            }
            try
            {
               // datesWithPeriod.Add(i.Наряд.First().Дата);
            }
            catch { }
            return datesWithPeriod;
            // var filteredData = SecretaryEntities5.GetContext().Employees.Local.ToList().Where(x => x.ID_Employee == db.ID);
            /* Наряд n = new Наряд();
             for (int l = 0; l < datesWithPeriod.Count(); l++)
             {
                 var fd = db_mitraEntities.GetContext().Наряд.Local.ToList().Where(x => x.Дата == d);
                 if (datesWithPeriod[l] == d)
                 {
                     datesWithPeriod2.Add(d.Date);
                 }
                 d = d.AddDays(1);*/


            //      if(d == n.Номер)
            //       datesWithPeriod.Add()
        }
            
        
    }
}
