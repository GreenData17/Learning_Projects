using GameEngine.Engine;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngine
{
    public class Game : Cuby
    {
        public Game() : base(new Vector2(1366, 768), "New Game") { }  // 16:9 Resolution Window.
        //public Game() : base() { }  // 512x512 Base Resolution

        //Objects
        private bool Up, Down, Left, Right;
        private Shape2d Player;

        //Used for loading/preparing objects
        public override void OnLoad()
        {
            Debug.LogSpace();
            Debug.Log("Use this to give Information in the Console.");
            Debug.LogCreate("This will be used for the objects.");
            Debug.LogDestroy("This will be used for the objects.");
            Debug.LogError("This is used to show errors.");
            Debug.LogInfo("Use this to give Information in the Console.");
            Debug.LogSystem("This is only used inside of \"Cuby.cs\".");
            Debug.LogSpace();

            Debug.LogInfo("# OnLoad Debug's #");
            Player = new Shape2d(new Vector2(50, 50), new Vector2(683, 384), Color.DarkGray, "Player");
        }

        public override void OnUpdate()
        {
            int speed = 2;

            if(Up) { Player.Position.Y -= speed; }
            if(Down) { Player.Position.Y += speed; }
            if(Left) { Player.Position.X -= speed; }
            if(Right) { Player.Position.X += speed; }
        }

        public override void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W) { Up = true; }
            if(e.KeyCode == Keys.S) { Down = true; }
            if(e.KeyCode == Keys.A) { Left = true; }
            if(e.KeyCode == Keys.D) { Right = true; }


            Update();
        }

        public override void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { Up = false; }
            if (e.KeyCode == Keys.S) { Down = false; }
            if (e.KeyCode == Keys.A) { Left = false; }
            if (e.KeyCode == Keys.D) { Right = false; }


            Update();
        }
    }
}
