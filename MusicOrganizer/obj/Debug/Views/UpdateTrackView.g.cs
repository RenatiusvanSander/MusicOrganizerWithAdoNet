﻿#pragma checksum "..\..\..\Views\UpdateTrackView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1FCD21EE174EC881DAD5E0C75B449E7F9E47E57D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using MusicOrganizer.Views;
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


namespace MusicOrganizer.Views {
    
    
    /// <summary>
    /// UpdateTrackView
    /// </summary>
    public partial class UpdateTrackView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Views\UpdateTrackView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateTrackButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\UpdateTrackView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addArtistButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\UpdateTrackView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addAlbumButton;
        
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
            System.Uri resourceLocater = new System.Uri("/MusicOrganizer;component/views/updatetrackview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\UpdateTrackView.xaml"
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
            this.updateTrackButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Views\UpdateTrackView.xaml"
            this.updateTrackButton.Click += new System.Windows.RoutedEventHandler(this.UpdateTrackButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.addArtistButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Views\UpdateTrackView.xaml"
            this.addArtistButton.Click += new System.Windows.RoutedEventHandler(this.AddArtistButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.addAlbumButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Views\UpdateTrackView.xaml"
            this.addAlbumButton.Click += new System.Windows.RoutedEventHandler(this.AddAlbumButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

