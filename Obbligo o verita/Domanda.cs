using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obbligo_o_verita
{

    class Domanda
    {
        private int id { get; set; }
        private String richiesta { get; set; }

        public Domanda(int id, String richiesta)
        {
            this.id = id;
            this.richiesta = richiesta;
        }
        public int getId()
        {
            return id;
        }
        public String getRichiesta()
        {
            return richiesta;
        }


    }
}
