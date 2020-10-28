using System.Drawing;

namespace GameEngine.Engine
{
    public class Shape2d
    {
        public Vector2 Size { get { return _Size; } set { _Size = value; Cuby.Instance.Update(); } }
        private Vector2 _Size = Vector2.One();
        public Vector2 Position { get { return _Position; } set { _Position = value; Cuby.Instance.Update(); } }
        private Vector2 _Position = Vector2.Zero();

        public Color Color { get { return _Color; } set { _Color = value; Cuby.Instance.Update(); } }
        private Color _Color = Color.Red;

        public string Tag;

        public Shape2d(Vector2 Size, Vector2 Position, Color Color, string Tag)
        {
            this.Size = Size;
            this.Position = Position;
            this.Color = Color;
            this.Tag = Tag;

            Cuby.Instance.AllShape2Ds.Add(this);
            Cuby.Instance.Update();
            Debug.LogCreate($"\"{Tag}\" has been Created!");
        }

        public void Destroy()
        {
            Cuby.Instance.AllShape2Ds.Remove(this);
            Cuby.Instance.Update();
            Debug.LogDestroy($"\"{Tag}\" has been Created!");
        }
    }
}
