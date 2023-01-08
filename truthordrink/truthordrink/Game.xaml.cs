using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using truthordrink.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace truthordrink
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Drink
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public object strDrinkAlternate { get; set; }
        public object strTags { get; set; }
        public object strVideo { get; set; }
        public string strCategory { get; set; }
        public object strIBA { get; set; }
        public string strAlcoholic { get; set; }
        public string strGlass { get; set; }
        public string strInstructions { get; set; }
        public object strInstructionsES { get; set; }
        public object strInstructionsDE { get; set; }
        public object strInstructionsFR { get; set; }
        public string strInstructionsIT { get; set; }

        [JsonProperty("strInstructionsZH-HANS")]
        public object strInstructionsZHHANS { get; set; }

        [JsonProperty("strInstructionsZH-HANT")]
        public object strInstructionsZHHANT { get; set; }
        public string strDrinkThumb { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public object strIngredient8 { get; set; }
        public object strIngredient9 { get; set; }
        public object strIngredient10 { get; set; }
        public object strIngredient11 { get; set; }
        public object strIngredient12 { get; set; }
        public object strIngredient13 { get; set; }
        public object strIngredient14 { get; set; }
        public object strIngredient15 { get; set; }
        public string strMeasure1 { get; set; }
        public string strMeasure2 { get; set; }
        public string strMeasure3 { get; set; }
        public string strMeasure4 { get; set; }
        public string strMeasure5 { get; set; }
        public string strMeasure6 { get; set; }
        public string strMeasure7 { get; set; }
        public object strMeasure8 { get; set; }
        public object strMeasure9 { get; set; }
        public object strMeasure10 { get; set; }
        public object strMeasure11 { get; set; }
        public object strMeasure12 { get; set; }
        public object strMeasure13 { get; set; }
        public object strMeasure14 { get; set; }
        public object strMeasure15 { get; set; }
        public object strImageSource { get; set; }
        public object strImageAttribution { get; set; }
        public string strCreativeCommonsConfirmed { get; set; }
        public object dateModified { get; set; }
    }

    public class Root
    {
        public List<Drink> drinks { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        private List<Question> userQuestions;
        public Game()
        {
            InitializeComponent();
        }

        private async void GetCocktail()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/random.php");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                drinkLabel.Text = "Cocktail suggestion: " + myDeserializedClass.drinks[0].strDrink;
            } else
            {
                drinkLabel.Text = "Could not retrieve cocktail";
            }
        }

        private void SelectRandomQuestion()
        {
            if (userQuestions.Count <= 0) return;
            var rnd = new Random();
            int index = rnd.Next(userQuestions.Count);
            Question question = userQuestions[index];
            currentQuestion.Text = question.question;
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            SelectRandomQuestion();
        }

        private void EnableShake()
        {
            Accelerometer.Start(SensorSpeed.Game);
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        private void DisableShake()
        {
            Accelerometer.Stop();
            Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            EnableShake();
            userQuestions = await App.Database.GetQuestionsForAuthenticatedUserAsync();
            SelectRandomQuestion();
            GetCocktail();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DisableShake();
        }

        private void truthButton_Clicked(object sender, EventArgs e)
        {
            SelectRandomQuestion();
        }

        private void drinkButton_Clicked(object sender, EventArgs e)
        {
            SelectRandomQuestion();
            GetCocktail();
        }

        private async void speechButton_Clicked(object sender, EventArgs e)
        {
            await TextToSpeech.SpeakAsync(currentQuestion.Text);
        }
    }

}