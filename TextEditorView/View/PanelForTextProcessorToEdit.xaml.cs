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
using TextEditorView.Model;

namespace TextEditorView.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PanelForTextProcessorToEdit : UserControl
    {
        public FlowDocumentBox SelectedDocumentBox { get; set; }
        public PanelForTextProcessorToEdit()
        {
            InitializeComponent();
        }

    }
}
