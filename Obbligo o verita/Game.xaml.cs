using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Obbligo_o_verita.Resources;


namespace Obbligo_o_verita
{
    public partial class Game : PhoneApplicationPage
    {
        FornisciQuesito fornitore;
        string choice;
        int i, count=0,s=0;
        // Costruttore
        string temp;

        public Game()
        {
            InitializeComponent();
            fornitore = new FornisciQuesito();
        }

  
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            obbligo.Text = AppResources.Obbligo;
            verita.Text = AppResources.Verità;
            nomeGioc.Visibility = Visibility.Visible;
            nomeGioc.Text = VarGlobal.nomGioc[count];
        }

        private void thruthOrDare(object sender, System.Windows.Input.GestureEventArgs e)
        {
            choice = ((TextBlock)sender).Text;
            Gioca(this, e);

        }
        private void Gioca(object sender, RoutedEventArgs e)
        {
            obbligo.Visibility = Visibility.Collapsed;
            verita.Visibility = Visibility.Collapsed;
            instr.Visibility = Visibility.Visible;
            immagine.Visibility = Visibility.Visible;
            done.Visibility = Visibility.Visible;
            refused.Visibility = Visibility.Visible;
            done.Text = AppResources.Done;
            refused.Text = AppResources.Refused;

            /*
            //Inserisco in una stringa il nome del db da caricare e lo carico 
            string db = "Databases/"+choice + VarGlobal.scelta.ToString() + ".xml";
           // instr.Text = db;
            loadedCustomData = XDocument.Load(db);
            //Genero un numero casuale tra 1 e 100 (Il numero varia da db a db) e carico la domanda con quell'id

            int RandomId = 0;
            RandomId = rnd.Next(1, 101);
            var domanda = from c in loadedCustomData.Descendants("Richiesta")
                          where c.Attribute("id").Value == RandomId.ToString()
                          select c.Attribute("Contenuto").Value;
            //Assegno a una variabile temporanea il valore della domanda caricata, per verificare che non ci siano istanze di aaa
            temp = domanda.First().ToString();*/

            Domanda scelta = fornitore.getNextDomanda(choice,count);
            /*
            //Se c'è aaa
            if (scelta.Contains("aaa"))
            {   //Lo sostituisco con il nome scelto a caso di un giocatore 
                RandomId = rnd.Next(0, VarGlobal.numGioc);
                temp = temp.Replace("aaa", VarGlobal.nomGioc[RandomId]);
            }*/
            //Infine assegno al Textblock la domanda trovata
            instr.Text = scelta.getRichiesta();
        }

        private void refused_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            VarGlobal.punteggio[count] -= 5;
            count++;
            if (count == VarGlobal.numGioc)
            {
                NavigationService.Navigate(new Uri("/punteggio.xaml", UriKind.Relative));
            }
            else
            {
            obbligo.Visibility = Visibility.Visible;
            verita.Visibility = Visibility.Visible;
            instr.Visibility = Visibility.Collapsed;
            immagine.Visibility = Visibility.Collapsed;
            done.Visibility = Visibility.Collapsed;
            refused.Visibility = Visibility.Collapsed;

            PhoneApplicationPage_Loaded(this, e);
            }
        
        }

        private void done_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            instr.Visibility = Visibility.Collapsed;
            immagine.Visibility = Visibility.Collapsed;
            done.Visibility = Visibility.Collapsed;
            refused.Visibility = Visibility.Collapsed;

            //Inserisco nella Source di a1 a2 a3 a4 le stelle vuote
            a1.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
            a2.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
            a3.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
            a4.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
            a5.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;

            //Rendo le stelle vuote visibili
            a1.Visibility = Visibility.Visible;
            a2.Visibility = Visibility.Visible;
            a3.Visibility = Visibility.Visible;
            a4.Visibility = Visibility.Visible;
            a5.Visibility = Visibility.Visible;
            
        }

        private void a_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image star = (Image)sender;
            string sub = star.Name;
            string sub2 = sub.Substring(1);
            int sub3 = Convert.ToInt32(sub2);

            
            #region IN BASE ALLA STELLA CHE TAPPO COLORO QUEST'ULTIMA PIU'LE PRECENDETI

            switch (sub3)
            {
                case 1:
                    {   
                        //Inserisco nella Sourse di a1 la stella piena
                        a1.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;

                        a2.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        a3.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        a4.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        a5.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        s = 1;        
                        break;
                    }
                case 2:
                    {
                        //Inserisco nella Sourse di a1 a2 la stella piena
                        a1.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a2.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;

                        a3.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        a4.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        a5.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        s = 2;              
                        break;
                    }
                case 3:
                    {
                        //Inserisco nella Sourse di a1 a2 a3 la stella piena
                        a1.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a2.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a3.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;

                        a4.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        a5.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        s = 3;                  
                        break;
                    }
                case 4:
                    {
                        //Inserisco nella Sourse di a1 a2 a3 a4 la stella piena
                        a1.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a2.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a3.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a4.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;

                        a5.Source = new ImageSourceConverter().ConvertFromString("/Img/emptyStar.png") as ImageSource;
                        s = 4;                  
                        break;

                    }
                case 5:
                    {
                        //Inserisco nella Sourse di a1 a2 a3 a4 a5 la stella piena
                        a1.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a2.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a3.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a4.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        a5.Source = new ImageSourceConverter().ConvertFromString("/Img/fullStar.png") as ImageSource;
                        s = 5;
                        break;
                      }
                        
            }
            #endregion
            
            //Rendo visibile il bottone per confermare la scelta
            ok.Visibility = Visibility.Visible;
            ok.Text = AppResources.Avanti;

        }

        private void ok_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            #region IN BASE AL VALORE DI s, OTTENUTO NELLO SWITCH PRECEDENTE, ASSEGNO UN PUNTEGGIO

            switch (s)
            {
                case 1:
                    {
                        VarGlobal.punteggio[count] += 5;
                        break;
                    }
                case 2:
                    {
                        VarGlobal.punteggio[count] += 10;
                        break;
                    }
                case 3:
                    {
                        VarGlobal.punteggio[count] += 15;
                        break;
                    }
                case 4:
                    {
                        VarGlobal.punteggio[count] += 20;
                        break;

                    }
                case 5:
                    {
                        VarGlobal.punteggio[count] += 25;
                        break;
                    }

            }
            #endregion

            count++;

            if (count == VarGlobal.numGioc)
            {
                NavigationService.Navigate(new Uri("/punteggio.xaml", UriKind.Relative));
            }
            else
            {
                a1.Visibility = Visibility.Collapsed;
                a2.Visibility = Visibility.Collapsed;
                a3.Visibility = Visibility.Collapsed;
                a4.Visibility = Visibility.Collapsed;
                a5.Visibility = Visibility.Collapsed;
                ok.Visibility = Visibility.Collapsed;

                obbligo.Visibility = Visibility.Visible;
                verita.Visibility = Visibility.Visible;

                RoutedEventArgs g = new RoutedEventArgs();
                PhoneApplicationPage_Loaded(this, g);


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
                //Azzero i punteggi 
                for (i = 0; i < VarGlobal.numGioc; i++)
                {
                    VarGlobal.punteggio[i] = 0;
                }
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        } 
     
    }
}