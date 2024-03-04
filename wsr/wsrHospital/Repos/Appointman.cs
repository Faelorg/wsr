using System;
using System.Collections.Generic;

namespace wsrHospital.Repos
{
    public partial class Appointman
    {
        public Appointman()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int IdAppointmen { get; set; }
        public string? Name { get; set; }
        public int TypeAppointmenIdType { get; set; }
        public int RecomendationIdRecom { get; set; }
        public int ResultIdResult { get; set; }
        public int CardIdCard { get; set; }

        public virtual Card CardIdCardNavigation { get; set; } = null!;
        public virtual Recomendation RecomendationIdRecomNavigation { get; set; } = null!;
        public virtual Result ResultIdResultNavigation { get; set; } = null!;
        public virtual TypeAppointman TypeAppointmenIdTypeNavigation { get; set; } = null!;
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
