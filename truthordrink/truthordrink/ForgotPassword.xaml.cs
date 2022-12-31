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
    public partial class ForgotPassword : ContentPage
    {
        private readonly string email = "admin";
    
        public ForgotPassword()
        {
            InitializeComponent();
        }
        private async void PasswordReset_Clicked(object sender, EventArgs e)
        {
            if (emailEntry.Text == email)
            {
                await DisplayAlert("Verification link sent", "We have sent an email containing a verification link. This allows us to confirm the email address you've enterd. you will be atuomatically redirected upon clicking the verification link.", "Proceed");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Request failed", "You have entered invalid credentials.", "Retry"); 
            }

        }
    }
}