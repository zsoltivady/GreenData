﻿#pragma checksum "..\..\..\Paint\Paint.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69CD2CF563F3E5478765233CA1D8DDEEBA4037E8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using elso;


namespace elso {
    
    
    /// <summary>
    /// Paint
    /// </summary>
    public partial class Paint : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal elso.Paint paint;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem save_project;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem save_image;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.InkCanvas rajz;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button select;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button edit;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button undo;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button erase;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle colorbox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider red;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider green;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider blue;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Paint\Paint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider brush;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/elso;component/paint/paint.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Paint\Paint.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.paint = ((elso.Paint)(target));
            
            #line 8 "..\..\..\Paint\Paint.xaml"
            this.paint.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\Paint\Paint.xaml"
            this.paint.Closing += new System.ComponentModel.CancelEventHandler(this.paint_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\..\Paint\Paint.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.open_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.save_project = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\..\Paint\Paint.xaml"
            this.save_project.Click += new System.Windows.RoutedEventHandler(this.save_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.save_image = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\..\Paint\Paint.xaml"
            this.save_image.Click += new System.Windows.RoutedEventHandler(this.save_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 18 "..\..\..\Paint\Paint.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.kilep_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 21 "..\..\..\Paint\Paint.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rajz = ((System.Windows.Controls.InkCanvas)(target));
            
            #line 26 "..\..\..\Paint\Paint.xaml"
            this.rajz.MouseEnter += new System.Windows.Input.MouseEventHandler(this.rajz_MouseEnter);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\Paint\Paint.xaml"
            this.rajz.MouseMove += new System.Windows.Input.MouseEventHandler(this.rajz_MouseMove);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\Paint\Paint.xaml"
            this.rajz.MouseLeave += new System.Windows.Input.MouseEventHandler(this.rajz_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 8:
            this.select = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Paint\Paint.xaml"
            this.select.Click += new System.Windows.RoutedEventHandler(this.select_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.edit = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Paint\Paint.xaml"
            this.edit.Click += new System.Windows.RoutedEventHandler(this.edit_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.undo = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Paint\Paint.xaml"
            this.undo.Click += new System.Windows.RoutedEventHandler(this.undo_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.erase = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Paint\Paint.xaml"
            this.erase.Click += new System.Windows.RoutedEventHandler(this.erase_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.colorbox = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 35 "..\..\..\Paint\Paint.xaml"
            this.colorbox.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.colorbox_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 13:
            this.red = ((System.Windows.Controls.Slider)(target));
            
            #line 37 "..\..\..\Paint\Paint.xaml"
            this.red.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.red_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.green = ((System.Windows.Controls.Slider)(target));
            
            #line 38 "..\..\..\Paint\Paint.xaml"
            this.green.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.green_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.blue = ((System.Windows.Controls.Slider)(target));
            
            #line 39 "..\..\..\Paint\Paint.xaml"
            this.blue.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.blue_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 16:
            this.brush = ((System.Windows.Controls.Slider)(target));
            
            #line 40 "..\..\..\Paint\Paint.xaml"
            this.brush.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.brush_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

