'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.1433
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------


Imports Microsoft.VisualBasic
Imports System

<Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")> _
Partial Friend NotInheritable Class Settings : Inherits Global.System.Configuration.ApplicationSettingsBase

   Private Shared defaultInstance As Settings = (CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings()), Settings))

   Public Shared ReadOnly Property [Default]() As Settings
      Get
         Return defaultInstance
      End Get
   End Property

   <Global.System.Configuration.UserScopedSettingAttribute(), Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.Configuration.DefaultSettingValueAttribute("")> _
   Public Property OcrEngineType() As String
      Get
         Return (CStr(Me("OcrEngineType")))
      End Get
      Set(ByVal value As String)
         Me("OcrEngineType") = value
      End Set
   End Property
End Class