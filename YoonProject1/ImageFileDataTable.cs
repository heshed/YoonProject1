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
        private DataTable _dataTable = null;
        private string _directoryPath = null;
        private int _index = 0;

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
 
            _dataTable.Rows.Add(_index, fileInfo, suffix1, suffix2);
            _index++;
        }

        public DataRowCollection rows()
        {
            return _dataTable.Rows;
        }
    }


}
