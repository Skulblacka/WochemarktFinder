using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Klasse Stellt immer einen Datenstatz dar. Der datensatz wird an vom Manager in eine Liste gehalten.
/// erstellt von Tilmann Paczoch
/// </summary>
namespace IHKTest
{
    class Data
    {
        public String Bezirk { get; set; }
        public String Marktort { get; set; }
        public String Tage { get; set; }
        public String Zeiten { get; set; }
        public String Betreiber { get; set; }
        public String EMail { get; set; }
        public String WWW { get; set; }
        public String Bemerkungen { get; set; }
    }
}
