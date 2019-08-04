using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Obbligo_o_verita.Resources;

namespace Obbligo_o_verita
{
    public partial class start : PhoneApplicationPage
    {
       
        // Costruttore
        public start()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        { 
            _new.Text = AppResources.Nuova;
            instr.Text = AppResources.Add;
            next.Text = AppResources.Avanti;
            //Inizializzo il numero di giocatori a 2 (il minimo) e lo mostro nel Textblock
            VarGlobal.numGioc = 2;
            numGioc.Text = VarGlobal.numGioc.ToString();
           
        }

        private void add_Tap(object sender, GestureEventArgs e)
        {
            sub.Visibility = Visibility.Visible;
            //Aumento il numero di giocatori se richiesto, fino a 20.
            VarGlobal.numGioc++;
            numGioc.Text = VarGlobal.numGioc.ToString();
            //Se i giocatori sono 20 non permetto di aggiungerne
            if (VarGlobal.numGioc == 20)
            {
                add.Visibility = Visibility.Collapsed;
            }
           
        }

        private void sub_Tap(object sender, GestureEventArgs e)
        {
            VarGlobal.numGioc--;
            numGioc.Text = VarGlobal.numGioc.ToString();
           //Se i giocatori sono 2 non permetto di sottrarne
            if (VarGlobal.numGioc == 2)
                sub.Visibility = Visibility.Collapsed;
        }

        private void TextBlock_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Choices.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        
    }
}