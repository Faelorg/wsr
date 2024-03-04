using System;
using System.Collections.Generic;

namespace wsrHospital.Repos
{
    public partial class Card
    {
        public Card()
        {
            Appointmen = new HashSet<Appointman>();
            Pacients = new HashSet<Pacient>();
        }

        public int IdCard { get; set; }
        public DateTime? Dategive { get; set; }
        public DateTime? Datenext { get; set; }
        public DateTime? Datelast { get; set; }

        public virtual ICollection<Appointman> Appointmen { get; set; }
        public virtual ICollection<Pacient> Pacients { get; set; }
    }
}
