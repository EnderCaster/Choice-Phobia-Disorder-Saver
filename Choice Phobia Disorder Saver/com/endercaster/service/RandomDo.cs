using Choice_Phobia_Disorder_Saver.com.endercaster.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Choice_Phobia_Disorder_Saver.com.endercaster.service
{
    class RandomDo
    {
        public string ChooseWithFile(string fileName)
        {
            string result = "";

            string[] items = GetFileContent(fileName);
            result = GetRandomItem(items);
            return result;
        }

        private string GetRandomItem(string[] items)
        {
            int itemLength = items.Length;
            return items[Erandom.getRandomPos(itemLength)];
        }

        private string[] GetFileContent(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new string[1];
            }
            string[] fileContent=File.ReadAllLines(fileName);
            return TrimStringArray(fileContent);
        }

        private string[] TrimStringArray(string[] fileContent)
        {
            List<string> realFileContent = new List<string>();
            foreach(string line in fileContent)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    realFileContent.Add(line);
                }
            }
            return realFileContent.ToArray();
        }
        public string ChooseWithMultlineText(string content)
        {   
            string[] items = Regex.Split(content, Environment.NewLine);
            
            return GetRandomItem(items);
        }
        public string[] GetMultipleItems(int count,int sum)
        {
            List<string> indexes = new List<string>();
            int index = Erandom.getRandomPos(sum);
            while (indexes.Count < count)
            {
                if (!indexes.Contains((index + 1).ToString()))
                {
                    indexes.Add((index + 1).ToString());
                }
                index = Erandom.getRandomPos(sum);
            }
            indexes.Sort();
            return indexes.ToArray();
        }

        private static string[] ChangeListItemToOrdinal(string[] indexes)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = "第" + indexes[i] + "条";
            }
            return indexes;
        }

        internal string ChooseWithCount(int count,int sum)
        {   
            return string.Join(Environment.NewLine, ChangeListItemToOrdinal( GetMultipleItems(count,sum)));
        }
    }
}
