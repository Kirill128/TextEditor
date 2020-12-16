using ParserWithList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using TextEditorView.ViewModel;

namespace TextEditorView.View
{
    /// <summary>
    /// Interaction logic for ProccessorControl.xaml
    /// </summary>
    public partial class ProccessorControl : UserControl
    {
        public RichTextBox SelectedTextBox { get; set; }

        public TextProccessorViewModel ProccessorViewModel { get; set; }
        public ProccessorControl(RichTextBox selectedRtb, TextProccessorViewModel proccessor)
        {
            InitializeComponent();

            SelectedTextBox = selectedRtb;

            ProccessorViewModel = proccessor;

            cmbFindFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbReplaceFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            List<double> l = new List<double>();
            for (int i = 122; i > 0; i--) l.Add(i);
            cmbFindFontSize.ItemsSource = l;
            cmbReplaceFontSize.ItemsSource = l;

        }

        #region proccessor text edit handlers

        private void Show_ProccessorWindow(object sender, RoutedEventArgs e)
        {
            StringBuilder build = new StringBuilder();
            TextPointer end = SelectedTextBox.Document.ContentStart; 
            for (int i=1;end.GetPositionAtOffset(i)!=null;i++) {
                TextRange range = new TextRange(end.GetPositionAtOffset(i-1),end.GetPositionAtOffset(i));
                build.Append(@range.Text);
            }
            MessageBox.Show(@build.ToString());
            
            
        }

        private void Find_Command(object sender, ExecutedRoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(WordToFind.Text)) return;
            //LinkedList<WordBox> boxes = TextProccessorViewModel.Find(SelectedTextBox.Document, WordToFind.Text);
            LinkedList<WordBox> boxes = TextProccessorViewModel.Find((string)cmbFindFontFamily.SelectedItem, SelectedTextBox.Document);
            SelectFindedByString(boxes);


        }
        private void Replace_Command(object sender, ExecutedRoutedEventArgs e)
        {
            
        }
        private void SelectFindedByString(LinkedList<WordBox> boxes)
        {
            

            foreach (WordBox w in boxes)
            {
                TextPointer start = TextProccessorViewModel.GetTextPointerAtOffset(SelectedTextBox.Document, w.StartInText);
                TextPointer end = TextProccessorViewModel.GetTextPointerAtOffset(SelectedTextBox.Document, w.EndInText);
                TextRange word = new TextRange(start, end);
                w.Range = word;
                word.ApplyPropertyValue(Inline.BackgroundProperty, Brushes.Black);
                word.ApplyPropertyValue(Inline.ForegroundProperty, Brushes.White);

            }
            //ProccessorViewModel.LastFindedWordsBoxes = boxes;
            
        }

        #endregion

    }
}
