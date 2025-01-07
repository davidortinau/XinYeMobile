using MauiIcons.Core;
using XinYeMobile.Models.QuestionBankModels;
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

	void Button_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(this.Handler.MauiContext.Services.GetRequiredService<QuestionPracticePage>());
	}
}