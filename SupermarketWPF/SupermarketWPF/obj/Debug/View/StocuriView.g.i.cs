﻿#pragma checksum "..\..\..\View\StocuriView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C6D53CAE1999BE9CE4AAC1B73822489510443777B53EE172E9F37971EF621240"
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


namespace SupermarketWPF.View {
    
    
    /// <summary>
    /// StocuriView
    /// </summary>
    public partial class StocuriView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\View\StocuriView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProdusId;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\StocuriView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCantitate;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\StocuriView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUnitateDeMasura;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\StocuriView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDataAprovizionarii;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\StocuriView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDataExpirarii;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\StocuriView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPretAchizitie;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\StocuriView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPretDeVanzare;
        
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
            System.Uri resourceLocater = new System.Uri("/SupermarketWPF;component/view/stocuriview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\StocuriView.xaml"
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
            this.txtProdusId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtCantitate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtUnitateDeMasura = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dpDataAprovizionarii = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.dpDataExpirarii = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.txtPretAchizitie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtPretDeVanzare = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 39 "..\..\..\View\StocuriView.xaml"
            ((System.Windows.Controls.DataGrid)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

