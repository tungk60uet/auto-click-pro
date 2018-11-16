using AutoClickPro.Models;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_add_kichban_Click(object sender, RoutedEventArgs e)
        {
            if(txt_tenkichban.Text!="")
                lb_kichban.Items.Add(txt_tenkichban.Text);
        }

        private void btn_xoakichban_Click(object sender, RoutedEventArgs e)
        {
            if(lb_kichban.SelectedIndex>-1)
                lb_kichban.Items.RemoveAt(lb_kichban.SelectedIndex);
        }

        private void btn_chitietkichban_Click(object sender, RoutedEventArgs e)
        {
            if (lb_kichban.SelectedIndex > -1)
            {
                chitietkichban chitietkichban = new chitietkichban(lb_kichban.SelectedIndex);
                chitietkichban.Show();
            }
            
        }
    }
}
