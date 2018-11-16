using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoClickPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string DBFolder = "database";
        List<string> files=new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            getDB();
        }
        void getDB()
        {
            lb_kichban.Items.Clear();
            files.Clear();
            if (!Directory.Exists(DBFolder))
            {
                Directory.CreateDirectory(DBFolder);
            }
            files.AddRange(Directory.GetFiles(DBFolder, "*.txt", SearchOption.TopDirectoryOnly));
            foreach (string item in files)
            {
                lb_kichban.Items.Add(item.Substring(DBFolder.Length + 1));
            }
        }
        private void btn_add_kichban_Click(object sender, RoutedEventArgs e)
        {
            if (txt_tenkichban.Text != ""&&!File.Exists(DBFolder + "/" + txt_tenkichban.Text + ".txt"))
            {
                File.Create(DBFolder+"/"+txt_tenkichban.Text +".txt");
                getDB();
            }
        }
        private void btn_xoakichban_Click(object sender, RoutedEventArgs e)
        {
            
            if (lb_kichban.SelectedIndex > -1)
            {
                File.Delete(DBFolder + "/" + lb_kichban.SelectedValue);
                getDB();
            }
        }
        private void btn_chitietkichban_Click(object sender, RoutedEventArgs e)
        {
            if (lb_kichban.SelectedIndex > -1)
            {
                chitietkichban chitietkichban = new chitietkichban((string)lb_kichban.SelectedValue);
                chitietkichban.Show();
            }
            
        }
    }
}
