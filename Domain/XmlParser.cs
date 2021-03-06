﻿/*****************************************************************
 XML TRANSLATION MANAGER
 A SIMPLE TOOL TO HELP MAINTAIN XML TRANSLATION FILES

 AUTHOR: RICARDO LOPES
 
 ****************************************************************/

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using XMLEditor.Models;

namespace XMLEditor.Domain
{
    public class XmlParser
    {

        public List<KeyV> GetTranslationKeysFromXML()
        {

            XDocument xdoc = XDocument.Load(@"appdata/lng-pt-br.xml");

            var dic = xdoc.Descendants("map").Descendants("add");

            var lst = new List<KeyV>();
            foreach (var n in dic)
            {
                var name = n.Attribute("name").Value;
                lst.Add(new KeyV() {  Key = name });

            }

            return lst;
        }
        public List<Translation> GetTranslationFromXML(String languageCode)
        {

            XDocument xdoc = XDocument.Load("appdata/lng-" + languageCode + ".xml");

            var dic = xdoc.Descendants("map").Descendants("add");

            var lst = new List<Translation>();
            foreach (var n in dic)
            {
                var name = n.Attribute("name").Value;
                String text;
                try
                {
                    text = n.Attribute("text").Value ?? String.Empty;
                }
                catch (Exception)
                {
                    text = String.Empty;
                }
                lst.Add(new Translation() { Lng= languageCode, Key = name, Value = text });
             
            }
            return lst;
        }
    }
}
