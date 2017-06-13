using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyDictionary.Views
{
    class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            Padding = new Thickness(0, Device.OS == TargetPlatform.iOS ? 20 : 0, 0, 0); /*kullanılan platform ios ise top 20 değilse 0 deme şekli*/

            Master = new MenuPage();
            Detail = new ListPage();
        }
    }
}
