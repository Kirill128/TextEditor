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
using System.Text.RegularExpressions;
using TextEditorView.Model;
using TextEditorView.ViewModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ParserWithList;

namespace TextEditorView.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //////////////////////////////////// Inizialisation Data //////////////////////////////////////////////////////////// 
        #region
        private const int lengthOfLeftPanelButtons = 3;
        private ToggleButton[] LeftPanelButtons;// left button with icons 
        /*
         * 0 - Button Folder
         * 1 - Button Settings
         * 2 - Button Proccessor
        */
        private const int lengthOfTopPanelButtons = 1;
        private ToggleButton[] TopPanelButtons;
        /*
          0- Button Special
        */

        private const int lengthOfLeftPanelStack = 3;
        private StackPanel[] AllLeftPanels; //left  panels for left buttons with icons
        /*
         * 0 - Panel for Button Folder
         * 1 - Panel for Button Settings
         * 2 - Panel for Button Proccessor
         */


        private PanelSpecial currentTopControl;
        public PanelSpecial CurrentTopControl {
            get { return currentTopControl; }
            set {
                currentTopControl = value;
                currentTopControl.Visibility = Visibility.Collapsed;
                Grid.SetRow(value, 0);
                MainGrid.Children.Add(currentTopControl);
            }
        }
        // top panels for left buttons with icons
        //  Panel for Button Special
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FlowDocumentsViewModel DocumentsViewModel { get; set; }

        public ObservableCollection<ButtonForFlowDoc> ButtonsFlowDocs { get; set; }

        public TextProccessorViewModel ProccessorViewModel { get; set; }
        
        public TextProccessorOutput ProccessorOutput { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            CurrentTopControl = new PanelSpecial(Text_Container);

            LeftPanelButtons = new ToggleButton[lengthOfLeftPanelButtons] { Button_Folder, Button_Settings, Button_Proccessor };
            TopPanelButtons = new ToggleButton[lengthOfTopPanelButtons] { Button_Special };

            AllLeftPanels = new StackPanel[lengthOfLeftPanelStack] { MakePanelButtonsOpenFileSystem(), MakePanelButtonsSettings() ,MakePanelProccessor() };

            foreach (StackPanel s in AllLeftPanels) {
                LeftWorkPanel.Children.Add(s);
            }

            DocumentsViewModel = new FlowDocumentsViewModel();
            DocumentsViewModel.PropertyChanged += Current_Doc_Changed;
            DocumentsViewModel.FlowDocumentsBoxes.CollectionChanged += Changes_Flow_Docs;

            ButtonsFlowDocs = new ObservableCollection<ButtonForFlowDoc>();
            ButtonsChangeFlowDoc.ItemsSource = ButtonsFlowDocs;

            ProccessorViewModel = new TextProccessorViewModel();

            this.DataContext = DocumentsViewModel;

            File_New_Command(null, null);
            
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region make left panels for left buttons
        public static StackPanel MakePanelButtonsOpenFileSystem() {
            Button New = new Button();
            New.Content = "New";
            New.Command = ApplicationCommands.New;
            New.Background = new SolidColorBrush(Color.FromArgb(0xFA, 0xDA, 0xDA, 0xDA));
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
            Grid.SetColumn(panel, 1);
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
            Button theme = new Button();
            theme.Content = "Theme";
            theme.Background = new SolidColorBrush(Colors.Transparent);
            theme.Foreground = new SolidColorBrush(Colors.Black);

            Button scale = new Button();
            scale.Content = "Scale";
            scale.Background = new SolidColorBrush(Colors.Transparent);
            scale.Foreground = new SolidColorBrush(Colors.Black);

            Button sprawka = new Button();
            sprawka.Content = "About";
            sprawka.Background = new SolidColorBrush(Colors.Transparent);
            sprawka.Foreground = new SolidColorBrush(Colors.Black);

            StackPanel panel = new StackPanel();
            panel.Visibility = Visibility.Collapsed;
            Grid.SetColumn(panel, 1);
            panel.Children.Add(theme);
            panel.Children.Add(scale);
            panel.Children.Add(sprawka);

            return panel;
        }

        public static StackPanel MakePanelProccessor() {
            TextBox textToFind = new TextBox();
            textToFind.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;


            Button find = new Button();
            find.Content = "Find";
            find.Command = ApplicationCommands.Find;
            find.Background = new SolidColorBrush(Colors.Transparent);
            find.Foreground = new SolidColorBrush(Colors.Black);



            StackPanel panel = new StackPanel();
            panel.Visibility = Visibility.Collapsed;
            Grid.SetColumn(panel, 1);
            panel.Children.Add(textToFind);
            panel.Children.Add(find);
           

            return panel;
        }
        #endregion
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        #region doc select change handler                  contain bindign to handlers when select doc or close doc      binding Proccessor selected doc to documentsVM selectedDoc
        private void Changes_Flow_Docs(object sender, NotifyCollectionChangedEventArgs e) {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    ButtonForFlowDoc but = new ButtonForFlowDoc(e.NewItems[0] as FlowDocumentBox);
                    ButtonsFlowDocs.Add(but);
                    but.ButtonFileSelectClick += Button_Doc_SelectChange_EventHandler;           //Binding to select 
                    but.ButtonFileCloseClick += Button_Doc_Close_EventHandler;                  //Binding to close
                    break;
                case NotifyCollectionChangedAction.Remove:
                    ButtonsFlowDocs.Remove((e.OldItems[0] as FlowDocumentBox).ButtonToManipulateDoc);
                    break;
            }
        }
        private void Current_Doc_Changed(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName) {
                case "SelectedDocument":
                    Text_Container.Document = DocumentsViewModel.SelectedDocumentBox.Document;
                    File_Path_Text.Text = DocumentsViewModel.SelectedDocumentBox.DocumentPathInFileSystem;
                    foreach (ButtonForFlowDoc b in ButtonsFlowDocs) b.ButtonFileName.IsChecked = false;
                    DocumentsViewModel.SelectedDocumentBox.ButtonToManipulateDoc.ButtonFileName.IsChecked = true;
                    ProccessorViewModel.SelectedToProccess = DocumentsViewModel.SelectedDocumentBox;
                    break;
                case "FlowDocuments":
                    //Just make all buttons in listbox according to FlowDocs observablecollection and input

                    break;

            }

        }
        #endregion
        // ///////////////////////////////////////// Handlers //////////////////////////////////////////////////////////
        #region icon folder (work with file system) left panel buttons handler

        private void File_New_Command(object sender, ExecutedRoutedEventArgs e)
        {
            DocumentsViewModel.FileNewInCollectionAndWindow();
        }
        private void File_Open_Command(object sender, ExecutedRoutedEventArgs e) // open in selected Rich Text Box Flow Doc
        {
            DocumentsViewModel.FileOpenInCollectionAndWindow();
        }
        private void Save_File_As_Command(object sender, ExecutedRoutedEventArgs e)
        {
            DocumentsViewModel.FileSaveAsCollectionAndWindow();
        }

        private void Save_File_Command(object sender, ExecutedRoutedEventArgs e) {
            DocumentsViewModel.FileSaveInCollectionAndWindow();
        }

        #endregion
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region panel proccessor edit text  handlers
        private void Find_Command(object sender, ExecutedRoutedEventArgs e)
        {
            LinkedList<WordBox> boxes =TextProccessorViewModel.Find(DocumentsViewModel.SelectedDocumentBox,"PATTERN");
            
            foreach (WordBox b in boxes) {
                TextPointer start=DocumentsViewModel.SelectedDocumentBox.Document.ContentStart.GetPositionAtOffset(b.StartInText);
                TextPointer end = DocumentsViewModel.SelectedDocumentBox.Document.ContentStart.GetPositionAtOffset(b.EndInText);
                TextRange word = new TextRange(start,end);
                word.ApplyPropertyValue(Inline.BackgroundProperty,Brushes.Gray);
            }

            //ProccessorOutput = new TextProccessorOutput();

            //ProccessorOutput.TextProccessorBox
        }
        #endregion

        #region work with docs list to select doc ,close doc etc.          if doc close make select first in collection     !!НЕЛЬЗЯ ВО VIEWMODEL ПОТОМУ ЧТО ТОГДА ЭТО БУДЕТ ПРИВЯЗКА К ОПРЕДЕЛЁННОМУ VIEW!! 
        private void Button_Doc_SelectChange_EventHandler(object sender) {
            ButtonForFlowDoc selection = (sender as ButtonForFlowDoc);
            DocumentsViewModel.SelectedDocumentBox = selection.FlowDocBox;
        }
        private void Button_Doc_Close_EventHandler(object sender)/////                  if doc close make select first in collection 
        {
            DocumentsViewModel.FlowDocumentsBoxes.Remove((sender as ButtonForFlowDoc).FlowDocBox);
            if (DocumentsViewModel.FlowDocumentsBoxes.Count > 0)
                DocumentsViewModel.SelectedDocumentBox = DocumentsViewModel.FlowDocumentsBoxes[0];
            else
                File_New_Command(null, null);
        }
        #endregion

        private void Shortcut_Key_Events(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.S)
            {
                Save_File_Command(null, null);
            }
        }


        #region left icons toggle buttons handlers
        private void Button_Folder_Click(object sender, RoutedEventArgs e) {
            HideLeftButtonsAndShowOneLeftPanel(sender, 0, 0);
        }
        private void Button_Settings_Click(object sender, RoutedEventArgs e)
        {
            HideLeftButtonsAndShowOneLeftPanel(sender, 1, 1);
        }
        private void Button_Proccessor_Click(object sender, RoutedEventArgs e)
        {
            HideLeftButtonsAndShowOneLeftPanel(sender, 2, 2);
        }
        private void HideLeftButtonsAndShowOneLeftPanel(object sender, int numOfLeftPanel, int numOfLeftButton) {
            ToggleButton buttonFolder = (ToggleButton)sender;
            if ((bool)buttonFolder.IsChecked)
            {
                foreach (ToggleButton t in LeftPanelButtons)
                {
                    t.IsChecked = false;
                }
                foreach (StackPanel s in AllLeftPanels) {
                    s.Visibility = Visibility.Collapsed;
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
            CurrentTopControl.Visibility = (Button_Special.IsChecked == true) ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion

        
    }


}
