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
using Newtonsoft.Json;

namespace BookMyShow
{
    /// <summary>
    /// Interaction logic for Timings.xaml
    /// </summary>
    public partial class Timings : Window
    {
        string Email;
        string Token;
        int TheatreId;
        int MovieId;
        DateTime DateofShow;
        HttpClient client = new HttpClient();
        public Timings(string Email, string Token, int TheatreId, int MovieId, DateTime DateofShow)
        {
            this.Email = Email;
            this.Token = Token;
            this.TheatreId = TheatreId;
            this.MovieId = MovieId;
            this.DateofShow = DateofShow;
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:55555");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
        }

        private async void Morning_Click(object sender, RoutedEventArgs e)
        {
            int id = 1;
            var response = await client.GetAsync("/api/Booking/GetShowid?ShowTimeid="+id+"&Theatreid="+TheatreId+"&Movieid="+MovieId);
            var ShowId= response.Content.ReadAsAsync<int>().Result;
            response = await client.GetAsync("/api/booking/GetAvailableSeats?showid=" + ShowId + "&timestamp=" + DateofShow);
            var GetAvailableSeats = response.Content.ReadAsAsync<bool[]>().Result;
            Seating seating = new Seating(GetAvailableSeats, Email, Token, ShowId, DateofShow);
            seating.Show();
        }

        private async void Evening_Click(object sender, RoutedEventArgs e)
        {
            int id = 3;
            var response = await client.GetAsync("/api/Booking/GetShowid?ShowTimeid=" + id + "&Theatreid=" + TheatreId + "&Movieid=" + MovieId);
            var ShowId = response.Content.ReadAsAsync<int>().Result;
            response = await client.GetAsync("/api/booking/GetAvailableSeats?showid=" + ShowId + "&timestamp=" + DateofShow);
            var GetAvailableSeats = response.Content.ReadAsAsync<bool[]>().Result;
            Seating seating = new Seating(GetAvailableSeats, Email, Token, ShowId, DateofShow);
            seating.Show();
        }

        private async void Afternoon_Click(object sender, RoutedEventArgs e)
        {
            int id = 2;
            var response = await client.GetAsync("/api/Booking/GetShowid?ShowTimeid=" + id + "&Theatreid=" + TheatreId + "&Movieid=" + MovieId);
            var ShowId = response.Content.ReadAsAsync<int>().Result;
            response = await client.GetAsync("/api/booking/GetAvailableSeats?showid=" + ShowId + "&timestamp=" + DateofShow);
            var GetAvailableSeats = response.Content.ReadAsAsync<bool[]>().Result;
            Seating seating = new Seating(GetAvailableSeats, Email, Token, ShowId, DateofShow);
            seating.Show();
        }

        private async void Night_Click(object sender, RoutedEventArgs e)
        {
            int id = 4;
            var response = await client.GetAsync("/api/Booking/GetShowid?ShowTimeid=" + id + "&Theatreid=" + TheatreId + "&Movieid=" + MovieId);
            var ShowId = response.Content.ReadAsAsync<int>().Result;
            response = await client.GetAsync("/api/booking/GetAvailableSeats?showid=" + ShowId + "&timestamp=" + DateofShow);
            var GetAvailableSeats = response.Content.ReadAsAsync<bool[]>().Result;

            Seating seating = new Seating(GetAvailableSeats,Email, Token,ShowId,DateofShow);
            seating.Show();
        }
    }
}
