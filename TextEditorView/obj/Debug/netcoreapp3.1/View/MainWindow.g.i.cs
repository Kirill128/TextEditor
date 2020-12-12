﻿#pragma checksum "..\..\..\..\View\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BCDD7CC17C83E879C2094211176C5EDE5FBF92E1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TextEditorView.View;


namespace TextEditorView.View {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ButtonsChangeFlowDoc;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox Text_Container;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock File_Path_Text;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LeftWorkPanel;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Button_Folder;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Button_Special;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Button_Settings;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Button_Proccessor;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TextEditorView;V1.0.0.0;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.File_New_Command);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.File_Open_Command);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 13 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Save_File_Command);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 14 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Save_File_As_Command);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 15 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Find_Command);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.ButtonsChangeFlowDoc = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            
            #line 72 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Shortcut_Key_Events);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Text_Container = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 10:
            this.File_Path_Text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.LeftWorkPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.Button_Folder = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 101 "..\..\..\..\View\MainWindow.xaml"
            this.Button_Folder.Click += new System.Windows.RoutedEventHandler(this.Button_Folder_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Button_Special = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 102 "..\..\..\..\View\MainWindow.xaml"
            this.Button_Special.Click += new System.Windows.RoutedEventHandler(this.Button_Special_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Button_Settings = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 103 "..\..\..\..\View\MainWindow.xaml"
            this.Button_Settings.Click += new System.Windows.RoutedEventHandler(this.Button_Settings_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.Button_Proccessor = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 104 "..\..\..\..\View\MainWindow.xaml"
            this.Button_Proccessor.Click += new System.Windows.RoutedEventHandler(this.Button_Proccessor_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

