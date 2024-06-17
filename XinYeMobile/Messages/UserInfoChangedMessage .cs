using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYeMobile.Messages
{
    public class UserInfoChangedMessage : ValueChangedMessage<bool>
    {
        public UserInfoChangedMessage(bool value) : base(value)
        {
        }
    }
}
