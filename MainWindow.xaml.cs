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
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections;

using Baseline.ImTools;
using System.Data;
using System.Windows.Controls.Primitives;

namespace WpfApp5
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        List<string> l1;
        string _xmlFile = "C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml";
        string index_xml = "C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile4.xml";
        int count;
        int max1;
        int b = 0;
        string input;
        DataTable _dataTable;
        public MainWindow()
        {
            
            InitializeComponent();

            l1 = new List<string>();
            
            App.Current.Properties["event_type"] = "none";
            App.Current.Properties["venue_selection"] = "none";
            App.Current.Properties["Order_Id"] = "none";
            int max1;
            XDocument xdoc1 = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
            var movieNames = xdoc1.Descendants("Events").Attributes("id").Select(g => g.Value);
            foreach (var name in movieNames)
            {
                {
                    var product1 = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Days")
                   .Single();

                    var product_fname = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("FName")
                   .Single();

                    var product_lname = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("LName")
                   .Single();

                    var product_date = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Date")
                   .Single();

                    string date_picker = product_date.Value.ToString().Split(' ').First();

                    var product_event = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Event_Type")
                   .Single();

                    max1 = 0;
                    count = 0;
                    int str1 = Convert.ToInt32(product1.Value.ToString().Split(' ').Last());
                    while (str1 > 0)
                    {
                        str1 = str1 / 10;
                        count++;
                        
                    }
                    
                    if (count == 1)
                    {
                        input = "00" + product1.Value + "\t"
                            + product_fname.Value + "\t"
                            + product_lname.Value + "\t"
                            + product_event.Value + "\t" + "   "
                            + date_picker + "\t" + " " + name;

                    }
                    else if (count == 2)
                    {
                        input = "0" + product1.Value + "\t"
                            + product_fname.Value + "\t"
                            + product_lname.Value + "\t"
                            + product_event.Value + "\t" + "   "
                            + date_picker + "\t" + " " + name;

                    }
                    else if (count == 3)
                    {
                        input = product1.Value + "\t"
                            + product_fname.Value + "\t"
                            + product_lname.Value + "\t"
                            + product_event.Value + "\t" + "   "
                            + date_picker+ "\t" + " " + name;

                    }
                                        
                    lb3.Items.Add(input);
                    ids.Items.Add(name);
                }
                    
                    
                    
            }
            
            ArrayList list = new ArrayList();
            foreach (var item in lb3.Items)
            {
                list.Add(item);
            }
            list.Sort();
            lb3.Items.Clear();
            foreach (var item in list)
            {
                lb3.Items.Add(item);
            }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selected_id = App.Current.Properties["Order_Id"].ToString();
            if (ids.Items.Contains(selected_id))
            {
                int result = 0;
                for (int x = 0; x <= (Convert.ToDateTime(date.SelectedDate.ToString()) - Convert.ToDateTime(days_left.Content)).TotalDays; x++)
                {
                    result = result + 1;
                }

                string t_event1 = Event_Type_Binding.Content.ToString();

                App.Current.Properties["event_type"] = t_event1;

                XDocument doc_i = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
                var product_dr = doc_i.Descendants("Events").Single(p => p.Attribute("id").Value.Equals(selected_id));
                product_dr.SetElementValue("FName", T1.Text);
                product_dr.SetElementValue("LName", T2.Text);
                product_dr.SetElementValue("Event_Type", t_event1);
                product_dr.SetElementValue("Date", date.SelectedDate.ToString());
                product_dr.SetElementValue("Days", result.ToString());

                doc_i.Save("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");

            }
            else
            {
                if ((T1.Text == string.Empty) | (T2.Text == string.Empty) | (date.SelectedDate.ToString() == string.Empty) | (event_list.SelectedIndex == -1))
                {
                    if (T1.Text == string.Empty)
                    {
                        T1.BorderBrush = Brushes.Red;
                    }
                    if (T2.Text == string.Empty)
                    {
                        T2.BorderBrush = Brushes.Red;
                    }
                    if (date.SelectedDate.ToString() == string.Empty)
                    {
                        date.BorderBrush = Brushes.Red;
                    }
                    if (event_list.SelectedIndex == -1)
                    {
                        event_list.BorderBrush = Brushes.Red;
                    }

                    MessageBox.Show("Select all fields");

                }
                else
                {
                    XDocument xdoc = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
                    XDocument doc_i = XDocument.Load(index_xml);
                    var booking_id = doc_i.Descendants("Bookings").Elements("Booking_ID").Single();
                    int i = Convert.ToInt32(booking_id.Value);
                    int result = 0;
                    string j = "one" + i.ToString();
                    for (int x = 0; x <= (Convert.ToDateTime(date.SelectedDate.ToString()) - Convert.ToDateTime(days_left.Content)).TotalDays; x++)
                    {
                        result = result + 1;
                    }

                    string t_event1 = Event_Type_Binding.Content.ToString();

                    App.Current.Properties["event_type"] = t_event1;

                    int update_counter = i + 1;
                    var counter = doc_i.Descendants("Bookings").Single();
                    counter.SetElementValue("Booking_ID", update_counter);
                    doc_i.Save("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile4.xml");


                    XDocument doc = XDocument.Load(_xmlFile);
                    doc.Root.Add(new XElement("Events",
                        new XAttribute("id", j),
                        new XElement("ID", i),
                        new XElement("FName", T1.Text),
                        new XElement("LName", T2.Text),
                        new XElement("Date", date.SelectedDate.ToString()),
                        new XElement("Event_Type", t_event1),
                        new XElement("Venue", " "),
                        new XElement("Food", " "),
                        new XElement("Guest_No", " "),
                        new XElement("Venue_Cost", " "),
                        new XElement("Cake", " "),
                        new XElement("Days", result.ToString())

                    ));
                    doc.Save(_xmlFile);

                    XDocument doc_dr = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile3.xml");

                    doc_dr.Root.Add(new XElement("Drinks",
                        new XAttribute("id", j),
                        new XElement("A_drinks_count", 0),
                        new XElement("NA_drinks_count", 0)));
                    doc_dr.Save("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile3.xml");

                    XDocument doc_f = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile2.xml");

                    doc_f.Root.Add(new XElement("Food",
                        new XAttribute("id", j),
                        new XElement("V_food_count", 0),
                        new XElement("kid_v_food_count", 0),
                        new XElement("kid_nv_food_count", 0),
                        new XElement("des_count", 0),
                        new XElement("NV_food_count", 0)));
                    doc_f.Save("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile2.xml");

                    var results = doc.Descendants("Product").Select(x => new
                    {
                        ID = x.Element("ID").Value,
                        Name = x.Element("Name").Value,

                    });


                    App.Current.Properties["Order_Id"] = j.ToString();
                    MessageBox.Show("Orders Added");
                    event_list.BorderBrush = Brushes.Black;
                    T1.BorderBrush = Brushes.Black;
                    T2.BorderBrush = Brushes.Black;
                    date.BorderBrush = Brushes.Black;
                    ids.Items.Clear();
                    XDocument xdoc2 = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
                    var ev_id = xdoc2.Descendants("Events").Attributes("id").Select(g => g.Value);
                    foreach (var name in ev_id)
                    {
                        ids.Items.Add(name);
                    }

                }
                
            }
            lb3.Items.Clear();
            XDocument xdoc1 = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
            var movieNames = xdoc1.Descendants("Events").Attributes("id").Select(g => g.Value);
            foreach (var name in movieNames)
            {
                {
                    var product1 = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Days")
                   .Single();
                    count = 0;

                    var product_fname = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("FName")
                   .Single();

                    var product_lname = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("LName")
                   .Single();

                    var product_date = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Date")
                   .Single();

                    string date_picker = product_date.Value.ToString().Split(' ').First();

                    var product_event = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Event_Type")
                   .Single();
                    int str1 = Convert.ToInt32(product1.Value.ToString().Split(' ').Last());
                    while (str1 > 0)
                    {
                        str1 = str1 / 10;
                        count++;
                    }

                    if (count == 1)
                    {
                        input = "00" + product1.Value + "\t"
                            + product_fname.Value + "\t"
                            + product_lname.Value + "\t"
                            + product_event.Value + "\t" + "   "
                            + date_picker + "\t" + " " + name;
                    }
                    else if (count == 2)
                    {
                        input = "0" + product1.Value + "\t"
                            + product_fname.Value + "\t"
                            + product_lname.Value + "\t"
                            + product_event.Value + "\t" + "   "
                            + date_picker + "\t" + " " + name;
                    }
                    else if (count == 3)
                    {
                        input = product1.Value + "\t"
                            + product_fname.Value + "\t"
                            + product_lname.Value + "\t"
                            + product_event.Value + "\t" + "   "
                            + date_picker + "\t" + " " + name;
                    }
                    if (lb3.Items.Contains(input))
                    { }
                    else
                    {
                        lb3.Items.Add(input);
                    }
                }
            }

            ArrayList list = new ArrayList();
            foreach (var item in lb3.Items)
            {
                list.Add(item);
            }
            list.Sort();
            lb3.Items.Clear();
            foreach (var item in list)
            {
                lb3.Items.Add(item);

            }
            T1.Text = string.Empty;
            T2.Text = string.Empty;
            event_list.SelectedIndex = -1;
            date.SelectedDate = Convert.ToDateTime(days_left.Content);
            MessageBox.Show("Saved!");
        }
       
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 w = new Window1();
            w.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                ed.Visibility = Visibility.Visible;
                vd.Margin = new Thickness(59, 354, 0, 0);
                
                string sel_val = lb3.SelectedItem.ToString();
                string str1 = sel_val.ToString().Split(' ').Last();
                MessageBox.Show(str1);
                App.Current.Properties["Order_Id"] = str1;
                
                
                XDocument xdoc = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
                var FName = xdoc.Descendants("Events")
                    .Where(g => g.Attribute("id").Value == str1)
                    .Elements("FName")
                    .Single();
                T1.Text = FName.Value;
                string fname = FName.Value;

                var LName = xdoc.Descendants("Events")
                    .Where(g => g.Attribute("id").Value == str1)
                    .Elements("LName")
                    .Single();
                T2.Text = LName.Value;
                string lname = LName.Value;

                var Date = xdoc.Descendants("Events")
                    .Where(g => g.Attribute("id").Value == str1)
                    .Elements("Date")
                    .Single();
                string date1 = Date.Value;
                date.SelectedDate = Convert.ToDateTime(Date.Value);

                var Days = xdoc.Descendants("Events")
                    .Where(g => g.Attribute("id").Value == str1)
                    .Elements("Days")
                    .Single();
                string days = Days.Value;


                var t_event = xdoc.Descendants("Events")
                    .Where(g => g.Attribute("id").Value == str1)
                    .Elements("Event_Type")
                    .Single();
                string t_event1 = t_event.Value;

                if (t_event1 == "Birthday")
                {
                    event_list.SelectedIndex = event_list.Items.Count - 2;
                    event_list.Focus();
                }
                else
                {
                    event_list.SelectedIndex = event_list.Items.Count - 1;
                    event_list.Focus();
                }

                string result = "Name: " + fname + " " + lname + "\nDate of Event: " + date1.Split(' ').First() + "\nDays: " + days + "\nOccasion: " + t_event1;

                info_orders.Text = result;

                App.Current.Properties["event_type"] = t_event1;
            }
            catch(Exception)
            {
                MessageBox.Show("Select an item fírst");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            XDocument xdoc1 = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
            var movieNames = xdoc1.Descendants("Events").Attributes("id").Select(g => g.Value);
            foreach (var name in movieNames)
            {
                {
                    var product1 = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Days")
                   .Single();
                    count = 0;
                    int str1 = Convert.ToInt32(product1.Value.ToString().Split(' ').Last());
                    while (str1 > 0)
                    {
                        str1 = str1 / 10;
                        count++;

                    }

                    if (count == 1)
                    {
                        input = "00" + product1.Value + " : " + name;

                    }
                    else if (count == 2)
                    {
                        input = "0" + product1.Value + " : " + name;

                    }
                    else if (count == 3)
                    {
                        input = product1.Value + " : " + name;

                    }
                    if(lb3.Items.Contains(input))
                    { }
                    else
                    {
                        lb3.Items.Add(input);
                    }
                    
                }

            }

            ArrayList list = new ArrayList();
            foreach (var item in lb3.Items)
            {
                list.Add(item);
            }
            list.Sort();
            lb3.Items.Clear();
            foreach (var item in list)
            {
                lb3.Items.Add(item);
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string search_string = search_lb.Text.ToLower();
            int lb_count = lb3.Items.Count;
            for(int i = lb_count - 1; i >= 0; i--)
            {
                string filter = lb3.Items.GetItemAt(i).ToString().ToLower();
                if(filter.Contains(search_string))
                {
                    lb3.SelectedIndex = Convert.ToInt32(i);
                    lb3.Focus();
                }
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _dataTable = new DataTable();
            _dataTable.Columns.Add(new DataColumn("Booking ID"));
            _dataTable.Columns.Add(new DataColumn("First_Name"));
            _dataTable.Columns.Add(new DataColumn("Last_Name"));
            _dataTable.Columns.Add(new DataColumn("Event Date"));
            _dataTable.Columns.Add(new DataColumn("Occasion"));
            _dataTable.Columns.Add(new DataColumn("Days_Left"));
            XDocument xdoc1 = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
            var movieNames = xdoc1.Descendants("Events").Attributes("id").Select(g => g.Value);
            foreach (var name in movieNames)
            {
                {
                    var product1 = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Days")
                   .Single();

                    var product_fname = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("FName")
                   .Single();

                    var product_lname = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("LName")
                   .Single();

                    var product_date = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Date")
                   .Single();

                    string date_picker = product_date.Value.ToString().Split(' ').First();

                    var product_event = xdoc1.Descendants("Events")
                   .Where(g => g.Attribute("id").Value == name)
                   .Elements("Event_Type")
                   .Single();

                    _dataTable.Rows.Add(
                        name,
                        product_fname.Value,
                        product_lname.Value,
                        product_date.Value,
                        product_event.Value,
                        product1.Value);
                    dg_view.ItemsSource = _dataTable.DefaultView;
                }
            }


            
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tb1.Text;
            if (string.IsNullOrEmpty(filter))
                _dataTable.DefaultView.RowFilter = null;
            else
                _dataTable.DefaultView.RowFilter = string.Format("First_Name Like '%{0}%' OR Last_Name Like '%{0}%'", filter);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string filter = "khare";
            if (string.IsNullOrEmpty(filter))
                _dataTable.DefaultView.RowFilter = null;
            else
                _dataTable.DefaultView.RowFilter = string.Format("Last_Name Like '%{0}%'", filter);

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(dg_view.ItemsSource);
            view.SortDescriptions.Clear();
            SortDescription sd = new SortDescription("Days_Left", ListSortDirection.Ascending);
            view.SortDescriptions.Add(sd);
           
        }
    }
    
}

/* lb3.Items.Cast<string>().Any(s => Regex.IsMatch(s, search_string))
 * lb3.Items[i].ToString().ToLower().Contains(search_string.ToLower())
 for(int i=lb3.Items.Count-1; i >=0; i--)
*/