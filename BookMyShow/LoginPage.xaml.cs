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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        HttpClient client = new HttpClient();
        public  LoginPage()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:55555");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            //string GetToken = "username=" + EmailBox.Text + "&password=" + passwordBox.Password + "&grant_type=password";
            //var login = new Dictionary <string, string>
            //{
            //    { EmailBox.Text, passwordBox.Password}
            //};
            string accessToken = " " ;
            var login = client.PostAsync("/token", new FormUrlEncodedContent(new Dictionary<string, string> { { "grant_type", "password" }, { "username", EmailBox.Text }, { "password", passwordBox.Password } })).Result;
            if (login.StatusCode == HttpStatusCode.OK)
            {
                var result = login.Content.ReadAsStringAsync().Result;
                Dictionary<string, string> tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                accessToken = tokenDictionary["access_token"];
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                MessageBox.Show("Log in succesfull!");
            }
            else
            {
                MessageBox.Show("Faulty Login");
                return;
            }

            Theatre theatre = new Theatre(EmailBox.Text, accessToken);
            theatre.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var register = new RegisterPage();
            register.Show();
            this.Close();
        }
    }
}
