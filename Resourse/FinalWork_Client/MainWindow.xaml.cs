using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Data;
using FinalWork_Client.Models;

namespace FinalWork_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkingAPI test = new WorkingAPI();

        public MainWindow()
        {
            InitializeComponent();

            listView.MouseDoubleClick +=
                delegate
                {
                    new EditWindow(listView.SelectedIndex).ShowDialog();
                };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listView.DataContext = test.ViewList();
        }
    }
}