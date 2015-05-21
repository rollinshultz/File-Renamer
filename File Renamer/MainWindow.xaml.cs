using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileRenamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClearTextBoxes();
        }
        
        FileHandlerClass fileHandler = new FileHandlerClass();
        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnChangeFilenames_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (fileHandler.directory != null)
                {
                    fileHandler.ChangeFilename();            
                }
                else
                {
                    System.Windows.MessageBox.Show("Please select a directory");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void GetDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            fileHandler.GetDirectory();
        }

        private void btnGetFiles_Click(object sender, RoutedEventArgs e)
        {
            fileHandler.GetFiles();
        }

        private void txtPrefix_LostFocus(object sender, RoutedEventArgs e)
        {
            fileHandler.Prefix = txtPrefix.Text;
        }

        private void txtRemove_LostFocus(object sender, RoutedEventArgs e)
        {
            fileHandler.TextToRemove = txtRemove.Text;
        }

        private void txtNewExtension_LostFocus(object sender, RoutedEventArgs e)
        {
            fileHandler.NewExtension = txtNewExtension.Text;
        }
        private void txtOldExtension_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtOldExtension.Text != String.Empty)
            {
            fileHandler.OldExtension = txtOldExtension.Text;
            }
            else
            {   String message = "If a file extension is not provided, all files in the directory will be selected \n"
                 + "If you wish to continue select Yes, if you wish to enter an extension select NO;" ;
                String caption = "caution";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxResult result =  System.Windows.MessageBox.Show(message, caption, buttons);
                if (result.ToString() == "No") 
                {
                    txtOldExtension.Focus();
                }
            }

                
        }

        private void btnChangeExtension_Click(object sender, RoutedEventArgs e)
        {
            if (fileHandler.directory != String.Empty)
            {
                fileHandler.ChangeExtension();
            }
        }

        private void txtNewExtension_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNewExtension.Text = "";
        }

        private void txtOldExtension_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOldExtension.Text = "";
        }

        private void btnInstructions_Click(object sender, RoutedEventArgs e)
        {
            //InstructionsPage page = new InstructionsPage();
            wndInstructions inst = new wndInstructions();
            inst.ShowDialog();
        }

        private void txtSuffix_LostFocus(object sender, RoutedEventArgs e)
        {
            fileHandler.Suffix = txtSuffix.Text;
        }

        private void txtReplace_LostFocus(object sender, RoutedEventArgs e)
        {
            fileHandler.TextToReplace = txtReplace.Text;
        }

        public void ClearTextBoxes()
        {
            txtPrefix.Clear();
            txtRemove.Clear();
            txtReplace.Clear();
            txtSuffix.Clear();
            txtOldExtension.Clear();
            txtNewExtension.Clear();
        }
    }
}
