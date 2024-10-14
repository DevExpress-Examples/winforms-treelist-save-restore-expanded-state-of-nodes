Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Nodes.Operations

Namespace SaveLoadExpanded
	Public Class TreeListViewState
		Private expanded As ArrayList
		Private selected As ArrayList
		Private focused As Object
		Private topNode As Object

		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal treeList As TreeList)
			Me.treeList_Renamed = treeList
			expanded = New ArrayList()
			selected = New ArrayList()
		End Sub

		Public Sub Clear()
			expanded.Clear()
			selected.Clear()
			focused = Nothing
			topNode = Nothing
		End Sub
		Private Function GetExpanded() As ArrayList
			Dim op As New OperationSaveExpanded()
			TreeList.NodesIterator.DoOperation(op)
			Return op.Nodes
		End Function
		Private Function GetSelected() As ArrayList
			Dim al As New ArrayList()
			For Each node As TreeListNode In TreeList.Selection
				al.Add(node.GetValue(TreeList.KeyFieldName))
			Next node
			Return al
		End Function

		Public Sub LoadState()
			TreeList.BeginUpdate()
			Try
				TreeList.CollapseAll()
				Dim node As TreeListNode
				For Each key As Object In expanded
					node = TreeList.FindNodeByKeyID(key)
					If node IsNot Nothing Then
						node.Expanded = True
					End If
				Next key
				TreeList.FocusedNode = TreeList.FindNodeByKeyID(focused)
				For Each key As Object In selected
					node = TreeList.FindNodeByKeyID(key)
					If node IsNot Nothing Then
						TreeList.Selection.Add(node)
					End If
				Next key

			Finally
				TreeList.EndUpdate()
				Dim topVisibleNode As TreeListNode = TreeList.FindNodeByKeyID(topNode)
				If topVisibleNode Is Nothing Then
					topVisibleNode = TreeList.FocusedNode
				End If
				TreeList.TopVisibleNodeIndex = TreeList.GetVisibleIndexByNode(topVisibleNode)
			End Try
		End Sub
		Public Sub SaveState()
			If TreeList.FocusedNode IsNot Nothing Then
				expanded = GetExpanded()
				selected = GetSelected()
				focused = TreeList.FocusedNode(TreeList.KeyFieldName)
				topNode = TreeList.GetNodeByVisibleIndex(TreeList.TopVisibleNodeIndex)?(TreeList.KeyFieldName)
			Else
				Clear()
			End If
		End Sub

		Private treeList_Renamed As TreeList
		Public Property TreeList() As TreeList
			Get
				Return treeList_Renamed
			End Get
			Set(ByVal value As TreeList)
				treeList_Renamed = value
				Clear()
			End Set
		End Property

		Private Class OperationSaveExpanded
			Inherits TreeListOperation
			Private al As New ArrayList()
			Public Overrides Sub Execute(ByVal node As TreeListNode)
				If node.HasChildren AndAlso node.Expanded Then
					al.Add(node.GetValue(node.TreeList.KeyFieldName))
				End If
			End Sub
			Public ReadOnly Property Nodes() As ArrayList
				Get
					Return al
				End Get
			End Property
		End Class
	End Class
End Namespace
