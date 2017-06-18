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
using System.Windows.Shapes;

namespace BookMyShow
{
    /// <summary>
    /// Interaction logic for Theatre.xaml
    /// </summary>
    public partial class Theatre : Window
    {
        public string Email, Token;
        public Theatre(string Email, string Token)
        {
            this.Email = Email;
            this.Token = Token;
            InitializeComponent();

        }

        private void INOX_Click(object sender, RoutedEventArgs e)
        {
            int id = 1;
            Movies movie = new Movies(Email, Token, id);
            movie.Show();
            this.Close();
        }

        private void IMAX_Click(object sender, RoutedEventArgs e)
        {
            int id = 2;
            Movies movie = new Movies(Email, Token, id);
            movie.Show();
            this.Close();
        }
    }
}
