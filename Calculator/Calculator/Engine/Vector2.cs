using System.Drawing;

namespace Calculator.Engine
{
    public class Vector2  //for easier use of x and y like position(Point(int X, int Y)) or size
    {
        public int X;
        public int Y;

        public Vector2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        //Creating

        public static Vector2 Zero() { return new Vector2(0, 0); }
        public static Vector2 One() { return new Vector2(1, 1); }

        //Converting

        public Size ToSize() { return new Size(X, Y); }
    }
}
