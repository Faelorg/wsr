using System;
using System.Collections.Generic;

namespace Hospital_MVC.Models
{
    public partial class TypeDoctor
    {
        public TypeDoctor()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int IdTypeDoctor { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
