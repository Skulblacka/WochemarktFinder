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

namespace IHKTest
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Initialize
            this.InitializeComponent();

            // Add columns
            var gridView = new GridView();
            this.listView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Bezirk",
                DisplayMemberBinding = new Binding("Bezirk")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Marktort",
                DisplayMemberBinding = new Binding("Marktort")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Tage",
                DisplayMemberBinding = new Binding("Tage")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Zeiten",
                DisplayMemberBinding = new Binding("Zeiten")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Betreiber",
                DisplayMemberBinding = new Binding("Betreiber")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "EMail",
                DisplayMemberBinding = new Binding("EMail")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "WWW",
                DisplayMemberBinding = new Binding("WWW")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Bemerkungen",
                DisplayMemberBinding = new Binding("Bemerkungen")
            });


            //     public String Bezirk { get; set; }
            //public String Marktort { get; set; }
            //public String Tage { get; set; }
            //public String Zeiten { get; set; }
            //public String Betreiber { get; set; }
            //public String EMail { get; set; }
            //public String WWW { get; set; }
            //public String Bemerkungen { get; set; }

            // List<Data> data = new List<Data>();


            //Data data = new Data { Betreiber = "12487", Marktort = "Trödelmarkt" };
            //Data data1 = new Data { Betreiber = "12487", Marktort = "Arödelmarkt" };

            //Populate list
            //this.listView.Items.Add(data);
            //this.listView.Items.Add(data1);
            string path = "C:\\Users\\user\\Desktop\\Wochenmaerkte.xls";
           List<Data> data= new Reader().ReadExcel();

            foreach (Data d in data)
            {
                this.listView.Items.Add(d);
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            DateTime date = new DateTime(datePicker.SelectedDate.Value.Year, datePicker.SelectedDate.Value.Month, datePicker.SelectedDate.Value.Day);
            
            Console.WriteLine((int)date.DayOfWeek);//ohne cast = Name vom Tag
        }
    }
}
