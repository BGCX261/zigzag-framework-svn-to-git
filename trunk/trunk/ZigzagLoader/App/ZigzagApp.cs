using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Zigzag.Loader
{
    class ZigzagApp
    {
        public ZigzagApp()
        {

        }

        public void Init(string [] argv)
        {
            m_GraphicFeature = new GraphicFeature();
            m_ScriptFeature = new ScriptFeature();

            m_GraphicFeature.Init();
            m_ScriptFeature.Init();
        }

        public void Tick(double dt)
        {
            m_GraphicFeature.Tick(dt);
            m_ScriptFeature.Tick(dt);
        }

        public void Render(Graphics g, double dt)
        {
            m_GraphicFeature.Render(g, dt);
        }

        public void Exit()
        {
            m_GraphicFeature.Exit();
            m_ScriptFeature.Exit();
        }

        private GraphicFeature m_GraphicFeature = null;
        private ScriptFeature m_ScriptFeature = null;

    }
}
