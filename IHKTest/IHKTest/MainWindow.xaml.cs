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
        Manager manager;
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


           List<Data> data= new Reader().ReadExcel();
           manager = new Manager(data);

           printView(data);
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
         
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var hour = "";
            var dateTime=0;
           

            if (datePicker.Text != "")
            {
               DateTime date = new DateTime(datePicker.SelectedDate.Value.Year, datePicker.SelectedDate.Value.Month, datePicker.SelectedDate.Value.Day);
                dateTime = (int)date.DayOfWeek;
            }

            if (TimePicker.SelectedValue != null)
            {
                hour = TimePicker.SelectedValue.ToString();
                hour = hour.Substring(38, 5);
            }




            listView.Items.Clear();
            printView(manager.getSortedDataList(dateTime, hour));

        }

        private void printView(List<Data> data)
        {
            
            foreach (Data d in data)
            {
                this.listView.Items.Add(d);
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();

            printView(manager.getData());
            TimePicker.SelectedValue = null;
            datePicker.SelectedDate = DateTime.Now;
        }
    }
}
