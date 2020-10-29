using System;
using System.Drawing;

namespace Calculator.Engine
{
    public class Shape2d  //contains the informations to create a shape
    {
        public Vector2 Position { get { return _Position; } set { _Position = value; Calc.Instance.Update(); } }
        private Vector2 _Position;
        public Vector2 Size { get { return _Size; } set { _Size = value; Calc.Instance.Update(); } }
        private Vector2 _Size;
        public Color color { get { return _color; } set { _color = value; Calc.Instance.Update(); } }
        private Color _color;

        public bool Hovering;

        public readonly string Tag;

        public Shape2d(Vector2 Position, Vector2 Size, Color color, string Tag)
        {
            this.Position = Position;
            this.Size = Size;
            this.color = color;
            this.Tag = Tag;

            Calc.Instance.RegisterShape2d(this);
            Calc.Instance.Update();
            Debug.LogCreate($"{Tag} has been Created!");
        }

        public void Destroy() { Calc.Instance.UnRegisterShape2d(this); Debug.LogDestroy($"{Tag} has been Destroyed!"); }
    }
}
