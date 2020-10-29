using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Engine
{
    public class Text //Contains the information to create a text object
    {
        public Vector2 Position { get { return _Position; } set { _Position = value; Calc.Instance.Update(); } }
        private Vector2 _Position;
        public string text { get { return _text; } set { _text = value; Calc.Instance.Update(); } }
        private string _text;
        public float fontsize { get { return _fontsize; } set { _fontsize = value; Calc.Instance.Update(); } }
        private float _fontsize;

        public string Tag;

        public Text(Vector2 Position, float fontsize, string text, string Tag)
        {
            this.Position = Position;
            this.fontsize = fontsize;
            this.text = text;
            this.Tag = Tag;

            Calc.Instance.RegisterText(this);
            Calc.Instance.Update();
            Debug.LogCreate($"{Tag} has been Created!");
        }

        public void Destroy() { Calc.Instance.UnRegisterText(this); Debug.LogDestroy($"{Tag} has been Destroyed!"); }
    }
}
