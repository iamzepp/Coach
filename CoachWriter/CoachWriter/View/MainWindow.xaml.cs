using CoachWriter.Model.MainObjects;
using CoachWriter.Model.ReaderObjects;
using CoachWriter.Model.ServiceObjects;
using CoachWriter.Model.WriteObjects;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CoachWriter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CoachFile f = default;
        bool flag = true;
        bool flagTB = false;

        public MainWindow()
        {
            InitializeComponent();

           
        }

        private void btn_vid_Click(object sender, RoutedEventArgs e)
        {
            Instruction[] intr = new Instruction[grid.SelectedItems.Count];
            grid.SelectedItems.CopyTo(intr, 0);

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

        private void btn_vs_Click(object sender, RoutedEventArgs e)
        {
            Instruction[] intr = new Instruction[grid.SelectedItems.Count];
            grid.SelectedItems.CopyTo(intr, 0);

            Instruction instruction = new Instruction()
            {
                Id = intr.First().Id,
                Subject = intr.First().Subject,
                Place = intr.First().Place,
                Effect = intr.First().Effect,
                Value = intr.First().Value,
                Unit = intr.First().Unit,
                Instr = intr.First().Instr,
                Group = intr.First().Group,
                Clast = intr.First().Clast
            };

            f.Instructions.Insert(grid.SelectedIndex + 1, instruction);
        }


        private void t_v_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && grid.SelectedItems.Count != 0)
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

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                (new WriteToDirectory()).Write(f, saveFileDialog.FileName);
            }

            Cursor = Cursors.Wait;
            Thread.Sleep(1000);
            Cursor = Cursors.Arrow;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                f = (new ReadFromDirectory()).Read(openFileDialog.FileName);
                grid.ItemsSource = f.Instructions;
            }    
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = null;
            f.Instructions.Clear();

            f = ServiceCollectionCreater.Create();

            grid.ItemsSource = f.Instructions;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                TB1.Focus();
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = findSP.ActualWidth;
                buttonAnimation.To = 500;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.3);
                findSP.BeginAnimation(WidthProperty, buttonAnimation);
                flag = false;
                flagTB = true;
            }
            else
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = findSP.ActualWidth;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.3);
                findSP.BeginAnimation(WidthProperty, buttonAnimation);
                flag = true;
                grid.ItemsSource = f.Instructions;
                flagTB = false;
            }
        }

        private void TB1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (f != null)
                {
                    string s = (sender as TextBox).Text;
                    var w = (f.Instructions.Where(c => c.Subject.Contains(s))).ToList();

                    if (w != null)
                    {
                        if (w.Count != 0)
                        {
                            grid.ItemsSource = w;
                        }
                        else
                        {
                            MessageBox.Show("Нет совпадений, бро!");
                        }
                    }
                }
            }
        }

        private void t_B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && grid.SelectedItems.Count != 0)
            {
                int index_v = Convert.ToInt32(t_B.Text) - 1;

                Instruction[] intr = new Instruction[grid.SelectedItems.Count];
                grid.SelectedItems.CopyTo(intr, 0);

                int index_s = f.Instructions.IndexOf(intr.First());
                int index_po = f.Instructions.IndexOf(intr.Last());


                for (int i = 0; i < (index_po -index_s) + 1; i++)
                {
                    f.Instructions.Move(i, index_v);
                    f.Instructions.Insert(index_v, intr[i]);
                    index_v++;
                }

                grid.ItemsSource = null;
                grid.ItemsSource = f.Instructions;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                (new ExcelWriter()).Write(f, saveFileDialog.FileName);
            }

            Cursor = Cursors.Wait;
            Thread.Sleep(1000);
            Cursor = Cursors.Arrow;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                f = (new ExcelReader()).Read(openFileDialog.FileName);
                grid.ItemsSource = f.Instructions;
            }
        }
    }
}
