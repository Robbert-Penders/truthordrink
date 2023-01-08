using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truthordrink.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace truthordrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddQuestions : ContentPage
    {
        public AddQuestions()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(QuestionEntry.Text)) {
                await DisplayAlert("Enter a question", "This field cannot be empty.", "Try again");
                return;
            }

            if (!App.IsAuthenticated()) return;

            await App.Database.SaveQuestionAsync(new Question
            {
                userId= App.GetAuthenticatedUserId(),
                question = QuestionEntry.Text,
            });

            await Navigation.PopAsync();
        }
    }
}