using System;
using System.Collections.Generic;

namespace wsrHospital.Repos
{
    public partial class Recomendation
    {
        public Recomendation()
        {
            Appointmen = new HashSet<Appointman>();
        }

        public int IdRecom { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Appointman> Appointmen { get; set; }
    }
}
