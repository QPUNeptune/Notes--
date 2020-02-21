using System;
using System.IO;
using Notesplusplus.Database;
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
    public static string Img { get; set; }

    public NotesEntryPage()
    {
        InitializeComponent();
    }

    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (Img.Equals(""))
        {
            Add.IsEnabled = true;
            Remove.IsEnabled = false;
        }
        else
        {
            Add.IsEnabled = false;
            Remove.IsEnabled = true;
        }

        ImageThinghy.Source = Img;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
            try
            {
                var note = (Note)BindingContext;
                note.ModificationTime = DateTime.Now;
                if (note.IsNew)
                {
                    note.IsNew = false;
                    note.CreationTime = note.ModificationTime;
                }
                await App.Database.SaveNoteAsync(note);
                await Navigation.PopAsync();
            }
            catch (Exception f)
            {
                await DisplayAlert("Error", f.Message + "\n" + f.Source + "\n" + f.StackTrace, "OK");
            }
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var note = (Note) BindingContext;
        await App.Database.DeleteNoteAsync(note);
        await Navigation.PopToRootAsync();
    }

    private async void AddNewImage(object sender, EventArgs e)
    {
        try
        {
            var note = (Note) BindingContext;
            var image = await CrossFilePicker.Current.PickFile(new[] {"image/*"});
            var imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserImages");
            if (image != null)
            {
                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);
                File.WriteAllBytes(Path.Combine(imagePath, image.FileName), image.DataArray);
                note.ImagePath = Path.Combine(imagePath, image.FileName);
                Img = note.ImagePath;
            }
        }
        catch (Exception ev)
        {
            await DisplayAlert("Error", ev.Message + "\n" + ev.Source + "\n" + ev.StackTrace, "OK");
        }
    }

    private void RemoveImage(object sender, EventArgs e)
    {
        var note = (Note) BindingContext;
        note.ImagePath = "";
        Img = note.ImagePath;
        ImageThinghy.Source = null;
        ImageThinghy.Source = Img;
        Add.IsEnabled = true;
        Remove.IsEnabled = false;
    }
}
}