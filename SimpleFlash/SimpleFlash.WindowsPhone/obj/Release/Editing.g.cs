﻿

#pragma checksum "C:\Users\Nic\Documents\Visual Studio 2013\Projects\SimpleFlash\SimpleFlash\SimpleFlash.WindowsPhone\Editing.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "46916EF0B71727D6842DA261E7558895"
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
    partial class Editing : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\Editing.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoToPrevPage_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 14 "..\..\Editing.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.UpdateCard_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


