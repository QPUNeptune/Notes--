using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes__
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class NotesEntryPage : ContentPage
{
	public NotesEntryPage()
	{
		InitializeComponent();
	}

	private void OnSaveButtonClicked(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	private void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}
}
}