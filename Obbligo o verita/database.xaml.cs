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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System.Xml.Linq;
using System.Xml.Serialization;
using Obbligo_o_verita.Resources;

namespace Obbligo_o_verita
{
    public partial class database : PhoneApplicationPage
    {
     
        public database()
        {
            InitializeComponent();

        }
        XDocument loadedCustomData = null;
        String choice, db;
        int chePall = 0;
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            visualizza.Text = AppResources.Visualize;
            inserisci.Text = AppResources.Insert;
        }

        private void visualizza_Tap(object sender, GestureEventArgs e)
        {
            TextBlock mandante = (TextBlock)sender;
            if (mandante.Name == "inserisci")
                chePall = 1;
            visualizza.Visibility = Visibility.Collapsed;
            inserisci.Visibility = Visibility.Collapsed;
            normal.Visibility = Visibility.Visible;
            hot.Visibility = Visibility.Visible;
            boilent.Visibility = Visibility.Visible;
            plus.Visibility = Visibility.Visible;
            maggior.Visibility = Visibility.Visible;
            coming.Visibility = Visibility.Collapsed;
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

            obbligo.Visibility = Visibility.Visible;
            verita.Visibility = Visibility.Visible;
            obbligo.Text = AppResources.Obbligo;
            verita.Text = AppResources.Verità;
            normal.Visibility = Visibility.Collapsed;
            hot.Visibility = Visibility.Collapsed;
            boilent.Visibility = Visibility.Collapsed;
            plus.Visibility = Visibility.Collapsed;
            maggior.Visibility = Visibility.Collapsed;
        }

        private void thruthOrDare(object sender, System.Windows.Input.GestureEventArgs e)
        {
            choice = ((TextBlock)sender).Text;

            //Inserisco in una stringa il nome del db da caricare e lo carico 
            db = "Databases/"+choice + VarGlobal.scelta.ToString() + ".xml";
            // instr.Text = db;
            loadedCustomData = XDocument.Load(db);

            if (chePall == 0)
                visualizzazione(this, e);
            else
                insert(this, e);
        }

        private void visualizzazione(object sender, RoutedEventArgs e)
        {
            obbligo.Visibility = Visibility.Collapsed;
            verita.Visibility = Visibility.Collapsed;
            lista.Visibility = Visibility.Visible;
            
            //Inserisco come sorgente di informazioni della lista il campo Contenuto del database
            lista.ItemsSource = from c in loadedCustomData.Descendants("Richiesta")
                                select c.Attribute("Contenuto").Value;

        }

        private void insert(object sender, GestureEventArgs e)
        {
            obbligo.Visibility = Visibility.Collapsed;
            verita.Visibility = Visibility.Collapsed;

            testoIn.Visibility = Visibility.Visible;
          

        }

        /*public void testoIn_TextChanged(object sender, TextChangedEventArgs e)
        {  
            // StringBuilder sb = new StringBuilder();

            /*XElement root = new XElement("Richiesta");
             root.Add(new XAttribute("id", id+1));
             root.Add(new XAttribute("Richiesta", aggiunta));
             loadedCustomData.Element("Richiesta").Add(root);*/
            // TextWriter tr = new StringWriter(sb);
            // loadedCustomData.Save(
            // loadedCustomData.Save( 


        private void testoIn_TextChanged(object sender, RoutedEventArgs e)
        {
            XElement temp = loadedCustomData.Root;
            XElement last = (XElement)temp.LastNode;
            int id = Convert.ToInt32(last.Attribute("id").Value);
            //asdad.Text = id.ToString();
            string aggiunta = testoIn.Text;

            loadedCustomData.Root.Add(
               new XElement("Richiesta",
                                  new XAttribute("id", id + 1),
                                  new XAttribute("Contenuto", aggiunta)));


            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(db, FileMode.Append ,FileAccess.Write, myIsolatedStorage))
                {
                    loadedCustomData.Save(isoStream);
                    isoStream.Close();
                }
            }

            lista.Visibility = Visibility.Visible;
            testoIn.Visibility = Visibility.Collapsed;
          
            lista.ItemsSource = from c in loadedCustomData.Descendants("Richiesta")
                                select c.Attribute("Contenuto").Value;


        }

     
    }
}



