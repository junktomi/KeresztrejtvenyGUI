using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeresztrejtvenyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FeltoltCombok();
        }
            
        
        TextBox[,] mezok;

        private void FeltoltCombok()
        {
            for (int i = 6; i <= 15; i++)
            {
                cbSor.Items.Add(i);
                cbOszlop.Items.Add(i);
            }

            cbSor.SelectedItem = 15;
            cbOszlop.SelectedItem = 15;

            for (int i = 1; i <= 10; i++)
            {
                cbIndex.Items.Add(i);
            }

            cbIndex.SelectedItem = 3;
        }
        //b
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int sor = (int)cbSor.SelectedItem;
            int oszlop = (int)cbOszlop.SelectedItem;

            gridRacs.Children.Clear();

            gridRacs.Rows = sor;
            gridRacs.Columns = oszlop;

            mezok = new TextBox[sor, oszlop];

            for (int i = 0; i < sor; i++)
            {
                for (int j = 0; j < oszlop; j++)
                {
                    TextBox tb = new TextBox();
                    tb.Text = "-";
                    tb.Width = 25;
                    tb.Height = 25;
                    tb.TextAlignment = TextAlignment.Center;
                    tb.MaxLength = 1;
                    tb.MouseDoubleClick += Valtas;
                    mezok[i, j] = tb;
                    gridRacs.Children.Add(tb);
                }
            }
        }
        private void Valtas(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "-"){
                tb.Text = "#";
            }
            else
            {
                tb.Text = "-";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //chatgpt segítség volt a streamwriterhez és az error exceptionhöz
            try
            {
                int sor = mezok.GetLength(0);
                int oszlop = mezok.GetLength(1);

                int index = (int)cbIndex.SelectedItem;
                string fajlNev = $"kr{index}.txt";

                using (StreamWriter sw = new StreamWriter(fajlNev))
                {
                    for (int i = 0; i < sor; i++)
                    {
                        string sorSzoveg = "";

                        for (int j = 0; j < oszlop; j++)
                        {
                            sorSzoveg += mezok[i, j].Text;
                        }

                        sw.WriteLine(sorSzoveg);
                    }
                }

                MessageBox.Show("Mentés sikeres!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
