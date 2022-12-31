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
            Question question = new Question();
            question.Questionbody = QuestionEntry.Text;

            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.Databaselocation);
            sQLiteConnection.CreateTable<Question>();
            int insertedrows = sQLiteConnection.Insert(question);
            sQLiteConnection.Close();

            if(insertedrows > 0)
            {
                await DisplayAlert("Succesfull", "added question", "ok");
            }
            else
            {
                await DisplayAlert("Failed", "something went wrong", "Try again");
            }

            await Navigation.PopAsync();
        }
        private void QuestionListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedquestion = QuestionListView.SelectedItem as Question;
            if (selectedquestion != null)
            {
                Navigation.PushAsync(new ManageQuestions(selectedquestion));
            }

        }
    }
}