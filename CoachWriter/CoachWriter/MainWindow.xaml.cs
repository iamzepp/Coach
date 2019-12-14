using CoachWriter.Model.MainObjects;
using CoachWriter.Model.ReaderObjects;
using CoachWriter.Model.ServiceObjects;
using CoachWriter.Model.WriteObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

            Cursor = Cursors.Wait;
            Thread.Sleep(3000);
            Cursor = Cursors.Arrow;
        }

        private void btn_vid_Click(object sender, RoutedEventArgs e)
        {
            Instruction[] intr = new Instruction[grid.SelectedItems.Count];
            grid.SelectedItems.CopyTo(intr,0);

            foreach (Instruction w in intr)
            {
               f.Instructions.Remove(w);
            }
        }

        private void btn_vstv_Click(object sender, RoutedEventArgs e)
        {

            Instruction instruction = new Instruction()
            {
                Id = default,
                Subject = default,
                Place = default,
                Effect = default,
                Value = default,
                Unit = default,
                Instr = default,
                Group = default,
                Clast = default
            };

            f.Instructions.Insert(grid.SelectedIndex + 1, instruction);

            
        }

        private void t_v_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter && grid.SelectedItems.Count !=0)
            {
                int index_v = Convert.ToInt32(t_v.Text) - 1;

                Instruction[] intr = new Instruction[grid.SelectedItems.Count];
                grid.SelectedItems.CopyTo(intr, 0);

                int index_s = f.Instructions.IndexOf(intr.First());
                int index_po = f.Instructions.IndexOf(intr.Last());


                for (int i = index_s; i < index_po + 1; i++)
                {
                    f.Instructions.Move(i, index_v);
                    index_v++;
                }

                grid.ItemsSource = null;
                grid.ItemsSource = f.Instructions;

            }
        }

        private void grid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<string> readf = ServiceCollectionCreater.ReadFile("Замена.txt");

            for (int i = 0; i < readf.Count; i++)
            {
                f.Instructions[i].Place = readf[i];
            }

            grid.ItemsSource = null;
            grid.ItemsSource = f.Instructions;           
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = null;
            f.Instructions.Clear();

            f = ServiceCollectionCreater.Create();
         
            grid.ItemsSource = f.Instructions;
        }

      

    }
}
