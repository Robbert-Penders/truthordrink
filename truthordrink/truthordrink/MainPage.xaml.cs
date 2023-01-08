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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            App.Unauthenticate();
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
                failed = true;
            }

            if (failed) return;

            var userResult = await App.Database.GetUserAsync(emailEntry.Text);
            if (userResult == null)
            {
                await DisplayAlert("Incorrect Email", "This email has not been registered", "Try again");
                return;
            }

            if (userResult.Password == passEntry.Text)
            {
                App.Authenticate(userResult);
                await Navigation.PushAsync(new LandingPage());
            }
            else
            {
                await DisplayAlert("Incorrect Password", "You have entered an invalid password", "Try again");
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
