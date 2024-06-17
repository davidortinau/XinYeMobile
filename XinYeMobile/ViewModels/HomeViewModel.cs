using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Text.Json;
using System.Web;
using XinYeMobile.Messages;
using XinYeMobile.Models.QuestionBankModels;

using XinYeMobile.Service;

namespace XinYeMobile.ViewModels
{
    public partial class HomeViewModel: ObservableObject
    {

        //服务
        private readonly IRestService _rest;

        public HomeViewModel(IRestService restService) 
        {
            _rest = restService;
            Routing.RegisterRoute("Practice", typeof(QuestionPracticePage));
        }

        [RelayCommand]
        public async Task Goto()
        {
            try
            {
                await Shell.Current.GoToAsync("Practice");
            }
            catch(Exception ex) 
            {

            }
        }
    }
}
