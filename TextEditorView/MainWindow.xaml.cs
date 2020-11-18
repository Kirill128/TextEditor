using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextEditorView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }
        private void File_New(object sender, ExecutedRoutedEventArgs e) {
            File_Path_Text.Text = "";

        }
         private void File_Open(object sender, ExecutedRoutedEventArgs e)
         {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                TextRange doc = new TextRange(Text_Container.Document.ContentStart, Text_Container.Document.ContentEnd);
                File_Path_Text.Text = dlg.FileName;
                using (FileStream fs = new FileStream(dlg.FileName,FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(dlg.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(dlg.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);

                }
            }
         }

        private void Save_File_As(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(Text_Container.Document.ContentStart, Text_Container.Document.ContentEnd);
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        private void Save_File(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void Button_Folder_Click(object sender, RoutedEventArgs e) {
            Button_Folder_Content_Panel.Visibility = (bool)((ToggleButton)sender).IsChecked ? Visibility.Visible : Visibility.Collapsed;
        }
        
        private void Button_Special_Click(object sender, RoutedEventArgs e)
        {
            Button_Special_Grid_Content.Visibility=((bool)((ToggleButton)sender).IsChecked ? Visibility.Visible : Visibility.Collapsed);
        }

        private void Button_Settings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_About_Click(object sender, RoutedEventArgs e)
        {

        }
    }
   
    
}
