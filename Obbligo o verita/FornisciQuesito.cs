using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Obbligo_o_verita
{
    class FornisciQuesito
    {
        public const int NORMAL = 1;
        public const int HOT = 2;
        public const int BOILENT = 3;

        private List<int> idUsati;

        private Random rnd = new Random(DateTime.Now.Millisecond);
        private XDocument loadedCustomData = null;

        

        public FornisciQuesito()
        {
            idUsati = new List<int>();
        }
        public Domanda getNextDomanda(String dbName, int giocatore)
        {
            int numTentativi = 0;
            int maxDom = 0;
              //Inserisco in una stringa il nome del db da caricare e lo carico 
            string db = "Databases/"+ dbName + VarGlobal.scelta.ToString() + ".xml";
            loadedCustomData = XDocument.Load(db);
            //Genero un numero casuale tra 1 e 100 (Il numero varia da db a db) e carico la domanda con quell'id
            if (dbName.Equals("obbligo") && VarGlobal.scelta == 3)
                maxDom = 107;
            else
                maxDom = 100;

            int RandomId = 0;
            do
            {
                RandomId = rnd.Next(1, maxDom);
                numTentativi++;
            } while (isUsed(RandomId) && numTentativi<=20);

            idUsati.Add(RandomId);
            var domanda = from c in loadedCustomData.Descendants("Richiesta")
                          where c.Attribute("id").Value == RandomId.ToString()
                          select c.Attribute("Contenuto").Value;
            Domanda scelta = new Domanda(RandomId, domanda.First().ToString());
            if (scelta.getRichiesta().Contains("aaa"))
                scelta = sostituisci(scelta, giocatore);

            return scelta;
        }
        public bool isUsed(int id)
        {
            bool used = false;
            foreach(int x in idUsati)
                if( x == id)
                    used = true;

            return used;
        }
        public Domanda sostituisci(Domanda inputDom, int giocatore)
        {
            int altroGiocatore;
            do{
                altroGiocatore = rnd.Next(0, VarGlobal.numGioc);
            }while(altroGiocatore == giocatore);

            String oldR = inputDom.getRichiesta();
            String newR = oldR.Replace("aaa", VarGlobal.nomGioc[altroGiocatore]);
            Domanda sostiuita = new Domanda(inputDom.getId(), newR);
            return sostiuita;
        }
    }
}
