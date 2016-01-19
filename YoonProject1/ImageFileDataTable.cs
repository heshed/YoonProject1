using System.Data;
using System.Diagnostics;
using System.IO;

namespace YoonProject1
{
    internal class ImageFileDataTable
    {
        public const int Inspector1 = 1;
        public const int Inspector2 = 2;
        private FileInfo _currentFileInfo;
        private int _currentIndex;
        private string _currentSuffix1;
        private string _currentSuffix2;

        private readonly DataTable _dataTable;
        private string _directoryPath;
        private int _inspectorId = Inspector1;


        public ImageFileDataTable()
        {
            _dataTable = new DataTable();
            _dataTable.Columns.Add("fileInfo", typeof (FileInfo));
            _dataTable.Columns.Add("fileNameSuffix1", typeof (string));
            _dataTable.Columns.Add("fileNameSuffix2", typeof (string));
        }

        public string getDirectoryPath()
        {
            return _directoryPath;
        }

        public void setInspectorId(int id)
        {
            _inspectorId = id;
        }

        public int getInspectorId()
        {
            return _inspectorId;
        }

        public void setPrevious()
        {
            if (_currentIndex <= 0)
            {
                return;
            }
            _currentIndex--;
            setCurrentDataWithIndex(_currentIndex);
        }

        public void setNext()
        {
            if (_currentIndex >= _dataTable.Rows.Count - 1)
            {
                return;
            }
            _currentIndex++;
            setCurrentDataWithIndex(_currentIndex);
        }

        private void setCurrentDataWithIndex(int index)
        {
            var row = _dataTable.Rows[_currentIndex];
            _currentFileInfo = row.Field<FileInfo>(0);
            _currentSuffix1 = row.Field<string>(1);
            _currentSuffix2 = row.Field<string>(2);
        }

        public void setCurrentIndex(int index)
        {
            _currentIndex = index;
        }

        public int getCurrentIndex()
        {
            return _currentIndex;
        }

        public bool isLastItem()
        {
            return _currentIndex == _dataTable.Rows.Count - 1;
        }

        public bool isFirstItem()
        {
            return _currentIndex == 0;
        }

        public bool isEmpty()
        {
            return _dataTable.Rows.Count == 0;
        }

        public void initialize(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void clear()
        {
            _directoryPath = null;
            _currentIndex = 0;
            _dataTable.Clear();
        }

        public int getTotalSize()
        {
            return _dataTable.Rows.Count;
        }

        public void addFileInfo(FileInfo fileInfo, string suffix1, string suffix2)
        {
            // 최초 입력일 경우 current 에 셋팅한다.
            if (_dataTable.Rows.Count == 0)
            {
                _currentFileInfo = fileInfo;
                _currentSuffix1 = suffix1;
                _currentSuffix2 = suffix2;
            }
            _dataTable.Rows.Add(fileInfo, suffix1, suffix2);
            Debug.WriteLine($"Add to DataTable {suffix1} {suffix2} {fileInfo.Name}");
        }

        public DataRowCollection rows()
        {
            return _dataTable.Rows;
        }

        public DataRow getRow(int index)
        {
            if (_dataTable.Rows.Count <= index)
            {
                return null;
            }
            return _dataTable.Rows[index];
        }

        public FileInfo getCurrentFileInfo()
        {
            return _currentFileInfo;
        }

        public string getCurrentSuffix1()
        {
            return _currentSuffix1;
        }

        public string getCurrentSuffix2()
        {
            return _currentSuffix2;
        }
    }
}