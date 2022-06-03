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
    class test
    {
        public string env { get; set; }
        public DateTime currentDate;
        public string test1
        {
            get
            {
                check();
                if (dates.Contains(currentDate))
                {
                    
                    return "True";
                }
                else
                {

                    return "False";
                };
            }
            set
            {
                test1 = value;
            }
        }
        public test setDate(DateTime date)
        {
            currentDate = date;
            return this;
        }
        public void funk()
        {
            check();
            if (dates.Contains(currentDate))
            {
                this.test1 = "True";
            }
            else
            {
                this.test1 = "False";
            }
        }
        public int pos;
        public int period;
        public DateTime bedinDate;
        
        private List<DateTime> dates = new List<DateTime>();
        
        private string check()
        {
            DateTime date1 = bedinDate;
            for (int i = 0; i < 365/period; i++)
            {
                try
                {
                    dates.Add(date1.AddDays(period));
                    date1 = date1.AddDays(period);
                }
                catch { }
            }
            return "";
        }
    }
    public partial class PlanPage : Page
    {
        public PlanPage()
        {
            InitializeComponent();
            var currentdate = DateTime.Today.Date;
            var column1 = new DataGridTextColumn()
            {
                Header = "Оборудование",
                Binding = new Binding("env")
            };
            var obj = db_mitraEntities.GetContext().Оборудование.ToList();
            

            планDataGrid.Columns.Add(column1);
            List<test> list = new List<test>();

            
            List<DateTime> currentDates = new List<DateTime>();
            for (int i = 0; i < 30; i++)
            {
                currentdate = currentdate.AddDays(1);
                try
                {
                    Console.WriteLine("" + obj[i].Тип_оборудования.План.First().Периодичность);
                    планDataGrid.Items.Add(new test { env = obj[i].Название, bedinDate = obj[i].Тип_оборудования.План.First().Data, period = obj[i].Тип_оборудования.План.First().Периодичность, pos = i, currentDate = currentdate });
                    
                }
                catch { 
                }

                var column = new DataGridTextColumn()
                {
                    Header = currentdate.ToLongDateString(),
                    Binding = new Binding("test1")
                };
                планDataGrid.Columns.Add(column);
                
            }

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void планDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }
    }
}
