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
    public partial class Game : ContentPage
    {
        public Game()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.Databaselocation))
        //    {
        //        sQLiteConnection.CreateTable<Question>();
        //        var questions = sQLiteConnection.Table<Question>().ToList();
        //        QuestionListView.ItemsSource = questions;

        //    }
        //}


    }

}