using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuntimeScript
{
    public class Actor
    {
        public Actor()
        {
            m_ScriptMgr = new ScriptManager();
        }

        public void Load(ActorData actorData)
        {
            m_ScriptMgr.Init();

            Id = GenUniqueId();
            Name = actorData.Name;
            
            foreach (ScriptData scriptData in actorData.ScriptList)
            {
                ScriptClassInstance script = new ScriptClassInstance();
                script.Init(this, scriptData);

                m_ScriptMgr.AddScript(script);
            }
            m_ScriptMgr.Load();
        }

        public void Tick(double dt)
        {
            m_ScriptMgr.Tick(dt);
        }

        public void Exit()
        {
            m_ScriptMgr.Exit();
        }

        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public string Name 
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public ScriptManager Script
        {
            get { return m_ScriptMgr; }
        }

        public int GenUniqueId()
        {
            m_UniqueId++;
            return m_UniqueId;
        }

        protected int m_Id = -1;

        protected string m_Name = "";

        protected ScriptManager m_ScriptMgr = null;

        protected static int m_UniqueId = 0;

    }
}
