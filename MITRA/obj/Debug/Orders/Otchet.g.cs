﻿#pragma checksum "..\..\..\Orders\Otchet.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4942D23F8B92CCBA8D5BAC5F0DDD90586FAA7F2A2621E3C6E685839F162124CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MITRA.Orders;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace MITRA.Orders {
    
    
    /// <summary>
    /// Otchet
    /// </summary>
    public partial class Otchet : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Orders\Otchet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock numOrd;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Orders\Otchet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_materials;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Orders\Otchet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_wasted;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Orders\Otchet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add_material;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Orders\Otchet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lv_used_materials;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Orders\Otchet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox discTextBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Orders\Otchet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTrue;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Orders\Otchet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFalse;
        
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
            System.Uri resourceLocater = new System.Uri("/MITRA;component/orders/otchet.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Orders\Otchet.xaml"
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
            this.numOrd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.cmb_materials = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txt_wasted = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btn_add_material = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Orders\Otchet.xaml"
            this.btn_add_material.Click += new System.Windows.RoutedEventHandler(this.btn_add_material_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lv_used_materials = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.discTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnTrue = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\Orders\Otchet.xaml"
            this.btnTrue.Click += new System.Windows.RoutedEventHandler(this.btnTrue_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnFalse = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\Orders\Otchet.xaml"
            this.btnFalse.Click += new System.Windows.RoutedEventHandler(this.btnFalse_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

