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
        Question question;
        private void QuestionListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedquestion = QuestionListView.SelectedItem as Question;
            if (selectedquestion != null)
            {
                Navigation.PushAsync(new ManageQuestions(selectedquestion));
            }

        }
        //public ManageQuestions(Question selectedquestion)
        //{
        //    InitializeComponent();
        //    question = selectedquestion;

        //    Idlabel.Text = question.id.ToString();
        //    QuestionBodyEntry.Text = question.Questionbody;
        //}

        private async void Newset_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddQuestions());
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}