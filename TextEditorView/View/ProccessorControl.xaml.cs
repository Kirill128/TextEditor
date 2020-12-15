using ParserWithList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextEditorView.ViewModel;

namespace TextEditorView.View
{
    /// <summary>
    /// Interaction logic for ProccessorControl.xaml
    /// </summary>
    public partial class ProccessorControl : UserControl
    {
        public RichTextBox SelectedTextBox { get; set; }

        public TextProccessorViewModel ProccessorViewModel{ get; set; }
        public ProccessorControl(RichTextBox selectedRtb,TextProccessorViewModel proccessor)
        {
            InitializeComponent();

            SelectedTextBox = selectedRtb;

            ProccessorViewModel = proccessor;
        }

        #region proccessor text edit handlers

        private void Show_ProccessorWindow(object sender, RoutedEventArgs e)
        {



        }

        private void Find_Command(object sender, ExecutedRoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(WordToFind.Text)) return;
            


        }
        private LinkedList<WordBox> SelectFindedByString() {
            LinkedList<WordBox> boxes = TextProccessorViewModel.Find(SelectedTextBox.Document, WordToFind.Text);

            foreach (WordBox w in boxes)
            {
                TextPointer start = TextProccessorViewModel.GetTextPointerAtOffset(SelectedTextBox.Document, w.StartInText);
                TextPointer end = TextProccessorViewModel.GetTextPointerAtOffset(SelectedTextBox.Document, w.EndInText);
                TextRange word = new TextRange(start, end);
                w.Range = word;
                word.ApplyPropertyValue(Inline.BackgroundProperty, Brushes.Black);
                word.ApplyPropertyValue(Inline.ForegroundProperty, Brushes.White);

            }
            ProccessorViewModel.LastFindedWordsBoxes = boxes;
            return boxes;
        }

        #endregion

    }
}
