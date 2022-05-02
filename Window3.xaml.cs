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
using System.Xml.Linq;
using System.ComponentModel;
using System.Activities.Expressions;
using FsCheck.Experimental;
using System.Collections;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        List<string> l1;
        public Window3()
        {

            InitializeComponent();
            l1 = new List<string>();
            label2.Content = "";
            XDocument xdoc1 = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");

            var movieNames = xdoc1.Descendants("Events").Attributes("id").Select(g => g.Value);
            foreach (var name in movieNames)
            {

                var product1 = xdoc1.Descendants("Events")
               .Where(g => g.Attribute("id").Value == name)
               .Elements("Days")
               .Single();

                string input = product1.Value;
                string details = name;

                try
                {
                    Show_Orders.Items.Add(input);
                }


                catch (Exception)
                {
                    MessageBox.Show("Refreshed");
                }


            }
            string[] strArray = Show_Orders.Items.Cast<string>().ToArray();
            int[] intArray = strArray.Select(x => int.Parse(x)).ToArray();
            Array.Sort(intArray);
            Show_Orders.Items.Clear();
            foreach (int item in intArray)
            {

                Show_Orders.Items.Add(item);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (Show_Orders.SelectedItems.Count > 0)
            {
                label2.Content = Show_Orders.SelectedItem.ToString();
            }
            try
            {
                label2.Content = Show_Orders.SelectedItem.ToString();
                Label.Content = label2.Content.ToString().Split(' ').Last();
                App.Current.Properties["Order_Id"] = Label.Content.ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Select!");
            }

            XDocument xdoc = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
            var FName = xdoc.Descendants("Events")
               .Where(g => g.Attribute("id").Value == Label.Content.ToString())
               .Elements("FName")
               .Single();
            string fname = FName.Value;

            var LName = xdoc.Descendants("Events")
               .Where(g => g.Attribute("id").Value == Label.Content.ToString())
               .Elements("LName")
               .Single();
            string lname = LName.Value;

            var Date = xdoc.Descendants("Events")
               .Where(g => g.Attribute("id").Value == Label.Content.ToString())
               .Elements("Date")
               .Single();
            string date = Date.Value;

            var Days = xdoc.Descendants("Events")
               .Where(g => g.Attribute("id").Value == Label.Content.ToString())
               .Elements("Days")
               .Single();
            string days = Days.Value;


            var t_event = xdoc.Descendants("Events")
               .Where(g => g.Attribute("id").Value == Label.Content.ToString())
               .Elements("Event_Type")
               .Single();
            string t_event1 = t_event.Value;

            string result = "Name: " + fname + " " + lname + "\nDate of Event: " + date.Split(' ').First() + "\nDays: " + days + "\nOccasion: " + t_event1;
            tb1.Visibility = Visibility.Visible;
            tb1.Text = result;

            App.Current.Properties["event_type"] = t_event1;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            Window1 w = new Window1();
            w.ShowDialog();
        }

        
    }
}
