using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private InspectorsChoice _inspectorsChoice;
        private DefaultConfig _DefaultConfig = new DefaultConfig();

        public PDRForm()
        {
            InitializeComponent();

            _folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            _folderBrowserDialog.ShowNewFolderButton = false;

            _folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            _inspectorsChoice = new InspectorsChoice();

            _imageFileDataTable = new ImageFileDataTable();
            _imageFileDataTable.setInspectorId(ImageFileDataTable.Inspector1);
            Checker1Button.BackColor = Color.Coral;
            Checker2Button.BackColor = DefaultBackColor;

            // 설정파일 로직
            _DefaultConfig.write();
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = _folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ConsoleLabel.Text = _folderBrowserDialog.SelectedPath;
                updateImageFileDataTable(_imageFileDataTable, _folderBrowserDialog.SelectedPath);
                _inspectorsChoice.setSavePath(_folderBrowserDialog.SelectedPath);
                setFirstItemToCurrent();
            }
        }

        private void setConsoleLabel(string text, System.Drawing.Color color)
        {
            ConsoleLabel.ForeColor = color;
            string prefixMessage = $"{_imageFileDataTable.getCurrentIndex()+1}/{_imageFileDataTable.getTotalSize()} ";
            ConsoleLabel.Text = prefixMessage + text;
            Debug.WriteLine(prefixMessage + text);
        }

        private void setFirstItemToCurrent()
        {
            if (_imageFileDataTable.isEmpty())
            {
                setConsoleLabel("불러온 이미지가 없습니다.", Color.Red);
                return;
            }

            renderCurrentImageToPictureBox();
        }

        private void renderCurrentImageToPictureBox()
        {
            FileInfo info = _imageFileDataTable.getCurrentFileInfo();
            string suffix1 = _imageFileDataTable.getCurrentSuffix1();
            string suffix2 = _imageFileDataTable.getCurrentSuffix2();
            renderImageFileToPictureBox(pictureBox, info.FullName);
        }

        private void renderImageFileToPictureBox(PictureBox pictureBox, string imageFilePath)
        {
            Image image = Image.FromFile(imageFilePath);
            pictureBox.Image = image;
            pictureBox.AutoSize = true;
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

        private bool isImageFile(FileInfo info)
        {
            string[] extensions = new string[] {".jpg", ".jpeg", ".png"};
            return extensions.Contains(info.Extension, StringComparer.OrdinalIgnoreCase);
        }

        private bool getSuffixesFromFileName(FileInfo info, out string suffix1, out string suffix2)
        {            
            // 파일 포맷은 001_151126_101489851.png 
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(info.FullName);
            string[] splitedFileName = nameWithoutExtension.Split('_');
            if (splitedFileName.Length < 3)
            {
                suffix1 = "";
                suffix2 = "";
                return false;
            }
            var lastSplitedStringLength = splitedFileName[2].Length;
            suffix1 = splitedFileName[2].Substring(0, lastSplitedStringLength - 1);
            suffix2 = splitedFileName[2].Substring(lastSplitedStringLength - 1, 1);
            return true;
        }

        private bool displayAndCheckImageLoadingState()
        {
            if (_imageFileDataTable.isEmpty())
            {
                setConsoleLabel("불러온 이미지가 없습니다.", Color.Red);
                return false;
            }

            if (_imageFileDataTable.isFirstItem())
            {
                setConsoleLabel(_imageFileDataTable.getCurrentFileInfo().FullName + " 첫번째 이미지입니다.", Color.Blue);
                return false;
            }
            if (_imageFileDataTable.isLastItem())
            {
                setConsoleLabel(_imageFileDataTable.getCurrentFileInfo().FullName + " 마지막 이미지입니다.", Color.Blue);
                return false;
            }

            return true;
        }


        /// <summary>
        /// 선택한 라디오그룹의 Tag 값을 취한다. 
        /// </summary>
        /// <returns></returns> 선택한 값이 없을 경우 -1
        private int getSelectedPDRValue()
        {
            int selectedValue = -1;
            RadioButton selectedButton;
            List<RadioButton> radioButtons = groupBoxDR.Controls.OfType<RadioButton>().ToList();
            foreach (RadioButton rb in radioButtons)
            {
                if (rb.Checked)
                {
                    selectedValue = int.Parse(rb.Tag.ToString());
                    return selectedValue;
                }
            }
            return selectedValue;
        }

        private void saveCurrentChoiceToFile()
        {
            if (_imageFileDataTable.isEmpty())
            {
                setConsoleLabel("선택한 이미지가 없습니다!", Color.Red);
                return;
            }

            string suffix1 = _imageFileDataTable.getCurrentSuffix1();
            string suffix2 = _imageFileDataTable.getCurrentSuffix2();
            int inspectorID = _imageFileDataTable.getInspectorId();
            int selectedPDR = getSelectedPDRValue();

            if (selectedPDR == -1)
            {
                setConsoleLabel("PDR 을 선택하지 않았습니다.", Color.Red);
                return;
            }
            // key 구성 : 이미지파일명의 _ 구분한 3번째 필드값
            string keyFromImageFileNameSuffixes = _inspectorsChoice.makeKey(inspectorID, suffix1, suffix2);

            Debug.WriteLine($"inspector: {inspectorID} key : {keyFromImageFileNameSuffixes}, PDR : {selectedPDR}");

            _inspectorsChoice.put(inspectorID, keyFromImageFileNameSuffixes, selectedPDR);
            _inspectorsChoice.save();
        }

        private void PreviosButton_Click(object sender, EventArgs e)
        {
            saveCurrentChoiceToFile();

            _imageFileDataTable.setPrevious();
            if (!displayAndCheckImageLoadingState())
            {
                return;
            }
            renderCurrentImageToPictureBox();
            setConsoleLabel(_imageFileDataTable.getCurrentFileInfo().FullName, Color.Green);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            saveCurrentChoiceToFile();

            _imageFileDataTable.setNext();
            if (!displayAndCheckImageLoadingState())
            {
                return;
            }
            renderCurrentImageToPictureBox();
            setConsoleLabel(_imageFileDataTable.getCurrentFileInfo().FullName, Color.Green);
        }

        private void Checker1Button_Click(object sender, EventArgs e)
        {
            setConsoleLabel("검사자1 변경 !", Color.Coral);
            _imageFileDataTable.setInspectorId(ImageFileDataTable.Inspector1);
            Checker1Button.BackColor = Color.Coral;
            Checker2Button.BackColor = DefaultBackColor;
        }

        private void Checker2Button_Click(object sender, EventArgs e)
        {
            setConsoleLabel("검사자2 변경 !", Color.Coral);
            _imageFileDataTable.setInspectorId(ImageFileDataTable.Inspector2);
            Checker2Button.BackColor = Color.Coral;
            Checker1Button.BackColor = DefaultBackColor;
        }
    }
}
