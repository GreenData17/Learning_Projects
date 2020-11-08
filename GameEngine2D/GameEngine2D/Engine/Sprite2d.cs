using System;
using System.Collections.Generic;
using drw = System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Sprite2d
    {
        public Vector2 Size { get { return _Size; } set { _Size = value; Cuby.Instance.Update(); } }
        private Vector2 _Size = Vector2.One();
        public Vector2 Position { get { return _Position; } set { _Position = value; Cuby.Instance.Update(); } }
        private Vector2 _Position = Vector2.Zero();
        public drw.Bitmap Image { get { return _Image; } set { _Image = value; Cuby.Instance.Update(); } }
        private drw.Bitmap _Image = null;
        public string Tag;

        public Sprite2d(Vector2 Position, Vector2 Size, string Path, string Tag)
        {
            this.Position = Position;
            this.Size = Size;
            drw.Image tmp = drw.Image.FromFile($"assets/sprites/{Path}.png");
            Image = new drw.Bitmap(tmp, this.Size.X, this.Size.Y);
            
        }
    }
}
