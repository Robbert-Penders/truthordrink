using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using truthordrink.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace truthordrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
      
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private async void CreateGameButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Game());
        }

        private async void ManageQuestionButton_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ManageQuestions());
        }
    }

} 