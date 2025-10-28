using OpenSRS.NET.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace OpenSRS.NET
{
    internal static class Extensions
    {
        public static T ParseEnum<T>(string text, bool ignoreCase = false) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), text, ignoreCase);
        }

        public static string GetValueOrDefault(this IDictionary<string, string> dic, string key)
        {
            if (!dic.TryGetValue(key, out var value))
                return "";

            return value;
        }

        internal static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }

        internal static Dictionary<string, object> ObjectToDictionary(object instance)
        {
            var properties = instance.GetType().GetTypeInfo().GetProperties();

            var dic = new Dictionary<string, object>(properties.Length);

            foreach (var property in properties)
            {
                var prop = property.GetValue(instance, null);
                if (prop == null)
                    continue;
                dic[property.Name] = prop;
            }

            return dic;
        }

        internal static XElement ToDtAssoc(object parameters)
        {
            return ToDtAssoc(ObjectToDictionary(parameters));
        }

        internal static XElement ToDtAssoc(Dictionary<string, object> parameters)
        {
            var rootEl = new XElement("dt_assoc");

            foreach (var item in parameters)
            {
                if (item.Value != null)
                {
                    rootEl.Add(new XElement("item", new XAttribute("key", item.Key), item.Value));
                }
            }

            return rootEl;
        }

        internal static XElement ToDtArray(string[] items)
        {
            var element = new XElement("dt_array");

            int i = 0;

            foreach (var item in items)
            {
                element.Add(new XElement("item", new XAttribute("key", i.ToString()), item));

                i++;
            }

            return element;
        }

        internal static XElement ToDtArray(IEnumerable<IDtEl> items)
        {
            var arrayEl = new XElement("dt_array");

            int i = 0;

            foreach (var item in items)
            {
                arrayEl.Add(new XElement("item", new XAttribute("key", i.ToString()), item.ToDtAssoc()));

                i++;
            }

            return arrayEl;
        }
    }
}
