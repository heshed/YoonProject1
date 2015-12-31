using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoonProject1
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog _folderBrowserDialog;

        public Form1()
        {
            InitializeComponent();

            this._folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this._folderBrowserDialog.ShowNewFolderButton = false;

            // Default to the My Documents folder.
            this._folderBrowserDialog.RootFolder = Environment.SpecialFolder.Personal;
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = _folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show(_folderBrowserDialog.SelectedPath);
            }
        }
    }
}
