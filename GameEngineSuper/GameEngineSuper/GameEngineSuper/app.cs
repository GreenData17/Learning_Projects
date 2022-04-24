using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameEngineSuper.Engine;
using GameEngineSuper.Engine.DataTypes;

namespace GameEngineSuper
{

    class app : Super
    {
        // 16:9 Resolution Window.
        public app() : base(new Vector2(1366, 768), "New Game", Color.FromArgb(255, 255, 255)) { }
        //public Game() : base() { }  // 512x512 Base Resolution
    }
}
