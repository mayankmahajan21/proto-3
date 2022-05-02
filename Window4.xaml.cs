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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        List<string> l1;
        public Window4()
        {
            InitializeComponent();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            l1 = new List<string>();
            if (lb1.SelectedItems.Count > 0)
            {
                MessageBox.Show(lb1.SelectedItem.ToString());
                l1.Add(lb1.SelectedItem.ToString());
                lb3.Items.Add(lb1.SelectedItem.ToString());
                lb1.SelectedItem = null;

            }
            else if (lb2.SelectedItems.Count > 0)
            {
                
                MessageBox.Show(lb2.SelectedItem.ToString());
                l1.Add(lb2.SelectedItem.ToString());
                lb3.Items.Add(lb2.SelectedItem.ToString());
                lb2.SelectedItem = null;

            }
            
        }
        /*
        private void show(object sender, RoutedEventArgs e)
        {
            XDocument xdoc = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");

            var movieNames = xdoc.Descendants("Events").Attributes("id").Select(g => g.Value);
            foreach (var name in movieNames)
            {

                var product1 = xdoc.Descendants("Events")
               .Where(g => g.Attribute("id").Value == name)
               .Elements("Days")
               .Single();
                string input = name + ": " + product1.Value;

                if (lb3.Items.Contains(input))
                {
                    MessageBox.Show("This name already exists!");
                }
                else
                {
                    l1.Add(input);
                    lb3.ItemsSource = l1;
                }


            }

        }

        
        private void Del_Click(object sender, RoutedEventArgs e)
        {


            XDocument xdoc = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
            var product = xdoc.Descendants("Product").FirstOrDefault(p => p.Attribute("id").Value.Equals("one1"));
            product.Remove();
            xdoc.Save("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            XDocument xdoc = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
            var product = xdoc.Descendants("Events")
                .Where(g => g.Attribute("id").Value == "one1")
                .Elements("FName")
                .Single();
            T1.Text = product.Value;

            var product1 = xdoc.Descendants("Events")
                .Where(g => g.Attribute("id").Value == "one1")
                .Elements("LName")
                .Single();
            T2.Text = product1.Value;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string e_id = lb3.SelectedItem.ToString();
            XDocument xdoc = XDocument.Load("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
            var product = xdoc.Descendants("Events").Single(p => p.Attribute("id").Value.Equals(e_id));
            product.SetElementValue("Guest_No", "100");

            xdoc.Save("C:/Users/mayan/source/repos/WpfApp5/WpfApp5/XMLFile1.xml");
            MessageBox.Show("Updated");

        }
        */
    }
}
