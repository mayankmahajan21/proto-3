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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string Event_1 = Application.Current.Properties["event_type"].ToString();
        List<string> l1;
        public Window2()
        {
            
        }
        private void DataBinding()
        {
            lb3.ItemsSource = null;
            lb3.ItemsSource = l1;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(lb1.SelectedItems.Count > 0)
            {
                l1.Add(lb1.SelectedItem.ToString());
                lb3.ItemsSource = l1;
                DataBinding();
            }
            else if (lb2.SelectedItems.Count > 0)
            {
                l1.Add(lb1.SelectedItem.ToString());
                lb3.ItemsSource = l1;
                DataBinding();
            }
        }
    }

   }
