﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                btnBold.CommandTarget = currentTextContainer;
                btnItalic.CommandTarget = currentTextContainer;
                btnUnderline.CommandTarget = currentTextContainer;
            }
                
        }
        public PanelSpecial(RichTextBox rtb)
        {
            InitializeComponent();

            CurrentTextContainer = rtb;

            CurrentTextContainer.SelectionChanged += CurrentTextContainer_SelectionChanged;
            //add font families to combobox
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            List<double> l = new List<double>();
            for (int i = 122; i > 0; i--) l.Add(i);
            cmbFontSize.ItemsSource = l;
           
            string[] col = new string[] { "White","Black", "Green", "Yellow", "Red", "Gray" };
            cmbFontColor.ItemsSource = col;
            cmbFontBackColor.ItemsSource = col;

        }


        #region image paste logic

        private void ButtonImgAdd_Click(object sender, RoutedEventArgs e)
        {
            AddImage();
        }
        public void AddImage()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Png Files (*.png)|*.png|Jpg Files (*.jpg)|*.jpg";
            if (dlg.ShowDialog() == true)
            {
                Uri uri = new Uri(dlg.FileName, UriKind.Relative);
                BitmapImage bitmapImg = new BitmapImage(uri);
                Image image = new Image();
                image.Stretch = Stretch.Fill;
                image.Width = 50;
                image.Height = 50;
                image.Source = bitmapImg;

                BlockUIContainer container = new BlockUIContainer(image);
                CurrentTextContainer.Document.Blocks.Add(container);

                image.Loaded += delegate
                {
                    AdornerLayer al = AdornerLayer.GetAdornerLayer(image);
                    if (al != null)
                    {
                        al.Add(new ResizingAdorner(image));
                    }
                };
            }
        }

        public class ResizingAdorner : Adorner
        {
            // Resizing adorner uses Thumbs for visual elements.   
            // The Thumbs have built-in mouse input handling. 
            Thumb topLeft, topRight, bottomLeft, bottomRight;

            // To store and manage the adorner's visual children. 
            VisualCollection visualChildren;

            // Initialize the ResizingAdorner. 
            public ResizingAdorner(UIElement adornedElement)
                : base(adornedElement)
            {
                visualChildren = new VisualCollection(this);

                // Call a helper method to initialize the Thumbs 
                // with a customized cursors. 
                BuildAdornerCorner(ref topLeft, Cursors.SizeNWSE);
                BuildAdornerCorner(ref topRight, Cursors.SizeNESW);
                BuildAdornerCorner(ref bottomLeft, Cursors.SizeNESW);
                BuildAdornerCorner(ref bottomRight, Cursors.SizeNWSE);

                // Add handlers for resizing. 
                bottomLeft.DragDelta += new DragDeltaEventHandler(HandleBottomLeft);
                bottomRight.DragDelta += new DragDeltaEventHandler(HandleBottomRight);
                topLeft.DragDelta += new DragDeltaEventHandler(HandleTopLeft);
                topRight.DragDelta += new DragDeltaEventHandler(HandleTopRight);
            }

            // Handler for resizing from the bottom-right. 
            void HandleBottomRight(object sender, DragDeltaEventArgs args)
            {
                FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
                Thumb hitThumb = sender as Thumb;

                if (adornedElement == null || hitThumb == null) return;
                FrameworkElement parentElement = adornedElement.Parent as FrameworkElement;

                // Ensure that the Width and Height are properly initialized after the resize. 
                EnforceSize(adornedElement);

                // Change the size by the amount the user drags the mouse, as long as it's larger  
                // than the width or height of an adorner, respectively. 
                adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
                adornedElement.Height = Math.Max(args.VerticalChange + adornedElement.Height, hitThumb.DesiredSize.Height);
            }

            #region handlers for every angle to resize
            // Handler for resizing from the bottom-left. 
            void HandleBottomLeft(object sender, DragDeltaEventArgs args)
            {
                FrameworkElement adornedElement = AdornedElement as FrameworkElement;
                Thumb hitThumb = sender as Thumb;

                if (adornedElement == null || hitThumb == null) return;

                // Ensure that the Width and Height are properly initialized after the resize. 
                EnforceSize(adornedElement);

                // Change the size by the amount the user drags the mouse, as long as it's larger  
                // than the width or height of an adorner, respectively. 
                adornedElement.Width = Math.Max(adornedElement.Width - args.HorizontalChange, hitThumb.DesiredSize.Width);
                adornedElement.Height = Math.Max(args.VerticalChange + adornedElement.Height, hitThumb.DesiredSize.Height);
            }

            // Handler for resizing from the top-right. 
            void HandleTopRight(object sender, DragDeltaEventArgs args)
            {
                FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
                Thumb hitThumb = sender as Thumb;

                if (adornedElement == null || hitThumb == null) return;
                FrameworkElement parentElement = adornedElement.Parent as FrameworkElement;

                // Ensure that the Width and Height are properly initialized after the resize. 
                EnforceSize(adornedElement);

                // Change the size by the amount the user drags the mouse, as long as it's larger  
                // than the width or height of an adorner, respectively. 
                adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
                adornedElement.Height = Math.Max(adornedElement.Height - args.VerticalChange, hitThumb.DesiredSize.Height);
            }

            // Handler for resizing from the top-left. 
            void HandleTopLeft(object sender, DragDeltaEventArgs args)
            {
                FrameworkElement adornedElement = AdornedElement as FrameworkElement;
                Thumb hitThumb = sender as Thumb;

                if (adornedElement == null || hitThumb == null) return;

                // Ensure that the Width and Height are properly initialized after the resize. 
                EnforceSize(adornedElement);

                // Change the size by the amount the user drags the mouse, as long as it's larger  
                // than the width or height of an adorner, respectively. 
                adornedElement.Width = Math.Max(adornedElement.Width - args.HorizontalChange, hitThumb.DesiredSize.Width);
                adornedElement.Height = Math.Max(adornedElement.Height - args.VerticalChange, hitThumb.DesiredSize.Height);
            }
            #endregion

            // Arrange the Adorners. 
            protected override Size ArrangeOverride(Size finalSize)
            {
                // desiredWidth and desiredHeight are the width and height of the element that's being adorned.   
                // These will be used to place the ResizingAdorner at the corners of the adorned element.   
                double desiredWidth = AdornedElement.DesiredSize.Width;
                double desiredHeight = AdornedElement.DesiredSize.Height;
                // adornerWidth & adornerHeight are used for placement as well. 
                double adornerWidth = this.DesiredSize.Width;
                double adornerHeight = this.DesiredSize.Height;

                topLeft.Arrange(new Rect(-adornerWidth / 2, -adornerHeight / 2, adornerWidth, adornerHeight));
                topRight.Arrange(new Rect(desiredWidth - adornerWidth / 2, -adornerHeight / 2, adornerWidth, adornerHeight));
                bottomLeft.Arrange(new Rect(-adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight));
                bottomRight.Arrange(new Rect(desiredWidth - adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight));

                // Return the final size. 
                return finalSize;
            }

            // Helper method to instantiate the corner Thumbs, set the Cursor property,  
            // set some appearance properties, and add the elements to the visual tree. 
            void BuildAdornerCorner(ref Thumb cornerThumb, Cursor customizedCursor)
            {
                if (cornerThumb != null) return;

                cornerThumb = new Thumb();

                // Set some arbitrary visual characteristics. 
                cornerThumb.Cursor = customizedCursor;
                cornerThumb.Height = cornerThumb.Width = 10;
                cornerThumb.Opacity = 0.40;
                cornerThumb.Background = new SolidColorBrush(Colors.MediumBlue);

                visualChildren.Add(cornerThumb);
            }

            // This method ensures that the Widths and Heights are initialized.  Sizing to content produces 
            // Width and Height values of Double.NaN.  Because this Adorner explicitly resizes, the Width and Height 
            // need to be set first.  It also sets the maximum size of the adorned element. 
            void EnforceSize(FrameworkElement adornedElement)
            {
                if (adornedElement.Width.Equals(Double.NaN))
                    adornedElement.Width = adornedElement.DesiredSize.Width;
                if (adornedElement.Height.Equals(Double.NaN))
                    adornedElement.Height = adornedElement.DesiredSize.Height;

                FrameworkElement parent = adornedElement.Parent as FrameworkElement;
                if (parent != null)
                {
                    adornedElement.MaxHeight = parent.ActualHeight;
                    adornedElement.MaxWidth = parent.ActualWidth;
                }
            }
            // Override the VisualChildrenCount and GetVisualChild properties to interface with  
            // the adorner's visual collection. 
            protected override int VisualChildrenCount { get { return visualChildren.Count; } }
            protected override Visual GetVisualChild(int index) { return visualChildren[index]; }
        }
        #endregion

        #region font size and selectionChanged, color change handler
        
        private void CurrentTextContainer_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.FontWeightProperty);
            if (temp != null)btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            
            temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.FontStyleProperty);
            if (temp != null)btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            
            temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            if (temp != null)btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            if (temp != null)cmbFontFamily.SelectedItem = temp;
            temp = CurrentTextContainer.Selection.GetPropertyValue(Inline.FontSizeProperty);
            if (temp != null)cmbFontSize.SelectedItem = temp;
            
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

        private void cmbFontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontColor.SelectedItem != null)
            {
                CurrentTextContainer.Selection.ApplyPropertyValue(Inline.ForegroundProperty, (SolidColorBrush)new BrushConverter().ConvertFromString((string)cmbFontColor.SelectedItem));
            }
            CurrentTextContainer.Focus();
        }

        private void cmbFontBackColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontBackColor.SelectedItem != null)
            {
                CurrentTextContainer.Selection.ApplyPropertyValue(Inline.BackgroundProperty,(SolidColorBrush)new BrushConverter().ConvertFromString((string)cmbFontBackColor.SelectedItem));
            }
            CurrentTextContainer.Focus();
        }
        #endregion


    }

}
