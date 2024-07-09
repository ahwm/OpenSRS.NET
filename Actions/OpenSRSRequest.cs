using System.Collections.Generic;
using System.Xml.Linq;

namespace OpenSRS.NET.Actions
{
    public abstract class OpenSRSRequest
    {
        private readonly string action;
        private readonly string @object;

        public OpenSRSRequest(string action, string @object)
        {
            this.action = action;
            this.@object = @object;
        }

        public virtual XElement ToXml()
        {
            return new XElement("OPS_envelope",
                new XElement("header",
                    new XElement("version", "0.9")
                ),
                new XElement("body",
                    new XElement("data_block",
                        new XElement("dt_assoc",
                            new XElement("item", new XAttribute("key", "protocol"), "XCP"),
                            new XElement("item", new XAttribute("key", "action"), action),
                            new XElement("item", new XAttribute("key", "object"), @object),

                            GetAttributes()
                        )
                    )
                )
            );
        }

        public virtual Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object>();
        }

        public virtual XElement GetAttributes() => new XElement("item", new XAttribute("key", "attributes"), Extensions.ToDtAssoc(GetParameters()));
    }
}
