using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
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
using BookMyShow.Models;
using System.Net.Http.Formatting;
using System.Net;

namespace BookMyShow
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Payment : Window
    {
        string Email;
        string Token;
        float multiplier;
        int showid;
        DateTime dateofshow;
        int seatstart; 
        int seatEnd;
        HttpClient client = new HttpClient();
        public Payment(string Email,string Token,float multiplier, int showid, DateTime dateofshow, int seatstart, int seatEnd)
        {
            this.Email = Email;
            this.Token = Token;
            this.multiplier = multiplier;
            this.showid = showid;
            this.dateofshow = dateofshow;
            this.seatEnd = seatEnd;
            this.seatstart = seatstart;
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:55555");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
            pricelabel1.Content = "Present Multiplier: "+multiplier+ ", Total: ";
            pricelabel.Content = multiplier * 100 * (seatEnd - seatstart + 1);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var no = seatEnd - seatstart + 1;
            var price = multiplier * 100 * no;
            var response = await client.GetAsync("/api/booking/BookTickets?DateofShow=" + dateofshow + "&ShowId=" + showid + "&UId=" + Email + "&DateOfBooking=" + DateTime.Now + "&NoofTickets=" + no + "&SeatStart=" + seatstart + "&seatend=" + seatEnd + "&price=" + price);
            var result = response.Content.ReadAsAsync<bool>().Result;
            if (result)
            {
                MessageBox.Show("Payment successfull");
            }
            else MessageBox.Show("Sorry, Payment Not Successfull");
            
            this.Close();
        }
    }
}
