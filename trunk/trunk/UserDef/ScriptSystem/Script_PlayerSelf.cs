using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RuntimeScript
{
    public class Script_PlayerSelf : ScriptClass 
    {
        public override void OnLoad()
        {
            System.Console.WriteLine("Script_PlayerSelf OnLoad");
            System.Console.WriteLine("Name:{0}", Name);
            System.Console.WriteLine("ActorName:{0}, Id:{1}", this.Owner.Name, this.Owner.Id);
        }

        public override void OnBeginFrame()
        {

        }

        public override void OnFrame()
        {

        }
    }
}
