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
                await App.Database.DeleteQuestionAsync(selectedQuestion);
                collectionView.ItemsSource = await App.Database.GetQuestionsForAuthenticatedUserAsync();
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
