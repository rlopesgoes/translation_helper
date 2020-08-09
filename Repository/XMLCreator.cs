using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLEditor.Models;

namespace XMLEditor.Repository
{
    public class XMLCreator
    {
        public String CreateXML(List<Translation> trans)
        {
            XDocument doc = new XDocument();
            var root = new XElement("map");
            var lng = trans[0].Lng;
            foreach (var node in trans)
            {
                var el = new XElement("add");
                var at1 = new XAttribute("name", node.Key);
                var at2 = new XAttribute("text", node.Value);
                
                el.Add(at1);
                el.Add(at2);
                root.Add(el);
            }
            doc.Add(root);
            File.WriteAllText("appdata/tmp/lng-" + lng + ".xml", doc.ToString());
            return doc.ToString();

        }
    }
}
