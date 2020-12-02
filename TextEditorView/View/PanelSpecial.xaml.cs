using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for PanelSpecial.xaml
    /// </summary>
    public partial class PanelSpecial : UserControl
    {
        private RichTextBox currentTextContainer;
        public RichTextBox CurrentTextContainer {
            get { return currentTextContainer; }
            set {
                currentTextContainer = value;
                
            }
                
        }
        public PanelSpecial(RichTextBox rtb)
        {
            InitializeComponent();

            CurrentTextContainer = rtb;

            CurrentTextContainer.SelectionChanged += CurrentTextContainer_SelectionChanged;

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            List<double> l = new List<double>();
            for (int i = 122; i > 0; i--) l.Add(i);
            cmbFontSize.ItemsSource = l;
            
        }

        private void CurrentTextContainer_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;
            temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.SelectedItem = temp;
        }


        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
            {
                CurrentTextContainer.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
            CurrentTextContainer.Focus();
        }

        private void cmbFontSize_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontSize.SelectedItem != null)
            {
                CurrentTextContainer.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.SelectedItem);
            }
            CurrentTextContainer.Focus();
        }


    }

}
