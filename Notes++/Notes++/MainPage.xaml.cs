﻿using System;
using System.ComponentModel;
using Notesplusplus.Models;
using Xamarin.Forms;

namespace Notesplusplus
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListView.ItemsSource = await App.Database.GetNotesAsync();
        }

        private async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            NotesEntryPage.Img = "";
            await Navigation.PushAsync(new NotesEntryPage
            {
                BindingContext = new Note{IsNew = true, ImagePath = ""}
            });
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NotePage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }

        private async void Search(object sender, TextChangedEventArgs e)
        {
            await App.Database.GetNotesSearchAsync(e.NewTextValue);
        }
    }
}
