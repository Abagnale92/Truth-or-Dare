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
    public partial class Choices : PhoneApplicationPage
    {

        int i = 0;
        // Costruttore
        public Choices()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            _new.Text = AppResources.Nuova;
            //svuoto la textblock del nome del Giocatore per evitare che sia SPORCAAA e modifico l'instr
            nomeGioc.Text = "";
            instr.Text = AppResources.Hello + (i+1).ToString() + "\n"+ AppResources.Inserisci;
            nextPlay.Text = AppResources.Next;
            //Se il giocatore da inserire è l'ultimo sostituisco la scritta "Prossimo Giocatore" con "Fine"
            if ((i + 1) == VarGlobal.numGioc)
            {
                nextPlay.Text = AppResources.End;
            }
           
        }

       

        private void TextBlock_Tap(object sender, GestureEventArgs e)
        {
            //Quando clicchi su avanti 
            instr.Text = AppResources.Scegli;
            normal.Visibility = Visibility.Visible;
            hot.Visibility = Visibility.Visible;
            boilent.Visibility = Visibility.Visible;
            plus.Visibility = Visibility.Visible;
            maggior.Visibility = Visibility.Visible;
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            String choice = ((Button)sender).Content.ToString();

            switch (choice)
            {
                case "normal": VarGlobal.scelta = 1; break;
                case "hot": VarGlobal.scelta = 2; break;
                case "boilent": VarGlobal.scelta = 3; break;
            }
            NavigationService.Navigate(new Uri("/Game.xaml", UriKind.Relative));
        }

      

        private void nextTap(object sender, GestureEventArgs e)
        {
            if (nomeGioc.Text == "")
                VarGlobal.nomGioc[i] = "Player " + (i + 1);
            else
                VarGlobal.nomGioc[i] = nomeGioc.Text;

          
            if ((i + 1) < VarGlobal.numGioc)
            {
                i++;
                PhoneApplicationPage_Loaded(this, e);
            }
               
            else
            {
                nextPlay.Visibility = Visibility.Collapsed;
                nomeGioc.Visibility = Visibility.Collapsed;
                instr.Text = AppResources.Scegli;
                normal.Visibility = Visibility.Visible;
                hot.Visibility = Visibility.Visible;
                boilent.Visibility = Visibility.Visible;
                plus.Visibility = Visibility.Visible;
                maggior.Visibility = Visibility.Visible;
            }

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

                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        } 
    }
}