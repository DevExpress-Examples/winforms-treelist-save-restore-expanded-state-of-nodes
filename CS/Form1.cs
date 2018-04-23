using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaveLoadExpanded {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        TreeListViewState treeListViewState;

        private void Form1_Load(object sender, System.EventArgs e) {
            new DevExpress.XtraTreeList.Design.XViews(treeList1);
            treeListViewState = new TreeListViewState(treeList1);
        }

        private void btnSave_Click(object sender, System.EventArgs e) {
            treeListViewState.SaveState();
        }

        private void btnLoad_Click(object sender, System.EventArgs e) {
            treeListViewState.LoadState();
        }
    }
}