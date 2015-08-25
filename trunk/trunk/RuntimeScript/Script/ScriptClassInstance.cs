using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace RuntimeScript
{
    public class ScriptClassInstance
    {
        public void OnActive()
        {
            m_ScriptRoot_OnActive.Invoke(m_ScriptClass, null);
        }

        public void OnLoad()
        {
            m_ScriptRoot_OnLoad.Invoke(m_ScriptClass, null);
        }

        public void OnBeginFrame()
        {
            m_ScriptRoot_OnBeginFrame.Invoke(m_ScriptClass, null);
        }

        public void OnFrame()
        {
            m_ScriptRoot_OnFrame.Invoke(m_ScriptClass, null);
        }

        public void OnEndFrame()
        {
            m_ScriptRoot_OnEndFrame.Invoke(m_ScriptClass, null);
        }

        public void OnDeactive()
        {
            m_ScriptRoot_OnDeactive.Invoke(m_ScriptClass, null);
        }

        public void Init(Actor actor, ScriptData data)
        {
            string binPath = System.Environment.CurrentDirectory;
            string dllPath = binPath + "\\" + data.m_ScriptLib;
            string typeName = string.Format("RuntimeScript.{0}", data.m_ScriptClass);

            m_Assembly  = Assembly.LoadFile(dllPath);
            m_ScriptType = m_Assembly.GetType(typeName);
            m_ScriptClass = (ScriptClass)Activator.CreateInstance(m_ScriptType);

            m_ScriptRoot_OnActive = m_ScriptType.GetMethod("OnActive");
            m_ScriptRoot_OnLoad = m_ScriptType.GetMethod("OnLoad");
            m_ScriptRoot_OnBeginFrame = m_ScriptType.GetMethod("OnBeginFrame");
            m_ScriptRoot_OnFrame = m_ScriptType.GetMethod("OnFrame");
            m_ScriptRoot_OnEndFrame = m_ScriptType.GetMethod("OnEndFrame");
            m_ScriptRoot_OnDeactive = m_ScriptType.GetMethod("OnDeactive");

            Name = actor.Name;
            Owner = actor;

            m_ScriptClass.Instance = this;
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public void SetName(string name)
        {
            m_Name = name;
        }

        public Actor Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        public ScriptClass ScriptClass
        {
            get { return m_ScriptClass; }
            set { m_ScriptClass = value; }
        }

        protected string m_Name = "";

        protected Actor m_Owner = null;

        protected ScriptClass m_ScriptClass = null;

        protected Type m_ScriptType = null;

        private Assembly m_Assembly = null;

        private MethodInfo m_ScriptRoot_OnActive = null;

        private MethodInfo m_ScriptRoot_OnLoad = null;

        private MethodInfo m_ScriptRoot_OnBeginFrame = null;

        private MethodInfo m_ScriptRoot_OnFrame = null;

        private MethodInfo m_ScriptRoot_OnEndFrame = null;

        private MethodInfo m_ScriptRoot_OnDeactive = null;

    }
}
