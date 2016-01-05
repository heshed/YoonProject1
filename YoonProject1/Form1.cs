using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoonProject1
{
    public partial class PDRForm : Form
    {
        private FolderBrowserDialog _folderBrowserDialog;
        private ImageFileDataTable _imageFileDataTable = null;

        public PDRForm()
        {
            InitializeComponent();

            this._folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this._folderBrowserDialog.ShowNewFolderButton = false;

            this._folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            this._imageFileDataTable = new ImageFileDataTable();
           
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = _folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedDirectory.Text = _folderBrowserDialog.SelectedPath;
                updateImageFileDataTable(_imageFileDataTable, _folderBrowserDialog.SelectedPath);
                updateImageItemToListView(_imageFileDataTable, imageListView);
            }
        }


        private void renderImageFileToPictureBox(PictureBox pictureBox, string imageFilePath)
        {
            Image image = Image.FromFile(imageFilePath);
        }

        private void updateImageFileDataTable(ImageFileDataTable imageFileDataTable, string selectedPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(selectedPath);
            foreach (FileInfo info in directoryInfo.GetFiles())
            {
                string suffix1, suffix2;
                if (isImageFile(info) && getSuffixesFromFileName(info, out suffix1, out suffix2))
                {
                    imageFileDataTable.addFileInfo(info, suffix1, suffix2);
                }
            }
        }

        private void updateImageItemToListView(ImageFileDataTable imageFileDataTable, ListView listView)
        {
            listView.View = View.List;
            listView.Clear();
            listView.BeginUpdate();
            foreach (DataRow row in _imageFileDataTable.rows())
            {
                FileInfo info = row.Field<FileInfo>(1);
                ListViewItem item = new ListViewItem(info.Name);
                listView.Items.Add(item);
            }
            listView.EndUpdate();
        }

        private bool isImageFile(FileInfo info)
        {
            string[] extensions = new string[] {".jpg", ".jpeg", ".png"};
            return extensions.Contains(info.Extension, StringComparer.OrdinalIgnoreCase);
        }

        private bool getSuffixesFromFileName(FileInfo info, out string suffix1, out string suffix2)
        {            
            // 파일 포맷은 001_151126_101489851.png 
            string[] splitedFileName = info.Name.Split('_');
            if (splitedFileName.Length < 3)
            {
                suffix1 = "";
                suffix2 = "";
                return false;
            }
            var lastSplitedStringLength = splitedFileName[2].Length;
            suffix1 = splitedFileName[2].Substring(lastSplitedStringLength - 1);
            suffix2 = splitedFileName[2].Substring(lastSplitedStringLength - 1, 1);
            return true;
        }
    }
}
