using CommunityToolkit.Maui.Views;
using XinYeMobile.Models.QuestionBankModels;
using XinYeMobile.ViewModels;

namespace XinYeMobile.Pages.Tools;

public partial class AnswerCardPopup : Popup
{
	public AnswerCardPopup(AnswerCardPopupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void ClickIndex(object sender, TappedEventArgs e)
    {
		_= CloseAsync();
    }
}