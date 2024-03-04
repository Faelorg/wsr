using System;
using System.Collections.Generic;

namespace wsrHospital.Repos
{
    public partial class TypeAppointman
    {
        public TypeAppointman()
        {
            Appointmen = new HashSet<Appointman>();
        }

        public int IdType { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Appointman> Appointmen { get; set; }
    }
}
