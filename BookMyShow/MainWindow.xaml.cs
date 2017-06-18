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

namespace BookMyShow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string email;
        public string accesstoken;
        public MainWindow()
        {
            InitializeComponent();

            LoginPage login = new LoginPage();
            login.Show();
            
            //var login = new Timings("a", token, 1, 1, DateTime.Now + TimeSpan.FromDays(1));
            //login.Show();

            //var Mov = new Movies("a","a",1);
            //Mov.Show();

            //var RegisterPage = new RegisterPage();
            //RegisterPage.Show();
            this.Close();

        }

        
    }
}
