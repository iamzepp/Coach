using CoachWriter.Model.MainObjects;
using CoachWriter.Model.ReaderObjects;
using CoachWriter.Model.WriteObjects;
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

namespace CoachWriter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CoachFile f = default;

        public MainWindow()
        {
            InitializeComponent();

            f = (new ReadFromDirectory()).Read();

            grid.ItemsSource = f.Instructions;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            (new WriteToDirectory()).Write(f);
           
        }

        private void btn_vs_Click(object sender, RoutedEventArgs e)
        {
            int index_v = Convert.ToInt32(t_v.Text);
            int index_s = Convert.ToInt32(t_s.Text);
            int index_po = Convert.ToInt32(t_po.Text);

            for (int i = index_s; i < index_po + 1; i++)
            {
                f.Instructions.Move(i, index_v);
                index_v++;
            }
        }
    }
}
