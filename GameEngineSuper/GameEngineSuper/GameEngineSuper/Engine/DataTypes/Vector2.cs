using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameEngineSuper.Engine.DataTypes
{
    public class Vector2
    {
        float X, Y;

        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Vector2 Zero() { return new Vector2(0, 0); }
        public static Vector2 One() { return new Vector2(1, 1); }

        public Point ToPoint() { return new Point((int)Math.Round(X), (int)Math.Round(Y)); }
        public Size ToSize() { return new Size((int)Math.Round(X), (int)Math.Round(Y)); }
    }
}
