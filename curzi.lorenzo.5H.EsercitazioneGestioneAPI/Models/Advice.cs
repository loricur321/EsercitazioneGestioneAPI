using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curzi.lorenzo._5H.EsercitazioneGestioneAPI.Models
{
    public class Advice
    {
        public Slip slip { get; set; }
    }

    public class Slip
    {
        public int id { get; set; }
        public string advice { get; set; }
    }

}
