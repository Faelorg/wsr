using System;
using System.Collections.Generic;

namespace wsrHospital.Repos
{
    public partial class Poli
    {
        public Poli()
        {
            Pacients = new HashSet<Pacient>();
        }

        public int IdPolis { get; set; }
        public int? Number { get; set; }
        public DateTime? Dateend { get; set; }

        public virtual ICollection<Pacient> Pacients { get; set; }
    }
}
