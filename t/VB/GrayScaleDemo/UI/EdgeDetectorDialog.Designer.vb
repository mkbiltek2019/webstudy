﻿
Partial Class EdgeDetectorDialog
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"

   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._cbFilter = New System.Windows.Forms.ComboBox()
      Me._numThreshold = New System.Windows.Forms.NumericUpDown()
      Me._lblFilter = New System.Windows.Forms.Label()
      Me._lblThreshold = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._cbFilter)
      Me._gbOptions.Controls.Add(Me._numThreshold)
      Me._gbOptions.Controls.Add(Me._lblFilter)
      Me._gbOptions.Controls.Add(Me._lblThreshold)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(2, 0)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(273, 76)
      Me._gbOptions.TabIndex = 3
      Me._gbOptions.TabStop = False
      ' 
      ' _cbFilter
      ' 
      Me._cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbFilter.FormattingEnabled = True
      Me._cbFilter.Location = New System.Drawing.Point(86, 45)
      Me._cbFilter.Margin = New System.Windows.Forms.Padding(2)
      Me._cbFilter.Name = "_cbFilter"
      Me._cbFilter.Size = New System.Drawing.Size(174, 21)
      Me._cbFilter.TabIndex = 3
      ' 
      ' _numThreshold
      ' 
      Me._numThreshold.Location = New System.Drawing.Point(86, 15)
      Me._numThreshold.Margin = New System.Windows.Forms.Padding(2)
      Me._numThreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numThreshold.Name = "_numThreshold"
      Me._numThreshold.Size = New System.Drawing.Size(108, 20)
      Me._numThreshold.TabIndex = 1
      ' 
      ' _lblFilter
      ' 
      Me._lblFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblFilter.Location = New System.Drawing.Point(14, 45)
      Me._lblFilter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblFilter.Name = "_lblFilter"
      Me._lblFilter.Size = New System.Drawing.Size(58, 22)
      Me._lblFilter.TabIndex = 2
      Me._lblFilter.Text = "Filter"
      Me._lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _lblThreshold
      ' 
      Me._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblThreshold.Location = New System.Drawing.Point(14, 15)
      Me._lblThreshold.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblThreshold.Name = "_lblThreshold"
      Me._lblThreshold.Size = New System.Drawing.Size(58, 22)
      Me._lblThreshold.TabIndex = 0
      Me._lblThreshold.Text = "Threshold"
      Me._lblThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(290, 38)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 5
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(290, 8)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 4
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' EdgeDetectorDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(365, 84)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "EdgeDetectorDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Edge Detector"
      Me._gbOptions.ResumeLayout(False)
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _cbFilter As System.Windows.Forms.ComboBox
   Private _numThreshold As System.Windows.Forms.NumericUpDown
   Private _lblFilter As System.Windows.Forms.Label
   Private _lblThreshold As System.Windows.Forms.Label
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
End Class