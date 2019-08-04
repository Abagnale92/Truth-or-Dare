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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Obbligo_o_verita.Resources;


namespace Obbligo_o_verita
{
    public partial class MainPage : PhoneApplicationPage
    {

        //Determino un tipo Song
        // Song song = Song.FromUri("name", new Uri("Audio/Theme.mp3", UriKind.Relative));
        // Costruttore
        public MainPage()
        {
            InitializeComponent();
            VarGlobal.text1 = AppResources.Text1;
            VarGlobal.text2 = AppResources.Text2;

            play.Text = AppResources.Play;

            InitializeComponent();
            FrameworkDispatcher.Update();
            GestureEventArgs e = new GestureEventArgs();
            //     check_audio(this, e);

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Avvio l'animazione
            Storyboard1.Begin();

        }

        private void play_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/start.xaml", UriKind.Relative));
        }

        private void info_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/info.xaml", UriKind.Relative));
        }


        private void database_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/database.xaml", UriKind.Relative));
        }


        private void credits_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/credits.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }

        }

        /*    public void check_audio(object sender, GestureEventArgs e)
            {
                //Metto la canzone in loop e la faccio partire
                MediaPlayer.IsRepeating = true;


                //Se c'è già un valore in [Audio]
                if (VarGlobal.settings.Contains("audio"))
                {    //Controllo qual è 
                    bool checkAudio = (bool)VarGlobal.settings["audio"];
                    //Se l'audio non dovrebbe esserci
                    if (checkAudio == false)
                    {
                        //La imposto come partita per evitare problemi nel caso in cui riapra l'app una volta 
                        //settato a false l'audio (Non riparte riaprendola poichè quando clicco sull'immagine
                        //Cerca di avviare MediaPlayer.Resume(), ma poichè è stata messa in Pause() prima ancora 
                        //di partire,  non riesce a fare Resume, così invece ci riesce
                        MediaPlayer.Play(song);
                        //Lo fermo e metto l'immagine giusta
                        MediaPlayer.Pause();
                        audio.Source = new ImageSourceConverter().ConvertFromString("Img/audioOff.png") as ImageSource;
                    }
                    else
                    {  //Altrimenti lascio partire normalmente l'audio e metto l'immagine adatta
                        MediaPlayer.Play(song);
                        audio.Source = new ImageSourceConverter().ConvertFromString("Img/audioOn.png") as ImageSource;
                    }
                }
                //Se non c'è proprio, gli aggiungo il valore di default a true e faccio partire l'audio
                else
                {
                    VarGlobal.settings.Add("audio", true);
                    MediaPlayer.Play(song);
                }
            }

            private void audio_Tap(object sender, GestureEventArgs e)
            {
                //Quando clicco sul pulsante audio, se già c'era, lo fermo
                if ((bool)VarGlobal.settings["audio"])
                {
                    audio.Source = new ImageSourceConverter().ConvertFromString("Img/audioOff.png") as ImageSource;
                    VarGlobal.settings["audio"] = false;
                    MediaPlayer.Pause();
                }
                //Se non c'era l'audio, lo faccio partire
                else
                {
                    audio.Source = new ImageSourceConverter().ConvertFromString("Img/audioOn.png") as ImageSource;
                    VarGlobal.settings["audio"] = true;
                    FrameworkDispatcher.Update();
                    MediaPlayer.Resume();
               
                }
            } */



    }
}