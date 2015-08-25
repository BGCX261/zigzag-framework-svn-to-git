using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using Zigzag.Common;


namespace Zigzag.Loader
{
    public partial class ZigzagWin: Form
    {
        private BufferedGraphicsContext mGraphContext;
        private BufferedGraphics mBuffer1;
        private int mIntTime = 0;
        private int mIntMaxTime = 60;
        private Boolean m_blnIsLoading;
        private Font mFont;
        private Timer mFormsTimer;
        private HighResTimer mHighResTimer;
        private ZigzagApp mApp;

        public ZigzagWin(string [] argv)
        {
            InitializeComponent();

            mFont = new Font("Arial", 10);

            mApp = new ZigzagApp();
            mApp.Init(argv);
            mHighResTimer = new HighResTimer();

            mFormsTimer = new System.Windows.Forms.Timer();
            mFormsTimer.Interval = 30; // 100 milliseconds is a tenth of a second
            mFormsTimer.Tick += new System.EventHandler(this.TimerEventProcessor);

            this.MouseClick += new MouseEventHandler(On_pnlViewPort_Click);
            this.SizeChanged += new EventHandler(On_pnlViewPort_Size);
            this.Load += new EventHandler(DashFireWin_Load);
        }

        void DashFireWin_Load(object sender, EventArgs e)
        {
            m_blnIsLoading = true;

            mGraphContext = BufferedGraphicsManager.Current;

            ReloadSteeringScenario();
        }

        private void ReloadSteeringScenario()
        {
            m_blnIsLoading = true;

            mHighResTimer.Stop();
            mFormsTimer.Stop();

            mBuffer1 = mGraphContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            mBuffer1.Graphics.Clear(Color.White);

            ReDraw();

            mFormsTimer.Start();
            mHighResTimer.Start();

            m_blnIsLoading = false;
        }

        private void ReDraw()
        {
            mBuffer1.Graphics.Clear(Color.White);

            mApp.Render(mBuffer1.Graphics, mHighResTimer.ElapsedTime);

            mBuffer1.Graphics.DrawString(String.Format("FPS: {0}", mHighResTimer.FPS.ToString("0.##")), mFont, Brushes.DimGray, 2, 2);

            mBuffer1.Render();
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            mHighResTimer.Update();

            mIntTime = mIntTime + 1;

            if (mIntTime > mIntMaxTime)
            {
                mIntTime = 0;
            }

            mApp.Tick(mHighResTimer.ElapsedTime);

            ReDraw();
        }

        private void On_pnlViewPort_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else
            {

            }
        }

        private void On_pnlViewPort_Size(object sender, EventArgs e)
        {
            if (!m_blnIsLoading)
            {
                ReloadSteeringScenario();
            }
        }
    }
}