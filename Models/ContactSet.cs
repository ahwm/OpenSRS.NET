using System.Xml.Linq;

namespace OpenSRS.NET.Models
{
    public sealed class ContactSet
    {
        public DomainContact Owner { get; set; } = new DomainContact();
        public DomainContact Admin { get; set; } = new DomainContact();
        public DomainContact Tech { get; set; } = new DomainContact();
        public DomainContact Billing { get; set; } = new DomainContact();

        public XElement ToAssocEl()
        {
            return Extensions.ToDtAssoc(new
            {
                owner = Owner != null ? Extensions.ToDtAssoc(Owner.GetParameters()) : null,
                admin = Admin != null ? Extensions.ToDtAssoc(Admin.GetParameters()) : null,
                tech = Tech != null ? Extensions.ToDtAssoc(Tech.GetParameters()) : null,
                billing = Billing != null ? Extensions.ToDtAssoc(Billing.GetParameters()) : null
            });
        }
    }
}
