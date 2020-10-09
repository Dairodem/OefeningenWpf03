using OefeningenWpf01;
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

namespace OefeningenWpf03
{
    public partial class MainWindow : Window
    {
        string[] ages = new string[] { "Bejaarde", "Volwassen", "Minderjarige" };
        string[] sexes = new string[] { "Man", "Vrouw" };
        string colorText = "";
        List<Persoon> personen = new List<Persoon>();
        Image online = new Image();
        Image offline = new Image();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBoxes();
            FillListBox();

        }
        private void FillListBox()
        {
            personen.Add(new Persoon() { Voornaam = "Jos", Achternaam = "Vermeulen", LoggedIn = true }) ;
            personen.Add(new Persoon() { Voornaam = "Sofie", Achternaam = "Kasteels" , LoggedIn = false});
            personen.Add(new Persoon() { Voornaam = "Marc", Achternaam = "Deberg" ,LoggedIn = false});
            personen.Add(new Persoon() { Voornaam = "Alex", Achternaam = "Boom", LoggedIn = true });

            foreach (Persoon persoon in personen)
            {
                if (persoon.LoggedIn)
                    persoon.Status = @"G:\Documents\Coding\Pics\Online.png";
                else
                    persoon.Status = @"G:\Documents\Coding\Pics\offline.png";
            }

            LbxLogin.ItemsSource = personen;
        }
        private void FillComboBoxes()
        {
            for (int i = 0; i < ages.Length; i++)
            {
                CbAge.Items.Add(ages[i]);
            }
            for (int i = 0; i < sexes.Length; i++)
            {
                CbSex.Items.Add(sexes[i]);
            }
            CbAge.SelectedIndex = 0;
            CbSex.SelectedIndex = 0;
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{CbAge.SelectedItem} {CbSex.SelectedItem}");
        }

        private void tab1_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTab1.Text = txtTab2.Text;
        }

        private void tab2_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTab2.Text = txtTab1.Text;
        }

        private void BtnColor_Click(object sender, RoutedEventArgs e)
        {
            if (TxtColor.Foreground == Brushes.Blue)
            {
                TxtColor.Foreground = Brushes.Black;
            }
            else
            {
                TxtColor.Foreground = Brushes.Blue;
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtOef4.Text = "";
        }

        private void BtnColors_Click(object sender, RoutedEventArgs e)
        {
            colorText = "";
            CheckBoxes(CbRed);
            CheckBoxes(CbOra);
            CheckBoxes(CbGre);
            CheckBoxes(CbBlu);

            MessageBox.Show(colorText);

        }
        private void CheckBoxes(CheckBox cbx)
        {
            if ((bool)cbx.IsChecked)
            {
                colorText += $"{cbx.Content}\n";
            }
        }
    }
}
