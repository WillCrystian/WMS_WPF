﻿#pragma checksum "..\..\..\..\Screens\CadastrarProduto.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "240F48C0E55BE0472642B3911F6239E006B39035"
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
using WMS_WPF;


namespace WMS_WPF.Screens {
    
    
    /// <summary>
    /// CadastrarProduto
    /// </summary>
    public partial class CadastrarProduto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Screens\CadastrarProduto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_numeroOp;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Screens\CadastrarProduto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_item;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Screens\CadastrarProduto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cadastrarProduto;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Screens\CadastrarProduto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_voltar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WMS_WPF;component/screens/cadastrarproduto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Screens\CadastrarProduto.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Screens\CadastrarProduto.xaml"
            ((System.Windows.Controls.Canvas)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Load);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cb_numeroOp = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txt_item = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\Screens\CadastrarProduto.xaml"
            this.txt_item.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_cadastrarProduto = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Screens\CadastrarProduto.xaml"
            this.btn_cadastrarProduto.Click += new System.Windows.RoutedEventHandler(this.btn_cadastrarProduto_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_voltar = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
