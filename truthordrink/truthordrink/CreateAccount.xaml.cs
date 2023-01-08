using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace truthordrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccount : ContentPage

    {
        private readonly Regex emailReg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return emailReg.IsMatch(email);
        }

        public CreateAccount()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            App.Unauthenticate();
        }

        private async void signInButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void createAccountButton_Clicked(object sender, EventArgs e)
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
            if (userResult != null)
            {
                await DisplayAlert("Email In Use", "This email has already been registered", "Try another email");
                return;
            }

            var newUser = new Model.User
            {
                Email = emailEntry.Text,
                Password = passEntry.Text,
            };
            App.Authenticate(newUser);
            await App.Database.SaveUserAsync(newUser);
            await Navigation.PushAsync(new LandingPage());
        }
    }
}