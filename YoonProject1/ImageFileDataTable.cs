using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoonProject1
{
    class ImageFileDataTable
    {
        public const int Inspector1 = 1;
        public const int Inspector2 = 2;

        private DataTable _dataTable = null;
        private string _directoryPath = null;
        private int _inspectorId = Inspector1;
        private int _index = 0;
        private int _currentIndex = 0;
        private FileInfo _currentFileInfo;
        private string _currentSuffix1;
        private string _currentSuffix2;
        

        public ImageFileDataTable()
        {
            _dataTable = new DataTable();
            _dataTable.Columns.Add("index", typeof(int));
            _dataTable.Columns.Add("fileInfo", typeof(FileInfo));
            _dataTable.Columns.Add("fileNameSuffix1", typeof(string));
            _dataTable.Columns.Add("fileNameSuffix2", typeof(string));
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
            DataRow row = _dataTable.Rows[_currentIndex];
            _currentFileInfo = row.Field<FileInfo>(1);
            _currentSuffix1 = row.Field<string>(2);
            _currentSuffix2 = row.Field<string>(3);
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
            _dataTable.Clear();
        }

        public void addFileInfo(FileInfo fileInfo, string suffix1, string suffix2)
        {
            if (_currentIndex == _index)
            {
                _currentFileInfo = fileInfo;
                _currentSuffix1 = suffix1;
                _currentSuffix2 = suffix2;
            }
            _dataTable.Rows.Add(_index, fileInfo, suffix1, suffix2);
            _index++;
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
