using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace truthordrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccount : ContentPage

    {
        private readonly string email = "admin";
        private readonly string password = "admin";
        public CreateAccount()
        {
            InitializeComponent();
        }

        private async void signInButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void createAccountButton_Clicked(object sender, EventArgs e)
        {
            if (emailEntry.Text == "admin" && passEntry.Text =="admin") 
            {
                await DisplayAlert("verification link sent", "We have sent an email containing a verification link to enable your account.", "proceed");
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Request failed", "you have enterd invalid credentials.", "Retry");
            }
            
        }
    }
}