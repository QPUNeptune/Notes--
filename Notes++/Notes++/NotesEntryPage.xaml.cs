using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notesplusplus
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class NotesEntryPage : ContentPage
{
	public NotesEntryPage()
	{
		InitializeComponent();
	}

	async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var note = (Models.Note) BindingContext;
		note.ModificationTime = DateTime.Now;
        await App.Database.SaveNoteAsync(note);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		var note = (Models.Note) BindingContext;
        await App.Database.DeleteNoteAsync(note);
        await Navigation.PopAsync();
    }
}
}