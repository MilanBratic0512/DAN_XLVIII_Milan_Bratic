using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User(string username)
        {
            InitializeComponent();
            this.DataContext = new UserViewModel(this, username);
            DataGridUsers.Items.Refresh();

        }
        private void NumbersOnlyTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TbMargarita_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMargarita.Text) && !string.IsNullOrEmpty(tbKapricoza.Text) && !string.IsNullOrEmpty(tbNapolitana.Text) && !string.IsNullOrEmpty(tbSicilijana.Text) && !string.IsNullOrEmpty(tbSpecial.Text))
                tbTotal.Text = (Convert.ToInt32(tbMargarita.Text) * 350 + Convert.ToInt32(tbKapricoza.Text) * 490 + Convert.ToInt32(tbNapolitana.Text) * 630 + Convert.ToInt32(tbSpecial.Text) * 980 + Convert.ToInt32(tbSicilijana.Text) * 750).ToString();
        }

        private void TbKapricoza_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMargarita.Text) && !string.IsNullOrEmpty(tbKapricoza.Text) && !string.IsNullOrEmpty(tbNapolitana.Text) && !string.IsNullOrEmpty(tbSicilijana.Text) && !string.IsNullOrEmpty(tbSpecial.Text))
                tbTotal.Text = (Convert.ToInt32(tbMargarita.Text) * 350 + Convert.ToInt32(tbKapricoza.Text) * 490 + Convert.ToInt32(tbNapolitana.Text) * 630 + Convert.ToInt32(tbSpecial.Text) * 980 + Convert.ToInt32(tbSicilijana.Text) * 750).ToString();
        }

        private void TbNapolitana_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMargarita.Text) && !string.IsNullOrEmpty(tbKapricoza.Text) && !string.IsNullOrEmpty(tbNapolitana.Text) && !string.IsNullOrEmpty(tbSicilijana.Text) && !string.IsNullOrEmpty(tbSpecial.Text))
                tbTotal.Text = (Convert.ToInt32(tbMargarita.Text) * 350 + Convert.ToInt32(tbKapricoza.Text) * 490 + Convert.ToInt32(tbNapolitana.Text) * 630 + Convert.ToInt32(tbSpecial.Text) * 980 + Convert.ToInt32(tbSicilijana.Text) * 750).ToString();
        }

        private void TbSicilijana_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMargarita.Text) && !string.IsNullOrEmpty(tbKapricoza.Text) && !string.IsNullOrEmpty(tbNapolitana.Text) && !string.IsNullOrEmpty(tbSicilijana.Text) && !string.IsNullOrEmpty(tbSpecial.Text))
                tbTotal.Text = (Convert.ToInt32(tbMargarita.Text) * 350 + Convert.ToInt32(tbKapricoza.Text) * 490 + Convert.ToInt32(tbNapolitana.Text) * 630 + Convert.ToInt32(tbSpecial.Text) * 980 + Convert.ToInt32(tbSicilijana.Text) * 750).ToString();
        }

        private void TbSpecial_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMargarita.Text) && !string.IsNullOrEmpty(tbKapricoza.Text) && !string.IsNullOrEmpty(tbNapolitana.Text) && !string.IsNullOrEmpty(tbSicilijana.Text) && !string.IsNullOrEmpty(tbSpecial.Text))
                tbTotal.Text = (Convert.ToInt32(tbMargarita.Text) * 350 + Convert.ToInt32(tbKapricoza.Text) * 490 + Convert.ToInt32(tbNapolitana.Text) * 630 + Convert.ToInt32(tbSpecial.Text) * 980 + Convert.ToInt32(tbSicilijana.Text) * 750).ToString();
        }
    }
}
