using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuntimeScript
{
    public class ScriptManager
    {
        public ScriptManager()
        {
            m_ScriptDict = new Dictionary<string, ScriptClassInstance>();
        }

        public void Init()
        {

        }

        public void Load()
        {
            foreach (ScriptClassInstance script in m_ScriptDict.Values)
            {
                script.OnLoad();
            }

            foreach (ScriptClassInstance script in m_ScriptDict.Values)
            {
                script.OnActive();
            }
        }

        public void Tick(double dt)
        {
            foreach (ScriptClassInstance script in m_ScriptDict.Values)
            {
                script.OnBeginFrame();
            }

            foreach (ScriptClassInstance script in m_ScriptDict.Values)
            {
                script.OnFrame();
            }

            foreach (ScriptClassInstance script in m_ScriptDict.Values)
            {
                script.OnEndFrame();
            }
        }

        public void Exit()
        {
            foreach (ScriptClassInstance script in m_ScriptDict.Values)
            {
                script.OnDeactive();
            }
        }

        public void AddScript(ScriptClassInstance script)
        {
            if (script != null && m_ScriptDict != null && !m_ScriptDict.ContainsKey(script.Name))
            {
                m_ScriptDict.Add(script.Name, script);
            }
        }

        public ScriptClassInstance GetScript(string name)
        {
            if (m_ScriptDict != null && m_ScriptDict.Count > 0
                && m_ScriptDict.ContainsKey(name))
            {
                return m_ScriptDict[name];
            }
            return null;
        }

        private Dictionary<string, ScriptClassInstance> m_ScriptDict = null;
    }
}
