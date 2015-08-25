using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace RuntimeScript
{
    public class ScriptClass
    {
        public virtual void OnActive()
        {

        }

        public virtual void OnLoad()
        {

        }

        public virtual void OnBeginFrame()
        {

        }

        public virtual void OnFrame()
        {

        }

        public virtual void OnEndFrame()
        {

        }

        public virtual void OnDeactive()
        {

        }

        public string Name
        {
            get { return m_Instance.Name; }
        }

        public void SetName(string name)
        {
            m_Instance.Name = Name;
        }

        public Actor Owner
        {
            get { return m_Instance.Owner; }
        }

        public ScriptClassInstance Instance
        {
            get {return m_Instance; }
            set 
            { 
                m_Instance = value;
            }
        }

        protected ScriptClassInstance m_Instance = null;
    }
}
