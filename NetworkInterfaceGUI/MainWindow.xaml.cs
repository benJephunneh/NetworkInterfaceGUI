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

namespace NetworkInterfaceGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //textBlock.Text = 
            //textBlock1.Text = 
            //textBlock2.Text = 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock_Initialized(object sender, EventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Window handler, bubbling up");
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Window handler, tunneling down");
        }

        private void rotatedButton_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("rotatedButton handler, bubbling up");
        }

        private void rotatedButton_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("rotatedButton handler, tunneling down");
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Grid handler, bubbling up");
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Grid handler, tunneling down");
            //e.Handled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
