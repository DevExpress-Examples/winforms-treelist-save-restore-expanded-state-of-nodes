Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Namespace SaveLoadExpanded
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private treeListViewState As TreeListViewState

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim TempXViews As DevExpress.XtraTreeList.Design.XViews = New DevExpress.XtraTreeList.Design.XViews(treeList1)
			treeListViewState = New TreeListViewState(treeList1)
		End Sub

		Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
			treeListViewState.SaveState()
		End Sub

		Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
			treeListViewState.LoadState()
		End Sub
	End Class
End Namespace