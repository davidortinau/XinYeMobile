using Android.Media;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Views;
using XinYeMobile.ViewModels;

namespace XinYeMobile.Pages.Tools;

public partial class CommentEntryPopup : Popup
{
	public CommentEntryPopup(CommentEntryPopupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		grid.WidthRequest = DeviceDisplay.MainDisplayInfo.Width/DeviceDisplay.MainDisplayInfo.Density;
		_= DisplaySoftInputAsync();
    }



    private async Task DisplaySoftInputAsync()
	{
		try
		{
			await Task.Delay(300);
            if (!editor.IsSoftInputShowing())
            {
                var result =  await editor.ShowSoftInputAsync(CancellationToken.None);
            }
        }
		catch(Exception ex) 
		{
			await Shell.Current.DisplayAlert("“Ï≥£",ex.ToString(),"OK");
		}

    }

    private async void editor_Focused(object sender, FocusEventArgs e)
    {
        if (!editor.IsSoftInputShowing())
        {
            await editor.ShowSoftInputAsync(CancellationToken.None);
        }
    }
    private async void editor_Unfocused(object sender, FocusEventArgs e)
    {
        if (editor.IsSoftInputShowing())
        {
            await editor.HideSoftInputAsync(CancellationToken.None);
        }
    }
}