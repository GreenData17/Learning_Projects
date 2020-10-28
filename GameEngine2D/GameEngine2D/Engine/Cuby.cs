using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngine.Engine
{
    public abstract class Cuby
    {
        //Base Window Information.
        public static Cuby Instance;
        public string WIN_TITLE = "New Game";
        public Vector2 WIN_SIZE = new Vector2(512, 512);
        public Window WINDOW = null;

        public Color WIN_BACKCOLOR = Color.Black;

        //Register Lists
        public List<Shape2d> AllShape2Ds = new List<Shape2d>();
        
        //Two version to create a window.
        public Cuby()
        {
            Setup();
        }
        public Cuby(Vector2 Size, string Title)
        {
            this.WIN_TITLE = Title;
            this.WIN_SIZE = Size;
            Setup();
        }


        //Setting up the Window and set the event funktions.
        private void Setup()
        {
            Debug.Log("# CubyEngine v.1.0 #");
            Debug.Log(" Thanks for using CubyEngine!");
            Debug.LogSpace();
            Debug.LogInfo("# Cuby Debug's #");
            Debug.LogSystem("Setup Started!");
            Instance = this;
            WINDOW = new Window()
            {
                Text = WIN_TITLE,
                Size = WIN_SIZE.ToSize(),
                FormBorderStyle = FormBorderStyle.FixedSingle,
            };

            WINDOW.Paint += Renderer;
            WINDOW.KeyDown += OnKeyDown;
            WINDOW.KeyUp += OnKeyUp;

            Debug.LogSystem("OnLoad!");
            OnLoad();

            Debug.LogSystem("Window Started!");
            Application.Run(WINDOW);
        }

        //Use this to Update The Window.
        public void Update()
        {
            WINDOW.Refresh();
            OnUpdate();
        }

        //This renders everyting. From Square to Text.
        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(WIN_BACKCOLOR);

            foreach(Shape2d s in AllShape2Ds)
            {
                g.FillRectangle(new SolidBrush(s.Color), s.Position.X, s.Position.Y, s.Size.X, s.Size.Y);
            }
        }

        //Abstract Funktions (don't really know what Abstract Functions are...)
        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnKeyDown(object sender, KeyEventArgs e);
        public abstract void OnKeyUp(object sender, KeyEventArgs e);
    }
}
