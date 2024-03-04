using System;
using System.Collections.Generic;

namespace Hospital_MVC.Models
{
    public partial class Doctor
    {
        public int IdDoctor { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Dadname { get; set; }
        public int TypeDoctorIdTypeDoctor { get; set; }
        public int AppointmenIdAppointmen { get; set; }

        public virtual Appointman AppointmenIdAppointmenNavigation { get; set; } = null!;
        public virtual TypeDoctor TypeDoctorIdTypeDoctorNavigation { get; set; } = null!;
    }
}
