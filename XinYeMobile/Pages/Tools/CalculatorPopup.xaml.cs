using CommunityToolkit.Maui.Views;
using org.matheval;
using XinYeMobile.ViewModels;

namespace XinYeMobile.Pages.Tools;

public partial class CalculatorPopup : Popup
{
    public CalculatorPopup(CalculatorPopupViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}