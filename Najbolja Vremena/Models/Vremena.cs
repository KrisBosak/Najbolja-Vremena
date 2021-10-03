using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Najbolja_Vremena.Models
{
    public class Vremena
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime Vrijeme { get; set; }

        public Vremena()
        {

        }
    }
}
