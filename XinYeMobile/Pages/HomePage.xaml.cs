using MauiIcons.Core;
using XinYeMobile.ViewModels;

namespace XinYeMobile.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        _ = new MauiIcon();
    }
}