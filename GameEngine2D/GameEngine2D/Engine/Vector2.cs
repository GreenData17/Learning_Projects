using System.Drawing;

namespace GameEngine.Engine
{

    //Is used to set and locate a position easier/faster
    public class Vector2
    {
        public int X, Y;

        public Vector2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Vector2 Zero() { return new Vector2(0, 0); }
        public static Vector2 One() { return new Vector2(1, 1); }


        public Size ToSize() { return new Size(X, Y); }
        public Point ToPoint() { return new Point(X, Y); }
    }
}
