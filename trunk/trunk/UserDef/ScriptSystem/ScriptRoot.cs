using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RuntimeScript
{
    public class ScriptRoot : RuntimeScriptRoot
    {
        public override void OnLoad()
        {
            System.Console.WriteLine("ScriptRoot load");

            ActorManager.LoadFromTemplate("PlayerSelf");
        }

        public override void OnTick()
        {
            //System.Console.WriteLine("ScriptRoot Tick");
        }

        public override void OnExit()
        {
            System.Console.WriteLine("ScriptRoot Exit");
        }
    }
}
