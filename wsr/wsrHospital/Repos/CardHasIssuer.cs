using System;
using System.Collections.Generic;

namespace wsrHospital.Repos
{
    public partial class CardHasIssuer
    {
        public int CardIdCard1 { get; set; }
        public int IssuerIdIssuer { get; set; }

        public virtual Card CardIdCard1Navigation { get; set; } = null!;
        public virtual Issuer IssuerIdIssuerNavigation { get; set; } = null!;
    }
}
