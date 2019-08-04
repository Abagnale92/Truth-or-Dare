using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Obbligo_o_verita.Resources;

namespace Obbligo_o_verita
{
    public partial class info : PhoneApplicationPage
    {
        
        public info()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            infop.Text = AppResources.Info;
        }

    }
}