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
    /// Interaction logic for Seating.xaml
    /// </summary>
    public partial class Seating : Window
    {

        bool[] boolArr = new bool[51];
        CheckBox[] cb1 = new CheckBox[51];
        Boolean[] isCheckBoxChecked = new Boolean[51];
        int[] seatNumbersArr = new int[5];
        int seatNumberIndex;
        int seatCount;
        int finalSeatCount;
        bool[] temp = new bool[50];
        string email, token;
        int showid;
        DateTime dateofshow;
        int seatstart = 0;
        int seatEnd = 0;
        HttpClient client = new HttpClient();

        public Seating(bool[] GetAvailableSeats, string Email, string Token, int ShowId, DateTime DateofShow)
        {
            this.temp = GetAvailableSeats;
            this.email = Email;
            this.token = Token;
            this.showid = ShowId;
            this.dateofshow = DateofShow;
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:55555");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

            boolArr = GetAvailableSeats;
            
            func();
        }


        public void func()
        {
            try
            {
                StackPanel outerStack;
                StackPanel innerStack;

                for (int j = 1; j < 51; j++)
                {
                    isCheckBoxChecked[j] = false;
                }


                outerStack = new StackPanel { Orientation = Orientation.Vertical };
                int i = 1;
                for (int j = 0; j < 5; j++)
                {
                    innerStack = new StackPanel { Orientation = Orientation.Horizontal };
                    while (i < 51)
                    {
                        //CheckBox checkbox = new CheckBox();
                        //checkbox.Name = "myCheckbox" + (i);
                        //checkbox.Content = " " + (i);
                        //checkbox.Margin = new Thickness(10);                   
                        //innerStack.Children.Add(checkbox);
                        cb1[i] = new CheckBox();
                        cb1[i].Name = "myCheckbox" + (i);
                        cb1[i].Content = i;
                        cb1[i].Margin = new Thickness(15);
                        cb1[i].IsEnabled = boolArr[i];
                        cb1[i].IsChecked = !(boolArr[i]);
                        cb1[i].Background = new SolidColorBrush(Color.FromRgb(00, 0xFF, 00));
                        cb1[i].Checked += new RoutedEventHandler(cbChecked);
                        cb1[i].Unchecked += new RoutedEventHandler(cbUnchecked);

                        innerStack.Children.Add(cb1[i]);
                        if (i % 10 == 0)
                        {
                            ++i;
                            break;
                        }
                        else
                        {
                            ++i;
                        }
                    }
                    stackpanel1.Children.Add(innerStack);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e);
            }
        }

        public void cbChecked(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int seatNo = Int32.Parse(checkbox.Content.ToString());
            if (seatCount > 0)
            {
                --seatCount;
                isCheckBoxChecked[seatNo] = true;
                if (seatNumberIndex < 5)
                {
                    seatNumbersArr[seatNumberIndex] = seatNo;
                    ++seatNumberIndex;
                }
                if (seatNo < 50 && boolArr[seatNo + 1] == true && seatCount > 0)
                {
                    cb1[seatNo + 1].SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
            }
            else
            {
                cb1[seatNo].IsChecked = false;
                //cb1[seatNo].SetCurrentValue(CheckBox.IsCheckedProperty, false);
            }
        }


        public void cbUnchecked(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int seatNo = Int32.Parse(checkbox.Content.ToString());
            if (seatCount <= finalSeatCount && isCheckBoxChecked[seatNo] == true)
            {
                ++seatCount;
                --seatNumberIndex;
            }
        }


        public void CB_SelectionChanged(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            ComboBoxItem typeItem = (ComboBoxItem)combobox.SelectedItem;
            if (finalSeatCount > 0)
            {
                for (int j = 0; j < 5 && seatNumbersArr[j] > 0; j++)
                {
                    cb1[seatNumbersArr[j]].IsChecked = false;
                    isCheckBoxChecked[seatNumbersArr[j]] = false;
                }
                seatNumberIndex = 0;
            }
            finalSeatCount = Int32.Parse(typeItem.Content.ToString());
            seatCount = finalSeatCount;
        }


        //payment button click event

        public async void paymentBtnClick(object sender, EventArgs e)
        {
            if (finalSeatCount > 0)
            {
                seatstart = seatNumbersArr[0];
                if (seatNumberIndex != 0)
                {
                    seatEnd = seatNumbersArr[seatNumberIndex - 01];
                }

                var response = await client.GetAsync("/api/Booking/SurgePricing?showid=" + showid + "&DateofShow=" + dateofshow + "&SeatStart=" + seatstart + "&seatend=" + seatEnd + "&Uid=" + email);
                var multiplier = response.Content.ReadAsAsync<float>().Result;
                float price = multiplier * 100;

                Payment win1 = new Payment(email, token, multiplier, showid, dateofshow, seatstart, seatEnd);
                win1.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Select seats");
            }
        }

    }


}
