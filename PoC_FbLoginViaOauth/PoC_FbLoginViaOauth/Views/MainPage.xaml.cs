using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PoC_FbLoginViaOauth.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

            var apiRequest =
                "https://www.facebook.com/dialog/oauth?client_id="
                + "1586384741640378"
                + "&display=popup&response_type=code&redirect_uri=https://www.facebook.com/connect/login_success.html";


            web.Source = apiRequest;

            web.Navigated += Web_Navigated;
        }

        private void Web_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var auth_code = ExtractAccessTokenFromUrl(e.Url);

            if (auth_code != "")
            {

            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("login_success") && url.Contains("code"))
            {
                var auth_code = url.Replace("https://www.facebook.com/connect/login_success.html?code=", "");

                return auth_code;
            }

            return string.Empty;
        }
    }
}