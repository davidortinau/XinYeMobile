using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYeMobile.Messages
{
    public class LoginStateChangedMessage : ValueChangedMessage<bool>
    {
        public LoginStateChangedMessage(bool value) : base(value)
        {
        }
    }
}
