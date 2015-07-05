using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MinhaEstante.Common
{
    public class MessageBox
    {
        public static async void Show(string mensagem)
        {
            await new MessageDialog(mensagem).ShowAsync();
        }
    }
}
