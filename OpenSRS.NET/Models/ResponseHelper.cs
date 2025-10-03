using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OpenSRS.NET.Models
{
    public static class ResponseHelper
    {
        public static Dictionary<string, string> ParseAttributes(string text)
        {
            var doc = XDocument.Parse(text);

            var itemEl = doc.XPathSelectElement(@"//item[@key=""attributes""]/dt_assoc");

            return ReadAssoc(itemEl);
        }

        public static Dictionary<string, string> GetAttributesAsDictionary(XDocument doc)
        {
            var itemEl = doc.XPathSelectElement(@"//item[@key=""attributes""]/dt_assoc");

            return ReadAssocAsDic(itemEl);
        }

        public static Dictionary<string, string> ReadAssocAsDic(XElement dtAssocEl)
        {
            if (dtAssocEl is null) throw new ArgumentNullException(nameof(dtAssocEl));

            var expando = new Dictionary<string, string>();

            foreach (var el in dtAssocEl.Elements("item"))
            {
                var keyValue = el.Attribute("key");
                if (keyValue != null)
                {
                    expando.Add(keyValue.Value, el.Value);
                }
            }

            return expando;
        }

        public static Dictionary<string, string> ReadAssoc(XElement dtAssocEl)
        {
            var expando = new Dictionary<string, string>();

            foreach (var el in dtAssocEl.Elements("item"))
            {
                var keyValue = el.Attribute("key");
                if (keyValue != null)
                {
                    expando.Add(keyValue.Value, el.Value);
                }
            }

            return expando;
        }

        public static IEnumerable<Dictionary<string, string>> ReadArray(XElement dtArrayEl)
        {
            foreach (var item in dtArrayEl.Elements("item"))
            {
                var i = item.Element("dt_assoc");
                if (i == null)
                    continue;
                yield return ReadAssoc(i);
            }
        }

        /*
        <dt_array>
          <item key="0">
            <dt_assoc>
              <item key="domain">carbonmade.com</item>
              <item key="status">available</item>
             </dt_assoc>
           </item>
         </dt_array>
        */
    }
}
