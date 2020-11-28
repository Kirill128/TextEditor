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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextEditorView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int lengthOfLeftPanelButtons=2;
        private ToggleButton[] LeftPanelButtons;// left button with icons 
        /*
         * 0 - Button Folder
         * 1 - Button Settings
        */
        private const int lengthOfTopPanelButtons = 1;
        private ToggleButton[] TopPanelButtons;
        /*
          0- Button Special
        */

        private const int lengthOfLeftPanelStack = 2;
        private StackPanel[] AllLeftPanels; //left  panels for left buttons with icons
        /*
         * 0 - Panel for Button Folder
         * 1 - Panel for Button Settings
         */

        private const int lengthOfTopPanelGrid = 1;
        private Grid[] AllTopPanels; // top panels for left buttons with icons
        /*
         * 0 - Panle for Button Special
        */

        public MainWindow()
        {
            InitializeComponent();
            LeftPanelButtons = new ToggleButton[lengthOfLeftPanelButtons] { Button_Folder, Button_Settings };
            TopPanelButtons = new ToggleButton[lengthOfTopPanelButtons] { Button_Special };

            AllLeftPanels = new StackPanel[lengthOfLeftPanelStack] { MakePanelButtonsOpenFileSystem(), MakePanelButtonsSettings() };
            AllTopPanels = new Grid[lengthOfTopPanelGrid] { MakeGridForTopOnButtonSpecial() };

            foreach (StackPanel s in AllLeftPanels) {
                LeftWorkPanel.Children.Add(s);
            } 
        }

        #region make left panels for left buttons
        public static StackPanel MakePanelButtonsOpenFileSystem() {
            Button New = new Button();
            New.Content ="New";
            New.Command = ApplicationCommands.New;
            New.Background = new SolidColorBrush(Color.FromArgb(0xFA,0xDA,0xDA,0xDA));
            New.Foreground = new SolidColorBrush(Colors.Black);

            Button Open_File = new Button();
            Open_File.Content = "Open File";
            Open_File.Command = ApplicationCommands.Open;
            Open_File.Background = new SolidColorBrush(Color.FromArgb(0xFA, 0xDA, 0xDA, 0xDA));
            Open_File.Foreground = new SolidColorBrush(Colors.Black);

            Button Save_File = new Button();
            Save_File.Content = "Save File";
            Save_File.Command = ApplicationCommands.Save;
            Save_File.Background = new SolidColorBrush(Color.FromArgb(0xFA, 0xDA, 0xDA, 0xDA));
            Save_File.Foreground = new SolidColorBrush(Colors.Black);

            Button Save_File_As = new Button();
            Save_File_As.Content = "Save File As";
            Save_File_As.Command = ApplicationCommands.SaveAs;
            Save_File_As.Background = new SolidColorBrush(Color.FromArgb(0xFA, 0xDA, 0xDA, 0xDA));
            Save_File_As.Foreground = new SolidColorBrush(Colors.Black);


            StackPanel panel = new StackPanel();
            panel.Visibility = Visibility.Collapsed;
            Grid.SetColumn(panel,1);
            panel.Children.Add(New);
            panel.Children.Add(Open_File);
            panel.Children.Add(Save_File);
            panel.Children.Add(Save_File_As);

            return panel;
            
        }
        /*
                     <StackPanel x:Name="Button_Folder_Content_Panel" Grid.Column="1" Visibility="Collapsed">
                          <Button Content="New"           Command="ApplicationCommands.New"    Background="#fadadada" Foreground="Black"/>
                          <Button Content="Open File"     Command="ApplicationCommands.Open"   Background="#fadadada" Foreground="Black"/>
                          <Button Content="Save File"     Command="ApplicationCommands.Save"   Background="#fadadada" Foreground="Black"/>
                          <Button Content="Save File As"  Command="ApplicationCommands.SaveAs" Background="#fadadada" Foreground="Black"/>
                      </StackPanel>
         */
        public static StackPanel MakePanelButtonsSettings() {
            return new StackPanel();
        }
        #endregion
        
        #region make top panel for left button special
        public static Grid MakeGridForTopOnButtonSpecial() {
            return new Grid();
        }
        #endregion

        #region file work
        private void FileNew()
        {
            File_Path_Text.Text = "";
            TextRange doc = new TextRange(Text_Container.Document.ContentStart, Text_Container.Document.ContentEnd);
            doc.Text = "";
        }
        private void FileOpen()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                TextRange doc = new TextRange(Text_Container.Document.ContentStart, Text_Container.Document.ContentEnd);
                File_Path_Text.Text = dlg.FileName;
                using (FileStream fs = new FileStream(dlg.FileName, FileMode.Open))
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

        private void SaveFile()
        {
            if (File_Path_Text.Text == "")
            {
                SaveFileAs();
            }
            else
            {
                TextRange doc = new TextRange(Text_Container.Document.ContentStart, Text_Container.Document.ContentEnd);
                using (FileStream fs = new FileStream(File_Path_Text.Text, FileMode.Create))
                {
                    if (System.IO.Path.GetExtension(File_Path_Text.Text).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(File_Path_Text.Text).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        private void SaveFileAs()
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
        #endregion

        #region icon folder left panel buttons handler
        private void File_New_Command(object sender, ExecutedRoutedEventArgs e)
        {
            FileNew();
        }
        private void File_Open_Command(object sender, ExecutedRoutedEventArgs e)
        {
            FileOpen();
        }
        private void Save_File_As_Command(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileAs();
        }

        private void Save_File_Command(object sender, ExecutedRoutedEventArgs e) {
            SaveFile();
        }
        #endregion

        private void Shortcut_Key_Events(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.S)
            {
                SaveFile();
            }
        }


        #region left icons toggle buttons handlers
        private void Button_Folder_Click(object sender, RoutedEventArgs e) {
            HideLeftButtonsAndShowOneLeftPanel(sender,0,0);
        }
        private void Button_Settings_Click(object sender, RoutedEventArgs e)
        {
            HideLeftButtonsAndShowOneLeftPanel(sender,1,1);
        }
        private void HideLeftButtonsAndShowOneLeftPanel(object sender,int numOfLeftPanel,int numOfLeftButton) {
            ToggleButton buttonFolder = (ToggleButton)sender;
            if ((bool)buttonFolder.IsChecked)
            {
                foreach (ToggleButton t in LeftPanelButtons)
                {
                    t.IsChecked = false;
                }
                LeftPanelButtons[numOfLeftButton].IsChecked = true;
                AllLeftPanels[numOfLeftPanel].Visibility = Visibility.Visible;
            }
            else
            {
                AllLeftPanels[numOfLeftPanel].Visibility = Visibility.Collapsed;
            }
        }
        private void Button_Special_Click(object sender, RoutedEventArgs e)
        {
            TopSpecialGrid.Visibility = ((bool)((ToggleButton)sender).IsChecked ? Visibility.Visible : Visibility.Collapsed);


        }

        #endregion
    }


}
