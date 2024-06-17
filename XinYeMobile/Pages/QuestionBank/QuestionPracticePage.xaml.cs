using CommunityToolkit.Maui.Views;
using XinYeMobile.Pages.Tools;
using XinYeMobile.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XinYeMobile.Models.QuestionBankModels;

public partial class QuestionPracticePage : ContentPage
{
    double panX, panY;
    private readonly CalculatorPopupViewModel _cal;
    public QuestionPracticePage(QuestionPracticeViewModel vm,CalculatorPopupViewModel cal)
	{
		InitializeComponent();
		BindingContext = vm;
        _cal = cal;
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
         var popup = new CalculatorPopup(_cal);
        popup.Anchor = tabbar;
        popup.Size = new Size(width: DeviceDisplay.MainDisplayInfo.Width/ DeviceDisplay.MainDisplayInfo.Density,height:400);
        await this.ShowPopupAsync(popup);
    }

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (sender is Border)
        {
            var border = sender as Border;
            var parent = border.Parent as Grid;
            var description = parent.FindByName<ScrollView>("description");
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    carouselview.IsSwipeEnabled = false;
                    break;
                case GestureStatus.Running:
                    //QuestionView.IsSwipeEnabled = false;
                    description.HeightRequest = Math.Clamp(description.HeightRequest + e.TotalY, 50, (DeviceDisplay.MainDisplayInfo.Height/ DeviceDisplay.MainDisplayInfo.Density) - 250);
                    //border.TranslationY += e.TotalY;
                    break;
                case GestureStatus.Completed:
                    carouselview.IsSwipeEnabled = true;
                    break;
                default:
                    carouselview.IsSwipeEnabled = true;
                    break;
            }
        }
    }

}