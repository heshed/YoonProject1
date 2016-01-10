using System.Collections.Generic;

namespace YoonProject1
{
    public class InspectorsChoice
    {
        private Dictionary<string, int> _inspector1SaveData = null;
        private Dictionary<string, int> _inspector2SaveData = null;
        private string _csvFile = "";

        public InspectorsChoice()
        {
            this._inspector1SaveData = new Dictionary<string, int>();
            this._inspector2SaveData = new Dictionary<string, int>();
        }

        public void setSavePath(string directory)
        {
            _csvFile = $"{directory}/result.csv";
        }

        private bool put(Dictionary<string, int> dic, string key, int value)
        {
            if (dic.ContainsKey(key))
            {
                return false;
            }
            dic[key] = value;
            return true;
        }

        public bool put(int inspector, string key, int value)
        {
            Dictionary<string, int> dic;
            dic = (inspector == ImageFileDataTable.Inspector1)
                ? _inspector1SaveData
                : _inspector2SaveData;
            return put(dic, key, value);
        }

        /// <summary>
        /// 001_151126_101489851, 검사자1, mild NPDR인 경우 
        /// 001_151126_101489851와 검사자(1/2), mild NPDR을 저장함
        ///
        /// 10148985,1,1,2로 저장
        /// </summary>
        public void save()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(_csvFile))
            {

                foreach (KeyValuePair<string, int> entry in _inspector1SaveData)
                {
                    file.WriteLine($"{entry.Key},{ImageFileDataTable.Inspector1},{entry.Value}");
                }
                foreach (KeyValuePair<string, int> entry in _inspector2SaveData)
                {
                    file.WriteLine($"{entry.Key},{ImageFileDataTable.Inspector2},{entry.Value}");
                }
            }
        }
    }
}
