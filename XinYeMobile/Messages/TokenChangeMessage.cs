using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYeMobile.Messages
{
    public class TokenChangeMessage : ValueChangedMessage<bool>
    {
        public TokenChangeMessage(bool value) : base(value)
        {
        }
    }
}
