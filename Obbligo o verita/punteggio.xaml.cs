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
    public partial class punteggio : PhoneApplicationPage
    {
        int i;
        public punteggio()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Chideo se vogliono fare un altro giro
            istr.Visibility = Visibility.Visible;
            SI.Visibility = Visibility.Visible;
            NO.Visibility = Visibility.Visible;

            istr.Text = AppResources.Continue;
            SI.Text = AppResources.Yes;
            NO.Text = AppResources.No;
        }

        private void Torna_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //Azzero i punteggi 
            for (i = 0; i < VarGlobal.numGioc; i++)
            {
                VarGlobal.punteggio[i] = 0;
            }
            //Rendo invisibile
            name.Visibility = Visibility.Collapsed;
            point.Visibility = Visibility.Collapsed;
            torna.Visibility = Visibility.Collapsed;
            //Torno al menu' principale
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void SI_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //Se premono SI

            //Li faccio navigare alla scelta della categoria
            NavigationService.Navigate(new Uri("/Game.xaml", UriKind.Relative));
            //Ritornano invisibili
            istr.Visibility = Visibility.Collapsed;
            SI.Visibility = Visibility.Collapsed;
            NO.Visibility = Visibility.Collapsed;
        }

        private void NO_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //Se premono NO

            //Ritornano invisibili
            istr.Visibility = Visibility.Collapsed;
            SI.Visibility = Visibility.Collapsed;
            NO.Visibility = Visibility.Collapsed;

            //Rendo visibile
            name.Visibility = Visibility.Visible;
            point.Visibility = Visibility.Visible;

            //Stampo i punteggi
            name.Text += AppResources.Player + "\n \n";
            point.Text += AppResources.Points +"\n \n";
            for (i = 0; i < VarGlobal.numGioc; i++)
            {
                name.Text += VarGlobal.nomGioc[i] + "\n";
                point.Text += VarGlobal.punteggio[i] + "\n";
            }
            //Rendo visibile il tasto ritorna al menu'
            torna.Text = AppResources.Back;
            torna.Visibility = Visibility.Visible;

        }

         protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show(VarGlobal.text2, VarGlobal.text1, MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.Cancel)
            {
                //SE L'UTENTE ANNULLA ALLORA BLOCCO LA FUNZIONE DEL TASTO INDIETRO
                e.Cancel = true;
            }
            else
            {
                while (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }
                //Azzero i punteggi 
                for (i = 0; i < VarGlobal.numGioc; i++)
                {
                    VarGlobal.punteggio[i] = 0;
                }
                //Rendo invisibile
                name.Visibility = Visibility.Collapsed;
                point.Visibility = Visibility.Collapsed;
                torna.Visibility = Visibility.Collapsed;
                //Torno al menu' principale
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        } 
       
    }
}