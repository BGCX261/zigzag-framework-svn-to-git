using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuntimeScript
{
    public class ScriptData
    {
        public ScriptData()
        {

        }

        public string ScriptClass 
        {
            get { return m_ScriptClass ; }
            set { m_ScriptClass = value; }
        }

        public string ScriptLib 
        {
            get { return m_ScriptLib ; }
            set { m_ScriptLib = value; }
        }

        public string m_ScriptClass = "";

        public string m_ScriptLib = "";

        public Dictionary<string, string> m_Parameters = null;
    }


    public class ActorData
    {
        public ActorData()
        {
            m_ScriptList = new List<ScriptData>();
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string TemplateName
        {
            get { return m_TemplateName; }
            set { m_TemplateName = value; }
        }

        public void AddScriptData(ScriptData script)
        {
            m_ScriptList.Add(script);
        }

        public List<ScriptData> ScriptList
        {
            get { return m_ScriptList; }
        }

        public string m_Name = "";

        public string m_TemplateName = "";

        public List<ScriptData> m_ScriptList = null;

    }
}
