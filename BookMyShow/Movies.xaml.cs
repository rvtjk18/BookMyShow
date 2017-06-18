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
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : Window
    {
        string Email, Token;
        int TheatreId;
        DateTime DateofShow;
        public Movies(string Email, string Token, int TheatreId)
        {
            this.Email = Email;
            this.Token = Token;
            this.TheatreId = TheatreId;
            InitializeComponent();
            if (TheatreId == 1)
            {
                BaahubaliBtn.Visibility = Visibility.Hidden;
            }
            else if(TheatreId == 2){
                MummyBtn.Visibility = Visibility.Hidden;
            }

        }

    

        private void MummyBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Timings timing = new Timings(Email, Token, TheatreId, 1, DateofShow);
            timing.Show();
            this.Close();
        }
        private void BaahubaliBtn_Click(object sender, RoutedEventArgs e)
        {
            Timings timing = new Timings(Email, Token, TheatreId, 2, DateofShow);
            timing.Show();
            this.Close();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Date.Text != null || Date.Text!= "")
            {
                DateofShow = DateTime.ParseExact(Date.Text, "dd/MM/yyyy", null);
            }
            
        }
    }
}
