﻿#pragma checksum "..\..\..\Regisztracio\Window1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "17D2F1DA13A91EA92E9C02052F77DC739CA2BF90FBB4B43476A4C07644452488"
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


namespace elso {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Regisztracio\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label information_label;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Regisztracio\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Username;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Regisztracio\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwd;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Regisztracio\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmaiL;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Regisztracio\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegistratioN;
        
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
            System.Uri resourceLocater = new System.Uri("/elso;component/regisztracio/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Regisztracio\Window1.xaml"
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
            
            #line 12 "..\..\..\Regisztracio\Window1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Button);
            
            #line default
            #line hidden
            return;
            case 2:
            this.information_label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Username = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\Regisztracio\Window1.xaml"
            this.Username.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Information_TextBox_Username);
            
            #line default
            #line hidden
            return;
            case 4:
            this.passwd = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.EmaiL = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\Regisztracio\Window1.xaml"
            this.EmaiL.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Information_TextBox_Email);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RegistratioN = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Regisztracio\Window1.xaml"
            this.RegistratioN.Click += new System.Windows.RoutedEventHandler(this.Registration_Button);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

