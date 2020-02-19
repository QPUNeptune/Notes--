using System;
using System.IO;
using Notesplusplus.Models;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
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
        var note = (Note) BindingContext;
        note.ModificationTime = DateTime.Now;
        if (note.IsNew)
        {
            note.IsNew = false;
            note.CreationTime = note.ModificationTime;
        }
        await App.Database.SaveNoteAsync(note);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var note = (Note) BindingContext;
        await App.Database.DeleteNoteAsync(note);
        await Navigation.PopToRootAsync();
    }

    async void AddNewImage(object sender, EventArgs e)
    {
        try
        {
            var note = (Note) BindingContext;
            FileData image = await CrossFilePicker.Current.PickFile(new[] {"image/*"});
            string imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserImages");
            if (image != null)
            {
                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);
                File.WriteAllBytes(Path.Combine(imagePath, image.FileName), image.DataArray);
                note.ImagePath = Path.Combine(imagePath, image.FileName);
            }
        }
        catch (Exception f)
        {
            await DisplayAlert("Error", f.Message + "\n" + f.Source + "\n" + f.StackTrace, "OK");
        }
    }
}
}