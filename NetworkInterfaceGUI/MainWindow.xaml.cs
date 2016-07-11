using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            this.Loaded += new RoutedEventHandler(Page_Loaded);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //var oldSettings = new IPStuff();
            {
                var current = new Process();
                current.StartInfo.FileName = "netsh";
                current.StartInfo.Arguments = "interface ip show address \"Ethernet\"";
                //current.StartInfo.Arguments = "interface ip show address \"Local Area Connection\"";
                current.StartInfo.UseShellExecute = false;
                current.StartInfo.RedirectStandardOutput = true;
                current.Start();

                //Wait for the process to finish, then put output stream into a string.
                current.WaitForExit();

                var netshOutput = current.StandardOutput.ReadToEnd().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                //Dim oldSettings As New AddressChange
                //GetCurrentSettings()

                foreach (string line in netshOutput)
                {
                    if (line.Contains("IP Address"))
                    {
                        ExtractAddress(line, IPStuff.oldIP);
                    }
                    else if (line.Contains("mask"))
                    {
                        var index = line.IndexOf("mask") + 4;
                        for (int i = index; i < line.Count() - 1; i++)
                        {
                            if (!line[i].Equals(")"))
                                IPStuff.oldSubnet.Append(line[i]);
                        }
                    }
                    else if (line.Contains("Default Gateway"))
                    {
                        ExtractAddress(line, IPStuff.oldGateway);
                    }
                }
                //if line.Contains("IP Address")
            }
            //this.Page_Loaded.DataContext
        }

        private void ExtractAddress(string line, StringBuilder address)
        {
            int number;
            var index = line.IndexOf(".") - 4;
            if (!int.TryParse(line[index].ToString(), out number))
                index++;

            for (int i = index; i < line.Count() - 1; i++)
            {
                address.Append(line[i]);
            }
        }

        private class IPStuff
        {
            public static StringBuilder oldIP { get; set; }
            public static StringBuilder oldSubnet { get; set; }
            public static StringBuilder oldGateway { get; set; }
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
