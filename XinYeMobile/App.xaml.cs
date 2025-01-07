using XinYeMobile.Pages;
using XinYeMobile.ViewModels;

namespace XinYeMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
    {
            MainPage = new NavigationPage(
                            new HomePage(
                                activationState.Context.Services.GetService<HomeViewModel>()
                            ));
            
            return base.CreateWindow(activationState);
        }
    }
}
