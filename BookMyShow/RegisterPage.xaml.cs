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

namespace BookMyShow
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        HttpClient client = new HttpClient();
        public RegisterPage()
        {
            InitializeComponent();
            LoginButton.Visibility = Visibility.Hidden;
            client.BaseAddress = new Uri("http://localhost:55555/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();
                if(password.Password != cpassword.Password)
                {
                    MessageBox.Show("Please enter the correct Password");
                    return;
                }
                user.email = email.Text;
                user.password = password.Password ;
                user.Confirmpassword = cpassword.Password;
                
                HttpResponseMessage response = await client.PostAsJsonAsync("/api/Account/Register",user);
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode(); // Throw on error code.
                    Status.Content = "Registration Successfull, Please Login...!!!";
                    LoginButton.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Web API Not Running ");
            }
        }

        private void Login_click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            login.Show();
            this.Close();
        }
    }
}
