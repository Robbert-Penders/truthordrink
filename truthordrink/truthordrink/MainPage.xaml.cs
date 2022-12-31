using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace truthordrink
{
    public partial class MainPage : ContentPage
    {
        private readonly string email = "admin@admin.com";
        private readonly string password = "admin";
        private readonly Regex emailReg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public MainPage()
        {
            InitializeComponent();
        }
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return emailReg.IsMatch(email);
        }

        private async void login_Clicked(object sender, EventArgs e)
        {
            bool failed = false;

            if (!ValidateEmail(emailEntry.Text))
            {
                emailError.Text = "Enter a valid email address";
                failed = true;
            }

            if (String.IsNullOrEmpty(passEntry.Text))
            {
                passError.Text = "Enter a valid password";
                failed= true;
            }

            if (failed) return;

            if (emailEntry.Text == email && passEntry.Text == password)
            {
                await Navigation.PushAsync(new LandingPage());
            }
            else
            {
                await DisplayAlert("Login Failed", "You have entered invalid credentials", "Try again");

            }
        }

        private async void ForgotButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccount());
        }
    }
}
