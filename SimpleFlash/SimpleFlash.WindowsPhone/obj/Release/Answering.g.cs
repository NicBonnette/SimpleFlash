﻿

#pragma checksum "C:\Users\Nic\Documents\Visual Studio 2013\Projects\SimpleFlash\SimpleFlash\SimpleFlash.WindowsPhone\Answering.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2CF7D817A28B6CC58559665B5E76819E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleFlash
{
    partial class Answering : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\Answering.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.BackToStart_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 14 "..\..\Answering.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.KnewItButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 15 "..\..\Answering.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.DontKnowButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


