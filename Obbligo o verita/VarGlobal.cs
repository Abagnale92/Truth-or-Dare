using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;

namespace Obbligo_o_verita
{
    class VarGlobal
    {
        public static IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public static int numGioc = 0;
        //Variabile globale per i nomi dei giocatori
        public static string[] nomGioc = new string[20];
        //Variabile che conserva quale database prendere
        public static int scelta = 0;
        //Array per punteggio
        public static int[] punteggio =  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //Array temp
        public static int[] aUsed = new int[20];
        public static string text1, text2;
    }
}
