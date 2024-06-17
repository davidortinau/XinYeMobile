using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYeMobile.ViewModels
{
    public partial class CommentEntryPopupViewModel:ObservableObject
    {
        [ObservableProperty]
        private string? _content = string.Empty;
        public CommentEntryPopupViewModel() 
        {
            
        }

       public void UpdateContent(string content)
        {
            Content = content;
        }

    }
}
