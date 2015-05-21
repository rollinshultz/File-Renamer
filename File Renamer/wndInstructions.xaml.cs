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
using System.IO;

namespace FileRenamer
{
    /// <summary>
    /// Interaction logic for wndInstructions.xaml
    /// </summary>
    public partial class wndInstructions : Window
    {
        public wndInstructions()
        {
            InitializeComponent();
            //FileHandlerClass filehandler = new FileHandlerClass();
            
            //using(StreamReader stream = new StreamReader(@"Instructions.txt"))
            //{
            //    ctlDocViewer.InputScope = Convert.ChangeType(StreamReader stream.ReadToEnd(), );
            //}
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
