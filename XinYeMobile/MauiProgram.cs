using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using XinYeMobile.Pages;
using XinYeMobile.Service;
using XinYeMobile.ViewModels;
using MauiIcons.Material;
using MauiIcons.Fluent;
using MauiIcons.Material.Sharp;
using MauiIcons.Material.Outlined;
using XinYeMobile.Models.QuestionBankModels;
using XinYeMobile.Pages.Tools;

namespace XinYeMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .UseFFImageLoading()
                .UseMaterialMauiIcons()
                .UseFluentMauiIcons()
                .UseMaterialSharpMauiIcons()
                .UseMaterialOutlinedMauiIcons()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseVersionTracking();
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            //注入各项服务
            builder.Services.AddSingleton<IHttpsClientHandlerService,HttpsClientHandlerService>();
            builder.Services.AddTransient<IRestService,RestService>();
            //注入页面
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<QuestionPracticeViewModel>();
            builder.Services.AddSingleton<QuestionPracticePage>();
            builder.Services.AddSingleton<CalculatorPopup,CalculatorPopupViewModel>();
            builder.Services.AddTransientPopup<AnswerCardPopup, AnswerCardPopupViewModel>();
            builder.Services.AddTransientPopup<CommentPopup, CommentPopupViewModel>();
            builder.Services.AddTransientPopup<CommentEntryPopup, CommentEntryPopupViewModel>();
            return builder.Build();
        }
    }
}
