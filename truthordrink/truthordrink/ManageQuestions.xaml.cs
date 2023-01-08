using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truthordrink.Model;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace truthordrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageQuestions : ContentPage
    {
        public ManageQuestions()
        {
            InitializeComponent();
        }

        private async void Newset_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddQuestions());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetQuestionsForAuthenticatedUserAsync();
        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedQuestion = e.CurrentSelection[0] as Question;
            if (selectedQuestion != null)
            {
                
                string action = await DisplayActionSheet("Manage Question", "Cancel", null, "Edit", "Delete");
                Debug.WriteLine(action);
                if (action == "Delete")
                {
                    await App.Database.DeleteQuestionAsync(selectedQuestion);
                    collectionView.ItemsSource = await App.Database.GetQuestionsForAuthenticatedUserAsync();
                }
                else if (action == "Edit")
                {
                    string result = await DisplayPromptAsync("Edit Question", "What would you like to change it to?", initialValue: selectedQuestion.question, placeholder: "Question");
                    if (!String.IsNullOrEmpty(result))
                    {
                        selectedQuestion.question = result;
                        await App.Database.UpdateQuestionAsync(selectedQuestion);
                        collectionView.ItemsSource = await App.Database.GetQuestionsForAuthenticatedUserAsync();
                    }
                }
            }
        }

        private async void addDefaultQuestions_Clicked(object sender, EventArgs e)
        {
            addDefaultQuestions.IsVisible = false;
            DefaultQuestions.AddDefaultQuestions();
            collectionView.ItemsSource = await App.Database.GetQuestionsForAuthenticatedUserAsync();
        }
    }
}
