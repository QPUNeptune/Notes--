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

        async void OnEditClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotesEntryPage
            {
                BindingContext = BindingContext as Note
            });
        }
    }
}