using System;
using System.Collections.Generic;

namespace wsrHospital.Repos
{
    public partial class Result
    {
        public Result()
        {
            Appointmen = new HashSet<Appointman>();
        }

        public int IdResult { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Appointman> Appointmen { get; set; }
    }
}
