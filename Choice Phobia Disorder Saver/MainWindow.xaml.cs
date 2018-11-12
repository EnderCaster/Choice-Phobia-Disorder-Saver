using System;
using System.Windows;
using Microsoft.Win32;
using Choice_Phobia_Disorder_Saver.com.endercaster.utils;
using Choice_Phobia_Disorder_Saver.com.endercaster.service;

namespace Choice_Phobia_Disorder_Saver
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileSelector_Click(object sender, RoutedEventArgs e)
        {
            SetFileName(GetFileNameFromDialog());
        }

        private string GetFileNameFromDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            openFileDialog.Filter = "文本文件|*.txt";
            openFileDialog.InitialDirectory = Environment.SystemDirectory;
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }
        private void SetFileName(string fileName)
        {
            this.fileName.Text = fileName;
        }
        private string GetFileName()
        {
            return fileName.Text;
        }
        private void SetResult(string result)
        {
            resultContent.Text = result;
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            RandomDo randomDo = new RandomDo();
            string result = "";
            switch (modeChooser.SelectedIndex)
            {
                case Constraint.MODE_READ_FROM_FILE:
                    result = randomDo.ChooseWithFile(GetFileName());
                    SetResult(result);
                    break;
                case Constraint.MODE_READ_FROM_TEXTBOX:
                    result = randomDo.ChooseWithMultlineText(GetMultilineText());
                    SetResult(result);
                    break;
                case Constraint.MODE_DIY:
                    int count = 0;
                    int sum = 0;
                    int.TryParse(recordCount.Text,out count);
                    int.TryParse(recordSum.Text, out sum);
                    result = "请检查数量是否合法";
                    if (count >= sum)
                    {
                        result = "";
                    }
                    else if (count>0)
                    {
                        result = randomDo.ChooseWithCount(count,sum);
                    }
                    SetResult(result);
                    break;
                default:
                    SetResult("这是个BUG，请反馈");
                    break;
            }
        }

        private string GetMultilineText()
        {
            return itemContent.Text;
        }
    }
}
