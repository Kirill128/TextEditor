using ParserWithList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            
        }

        private void Find_Command(object sender, ExecutedRoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(WordToFind.Text)) return;
            LinkedList<WordBox> boxes = TextProccessorViewModel.Find(SelectedTextBox.Document, Regex.Escape( WordToFind.Text));

            //if (cmbFindFontFamily.SelectedItem==null) return;
            //LinkedList<WordBox> boxes = TextProccessorViewModel.Find( SelectedTextBox.Document,(FontFamily)cmbFindFontFamily.SelectedItem);
            SelectFinded(boxes);
        }
        private void Replace_Command(object sender, ExecutedRoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(WordToFind.Text) || String.IsNullOrEmpty(WordToReplace.Text)) return;
            TextProccessorViewModel.Replace(TextProccessorViewModel.Find(SelectedTextBox.Document, WordToFind.Text),WordToReplace.Text);
        }
        private void SelectFinded(LinkedList<WordBox> boxes)
        {
            foreach (WordBox w in boxes)
            {
                w.Range.ApplyPropertyValue(Inline.BackgroundProperty, Brushes.Black);
                w.Range.ApplyPropertyValue(Inline.ForegroundProperty, Brushes.White);
            }
            
        }

        
        #endregion


    }
}
