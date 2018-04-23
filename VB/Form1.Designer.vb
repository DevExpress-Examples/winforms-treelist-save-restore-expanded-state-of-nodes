Imports Microsoft.VisualBasic
Imports System
Namespace SaveLoadExpanded
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
			Me.btnLoad = New DevExpress.XtraEditors.SimpleButton()
			Me.panel1 = New System.Windows.Forms.Panel()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' treeList1
			' 
			Me.treeList1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList1.Location = New System.Drawing.Point(0, 0)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.Size = New System.Drawing.Size(480, 305)
			Me.treeList1.TabIndex = 1
			' 
			' btnSave
			' 
			Me.btnSave.Location = New System.Drawing.Point(20, 7)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New System.Drawing.Size(62, 20)
			Me.btnSave.TabIndex = 0
			Me.btnSave.Text = "Save"
'			Me.btnSave.Click += New System.EventHandler(Me.btnSave_Click);
			' 
			' btnLoad
			' 
			Me.btnLoad.Location = New System.Drawing.Point(107, 7)
			Me.btnLoad.Name = "btnLoad"
			Me.btnLoad.Size = New System.Drawing.Size(62, 20)
			Me.btnLoad.TabIndex = 1
			Me.btnLoad.Text = "Load"
'			Me.btnLoad.Click += New System.EventHandler(Me.btnLoad_Click);
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.btnLoad)
			Me.panel1.Controls.Add(Me.btnSave)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 305)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(480, 35)
			Me.panel1.TabIndex = 2
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(480, 340)
			Me.Controls.Add(Me.treeList1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private treeList1 As DevExpress.XtraTreeList.TreeList
		Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
		Private WithEvents btnLoad As DevExpress.XtraEditors.SimpleButton
		Private panel1 As System.Windows.Forms.Panel

	End Class
End Namespace

