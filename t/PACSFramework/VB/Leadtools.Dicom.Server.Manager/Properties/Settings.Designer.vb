'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.4927
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Namespace My


    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")> _
    Partial Friend NotInheritable Class Settings
        Inherits System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As Settings = (CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings()), Settings))

        Public Shared ReadOnly Property [Default]() As Settings
            Get
                Return defaultInstance
            End Get
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.Configuration.DefaultSettingValueAttribute("True")> _
        Public Property ShowHelpAgain() As Boolean
            Get
                Return (CBool(Me("ShowHelpAgain")))
            End Get
            Set(ByVal value As Boolean)
                Me("ShowHelpAgain") = value
            End Set
        End Property
    End Class
End Namespace