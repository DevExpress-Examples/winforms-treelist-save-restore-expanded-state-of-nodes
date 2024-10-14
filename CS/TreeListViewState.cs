using System;
using System.Collections;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace SaveLoadExpanded {
    public class TreeListViewState {
        private ArrayList expanded;
        private ArrayList selected;
        private object focused;
        private object topNode;

        public TreeListViewState() : this(null) { }
        public TreeListViewState(TreeList treeList) {
            this.treeList = treeList;
            expanded = new ArrayList();
            selected = new ArrayList();
        }

        public void Clear() {
            expanded.Clear();
            selected.Clear();
            focused = null;
            topNode = null;
        }
        private ArrayList GetExpanded() {
            OperationSaveExpanded op = new OperationSaveExpanded();
            TreeList.NodesIterator.DoOperation(op);
            return op.Nodes;
        }
        private ArrayList GetSelected() {
            ArrayList al = new ArrayList();
            foreach(TreeListNode node in TreeList.Selection)
                al.Add(node.GetValue(TreeList.KeyFieldName));
            return al;
        }

        public void LoadState() {
            TreeList.BeginUpdate();
            try {
                TreeList.CollapseAll();
                TreeListNode node;
                foreach(object key in expanded) {
                    node = TreeList.FindNodeByKeyID(key);
                    if(node != null)
                        node.Expanded = true;
                }
                TreeList.FocusedNode = TreeList.FindNodeByKeyID(focused);
                foreach(object key in selected) {
                    node = TreeList.FindNodeByKeyID(key);
                    if(node != null)
                        TreeList.Selection.Add(node);
                }
                
            }
            finally {
                TreeList.EndUpdate();
                TreeListNode topVisibleNode = TreeList.FindNodeByKeyID(topNode);
                if(topVisibleNode == null) topVisibleNode = TreeList.FocusedNode;
                TreeList.TopVisibleNodeIndex = TreeList.GetVisibleIndexByNode(topVisibleNode);
            }
        }
        public void SaveState() {
            if(TreeList.FocusedNode != null) {
                expanded = GetExpanded();
                selected = GetSelected();
                focused = TreeList.FocusedNode[TreeList.KeyFieldName];
                topNode = TreeList.GetNodeByVisibleIndex(TreeList.TopVisibleNodeIndex)?[TreeList.KeyFieldName];
            }
            else
                Clear();
        }

        private TreeList treeList;
        public TreeList TreeList {
            get {
                return treeList;
            }
            set {
                treeList = value;
                Clear();
            }
        }

        class OperationSaveExpanded : TreeListOperation {
            private ArrayList al = new ArrayList();
            public override void Execute(TreeListNode node) {
                if(node.HasChildren && node.Expanded)
                    al.Add(node.GetValue(node.TreeList.KeyFieldName));
            }
            public ArrayList Nodes { get { return al; } }
        }
    }
}
