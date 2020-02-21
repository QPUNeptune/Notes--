using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notesplusplus.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notesplusplus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {
        public NotePage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var note = (Note) BindingContext;
            BindingContext = await App.Database.GetNoteAsync(note.Id);
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            NotesEntryPage.Img = ((Note) BindingContext).ImagePath;
            await Navigation.PushAsync(new NotesEntryPage
            {
                BindingContext = BindingContext as Note
            });
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var note = (Note) BindingContext;
            var deleteConfirmation = await DisplayAlert("Delete note", "Are you sure you want to delete " + note.Title + " ?", "Yes", "No");
            if (deleteConfirmation)
            {
                await App.Database.DeleteNoteAsync(note);
                await DisplayAlert("Deletion complete", "The note " + note.Title + " was deleted successfully.", "OK");
                await Navigation.PopToRootAsync();
            }
            else
            {
                await DisplayAlert("Deletion failed", "Canceled by user.", "OK");
            }
        }
    }
}