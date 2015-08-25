using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;

using RuntimeScript;

namespace Zigzag.Loader
{
    class ScriptFeature : Feature
    {
        public ScriptFeature()
            : base()
        {

        }

        public override void Init()
        {
            ActorManager.Instance.Init();

            LoadScriptLib();
            LoadScriptRoot();

            m_ScriptRoot_OnLoad.Invoke(m_ScriptRoot, null);
        }

        public override void Tick(double dt)
        {
            m_ScriptRoot_OnTick.Invoke(m_ScriptRoot, null);
            ActorManager.Instance.Tick(dt);
        }

        public override void Exit()
        {
            m_ScriptRoot_OnExit.Invoke(m_ScriptRoot, null);
            ActorManager.Instance.Exit();
        }

        private void LoadScriptLib()
        {
            string binPath = System.Windows.Forms.Application.StartupPath;
            string dllPath = binPath + "\\UserDef.dll";
            m_Assembly  = Assembly.LoadFile(dllPath);   
        }

        public void LoadScriptRoot()
        {
            Type mTypeScriptRoot = m_Assembly.GetType("RuntimeScript.ScriptRoot");
            m_ScriptRoot = (RuntimeScriptRoot)(Activator.CreateInstance(mTypeScriptRoot));

            m_ScriptRoot_OnLoad = mTypeScriptRoot.GetMethod("OnLoad");
            m_ScriptRoot_OnTick = mTypeScriptRoot.GetMethod("OnTick");
            m_ScriptRoot_OnExit = mTypeScriptRoot.GetMethod("OnExit");
        }

        private Assembly m_Assembly = null;

        private RuntimeScriptRoot m_ScriptRoot = null;

        private MethodInfo m_ScriptRoot_OnLoad = null;

        private MethodInfo m_ScriptRoot_OnTick = null;

        private MethodInfo m_ScriptRoot_OnExit = null;
    }
}
