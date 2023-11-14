using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Models
{
    internal class Klant
    {
        public int Id { get; set; }
        public string? Achternaam { get; set; }
        public string? Voornaam { get; set; }
        public DateTime Geboortedatum { get; set; }
    }
}
