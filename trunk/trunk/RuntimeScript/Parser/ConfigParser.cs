using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RuntimeScript
{
    public class ConfigParser
    {
        public static ActorData ParserScript(string file)
        {
            XmlDocument xmlDoc=new XmlDocument();
            xmlDoc.Load(file);

            XmlNode root = xmlDoc.SelectSingleNode("Actor"); 
            XmlNode name = root.SelectSingleNode("/Actor/Name");


            return null;
        }
    }
}
