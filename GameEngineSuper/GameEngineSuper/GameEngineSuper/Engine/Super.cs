using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngineSuper.Engine.DataTypes;
using System.Drawing;

namespace GameEngineSuper.Engine
{
    public class Window : Form { public Window() { DoubleBuffered = true; } }
    public abstract class Super
    {
        public Window WINDOW;

        public Vector2 WINDOW_SIZE;
        public string WINDOW_TITLE;
        public Color WINDOW_COLOR;

        public Super(Vector2 size, string title, Color color)
        {
            WINDOW_SIZE = size;
            WINDOW_TITLE = title;
            WINDOW_COLOR = color;

            WINDOW = new Window
            {
                Size = WINDOW_SIZE.ToSize(),
                Text = WINDOW_TITLE,
                BackColor = WINDOW_COLOR,
            };

            Application.Run(WINDOW);
        }

    }
}
