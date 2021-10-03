using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Najbolja_Vremena.Models
{
    public class Vremena
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool Potvrdeno { get; set; }

        [Display(Name = "Vrijeme")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}")]
        public DateTime Vrijeme { get; set; }

        public Vremena()
        {
            
        }
    }
}
