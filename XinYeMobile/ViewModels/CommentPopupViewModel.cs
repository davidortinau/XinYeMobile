using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XinYeMobile.Models;
using XinYeMobile.Service;

namespace XinYeMobile.ViewModels
{
    public partial class CommentPopupViewModel:ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CommentModel> _commentList = new ObservableCollection<CommentModel>();
        [ObservableProperty]
        private string _content = string.Empty;
        [ObservableProperty]
        private bool _isShowLoading = false;
        private IRestService _rest;
        private IPopupService _popup;
        public CommentPopupViewModel(IRestService restService,IPopupService popupService) 
        {
            _rest = restService;
            _popup = popupService;
        }

        public async Task UpdateQuestionId(string questionId)
        {
            try
            {
                //联网获取评论内容 
                var result = await _rest.GetAsync($"/Comment?objectId={questionId}");
                if (result.IsSuccessStatusCode)
                {
                    IsShowLoading = true;
                    var comments = result.Content.ReadAsStringAsync().Result;
                    QueryResponse<CommentModel> query = JsonSerializer.Deserialize<QueryResponse<CommentModel>>(comments);
                    CommentList = query.Data.ToObservableCollection();
                    IsShowLoading = false;
                }
                else
                {
                    //出错
                    var resp = result.Content.ReadAsStringAsync().Result;
                    if (string.IsNullOrEmpty(resp))
                    {
                        await Shell.Current.DisplayAlert("Error",$"Error!{result.StatusCode}","OK");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", resp, "OK");
                    }
                }
            }
            catch(Exception ex)
            {
                IsShowLoading = false;
            }
        }


        [RelayCommand]
        public async Task Entry(string input)
        {
            try
            {
                //传递数据到entry popup 
                await _popup.ShowPopupAsync<CommentEntryPopupViewModel>(onPresenting:vm=>vm.UpdateContent(Content));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
