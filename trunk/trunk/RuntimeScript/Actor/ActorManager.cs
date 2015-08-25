using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuntimeScript
{
    public class ActorManager
    {
#region Singleton
        private static ActorManager s_Instance = new ActorManager();

        public static ActorManager Instance
        {
            get { return s_Instance; }
        }
#endregion

        private ActorManager()
        {
        }

        public void Init()
        {
            m_ActorDict = new Dictionary<int, Actor>();
        }

        public void Tick(double dt)
        {
            foreach (Actor actor in m_ActorDict.Values)
            {
                actor.Tick(dt);
            }
        }

        public void Exit()
        {
            foreach (Actor actor in m_ActorDict.Values)
            {
                actor.Exit();
            }
            m_ActorDict.Clear();
        }

        public void AddActor(Actor actor)
        {
            if (m_ActorDict != null
                && !m_ActorDict.ContainsKey(actor.Id))
            {
                m_ActorDict.Add(actor.Id, actor);
            }
        }

        public void RemoveActor(int id)
        {
            if (m_ActorDict != null && m_ActorDict.Count > 0
                && m_ActorDict.ContainsKey(id))
            {
                m_ActorDict.Remove(id);
            }
        }

        public Actor GetActor(int id)
        {
            if (m_ActorDict != null && m_ActorDict.Count > 0
                && m_ActorDict.ContainsKey(id))
            {
                return m_ActorDict[id];
            }
            return null;
        }

        public static Actor LoadFromTemplate(string template)
        {
            Actor actor = new Actor();

            string binPath = System.Environment.CurrentDirectory;
            string filePath = string.Format("{0}\\..\\..\\Asset\\ActorTemplate\\{1}.{2}", binPath, template, "xml");

            ActorData data = ConfigParser.ParserScript(filePath);

            ScriptData scriptData = new ScriptData();
            scriptData.m_ScriptClass = "Script_PlayerSelf";
            scriptData.m_ScriptLib = "UserDef.dll";

            ActorData actorData = new ActorData();
            actorData.Name = "PlayerSelf";
            actorData.TemplateName = "PlayerSelf";
            actorData.AddScriptData(scriptData);

            actor.Load(actorData);

            ActorManager.Instance.AddActor(actor);
            return null;
        }

        private Dictionary<int, Actor> m_ActorDict = null;
    }
}
