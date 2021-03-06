﻿' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace DicomDemo
   Partial Public Class HelpDialog
      Inherits Form
      Public Sub New()
         _serverAE = String.Empty
         InitializeComponent()
      End Sub

      Public Sub New(ByVal serverAE As String, ByVal showHelpCheckBox As Boolean)
         _serverAE = serverAE
         _showHelpCheckBox = showHelpCheckBox

         InitializeComponent()
      End Sub

      Private _showHelpCheckBox As Boolean
      Private _checkBoxNoShowAgainResult As Boolean

      Public Property CheckBoxNoShowAgainResult() As Boolean
         Get
            Return _checkBoxNoShowAgainResult
         End Get
         Set(ByVal value As Boolean)
            _checkBoxNoShowAgainResult = value
         End Set
      End Property
      Private _serverAE As String = String.Empty

      Private Sub ColorText(ByVal text As String, ByVal color As Color)
         _richTextBoxHelp.SelectionColor = color
         _richTextBoxHelp.SelectedText = text
         _richTextBoxHelp.SelectionColor = Color.Black
      End Sub

      Private Sub BoldText(ByVal text As String)
         Dim font As Font = _richTextBoxHelp.SelectionFont
         Dim fontBold As New Font(font.Name, font.Size, FontStyle.Bold)
         _richTextBoxHelp.SelectionFont = fontBold
         _richTextBoxHelp.SelectedText = text
         _richTextBoxHelp.SelectionFont = font
      End Sub

      Private Sub _HelpDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         _pictureBox.Image = System.Drawing.SystemIcons.Information.ToBitmap()

         _richTextBoxHelp.Clear()
         _richTextBoxHelp.SelectionColor = Color.Black
         BoldText("This demo shows how to use the high level Leadtools.Dicom.Scu component to query a DICOM server." & Constants.vbLf + Constants.vbLf + Constants.vbLf)

         ColorText("(Optional but Recommended) ", Color.Blue)

         _richTextBoxHelp.SelectedText = "Run the "
         BoldText("PACS Config Demo")
         Dim sMsg As String = String.Format(" to automatically configure this demo and other client demos to communicate with a DICOM server." & Constants.vbLf + Constants.vbLf)
         _richTextBoxHelp.SelectedText = sMsg

         ColorText("(Optional) ", Color.Blue)

         _richTextBoxHelp.SelectedText = "Click the "
         BoldText("Options")
         sMsg = String.Format(" button to configure this demo to communicate with a DICOM server.  If you already ran the PACS Config Demo, than this demo is already pre-configured to communicate with the DICOM Server service ({0})." & Constants.vbLf + Constants.vbLf, _serverAE)
         _richTextBoxHelp.SelectedText = sMsg

         ColorText("(Required) ", Color.Red)

         sMsg = String.Format("Start CSLeadtools.Dicom.Server.Manager.exe, select the {0} service, and click the ", _serverAE)
         _richTextBoxHelp.SelectedText = sMsg
         BoldText("Start Server")
         _richTextBoxHelp.SelectedText = " button (blue triangle) to start the DICOM service." & Constants.vbLf + Constants.vbLf

         ColorText("(Optional) ", Color.Blue)
         _richTextBoxHelp.SelectedText = "Enter any "
         BoldText("Search Params")
         _richTextBoxHelp.SelectedText = "." & Constants.vbLf + Constants.vbLf

         _richTextBoxHelp.SelectedText = "Click the "
         BoldText("Search")
         _richTextBoxHelp.SelectedText = " button to display the studies found." & Constants.vbLf + Constants.vbLf

         _richTextBoxHelp.SelectedText = "Select a "
         BoldText("Studies Found")
         _richTextBoxHelp.SelectedText = " item to display the series found." & Constants.vbLf + Constants.vbLf

         _richTextBoxHelp.SelectedText = "Double-click a "
         BoldText("Series Found")
         _richTextBoxHelp.SelectedText = " item to display the image(s)."

         _checkBoxNoShowAgain.Visible = _showHelpCheckBox
         buttonOK.Select()
      End Sub

      Private Sub HelpDialog_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
         CheckBoxNoShowAgainResult = _checkBoxNoShowAgain.Checked
      End Sub

   End Class
End Namespace
