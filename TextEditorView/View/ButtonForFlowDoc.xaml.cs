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

namespace TextEditorView.View
{
    /// <summary>
    /// Interaction logic for ButtonForFlowDoc.xaml
    /// </summary>
    public partial class ButtonForFlowDoc : UserControl
    {
        public FlowDocument FlowDoc { get; set; }
        public ButtonForFlowDoc(FlowDocument doc)
        {
            InitializeComponent();
        }

    }
}
