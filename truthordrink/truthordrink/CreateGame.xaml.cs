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
    public partial class CreateGame : ContentPage
    {
        //Dictionary<string, Questionslists> questionslist = new Dictionary<string, Questionslists>();
       // {
            //{"Default Questions", }
        //}
        public CreateGame()
        {
            InitializeComponent();

            Label header = new Label
            {
                Text = "Picker",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
        }        

        void Addplayer_Clicked(object sender, EventArgs e)
        {
            if(!playername3.IsVisible)
            {
                playername3.IsVisible = true;
            }
            else if(!playername4.IsVisible)
            {
                playername4.IsVisible = true;
                AddPlayerButton.IsVisible = false;
            }
        }

        private async void StartGameButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Game());
            playername3.IsVisible = false;
            playername4.IsVisible = false;
            AddPlayerButton.IsVisible = true;
        }
    }
}