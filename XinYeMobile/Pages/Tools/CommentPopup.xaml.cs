using CommunityToolkit.Maui.Views;
using XinYeMobile.ViewModels;

namespace XinYeMobile.Pages.Tools;

public partial class CommentPopup : Popup
{
	public CommentPopup(CommentPopupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		comment.Size = new Size(height: 0.6*DeviceDisplay.MainDisplayInfo.Height/ DeviceDisplay.MainDisplayInfo.Density,width: DeviceDisplay.MainDisplayInfo.Width/DeviceDisplay.MainDisplayInfo.Density);
	}
}