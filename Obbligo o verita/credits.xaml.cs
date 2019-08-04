using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Obbligo_o_verita
{
    public partial class credits : PhoneApplicationPage
    {
        
        public credits()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
               
        }

        private void EMailLink_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Subject = "Hello!";
            emailComposeTask.Body = "message body";
            emailComposeTask.To = "aresdev@outlook.it";
            emailComposeTask.Show();
        }

        private void facebook_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();

            webBrowserTask.Uri = new Uri("https://www.facebook.com/pages/ARES/354148764721989", UriKind.Absolute);

            webBrowserTask.Show();
        }

        private void twitter_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();

            webBrowserTask.Uri = new Uri("https://twitter.com/aresdev", UriKind.Absolute);

            webBrowserTask.Show();
        }

        private void oa_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();

            webBrowserTask.Uri = new Uri("http://www.windowsphone.com/it-IT/store/publishers?publisherId=AresDevelop&appId", UriKind.Absolute);

            webBrowserTask.Show();
        }

        

    }
}