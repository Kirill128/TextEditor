using System;
using System.Windows;
using System.Windows.Controls;
using TextEditorView.Model;

namespace TextEditorView.View
{
    /// <summary>
    /// Interaction logic for ButtonForFlowDoc.xaml
    /// </summary>
    public partial class ButtonForFlowDoc : UserControl
    {

        public delegate void RoutedEvent (object sender );

        public event RoutedEvent ButtonFileSelectClick;

        public event RoutedEvent ButtonFileCloseClick;
        public FlowDocumentBox FlowDocBox { get; set; }
        public ButtonForFlowDoc(FlowDocumentBox doc)
        {
            InitializeComponent();
            FlowDocBox = doc;

            string[] name = doc.DocumentPathInFileSystem.Split(new char[] { '\\' });
            ButtonFileName.Content = name[name.Length-1];

            FlowDocBox.ButtonToManipulateDoc = this;
        }

        private void ButtonFileName_Click(object sender, RoutedEventArgs e)
        {
            ButtonFileSelectClick?.Invoke(this);
        }

        private void ButtonClose_Click(object sender,RoutedEventArgs e)
        {
            ButtonFileCloseClick?.Invoke(this);
        }
       
    }
}
