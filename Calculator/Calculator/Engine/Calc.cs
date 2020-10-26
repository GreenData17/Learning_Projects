﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.Engine
{
    public class Windows : Form
    {
        public Windows()
        {
            DoubleBuffered = true;
        }
    }

    public abstract class Calc
    {
        public static Calc Instance = null;
        public Vector2 WIN_SIZE = new Vector2(200, 600);
        public string WIN_TITLE = "New Window";

        public Windows CALCULATOR = null;

        public List<Shape2d> AllShape2ds = new List<Shape2d>();
        public List<Text> AllTexts = new List<Text>();

        public Calc(Vector2 WIN_SIZE, string WIN_TITLE)
        {
            if(Instance == null) { Instance = this; }

            this.WIN_SIZE = WIN_SIZE;
            this.WIN_TITLE = WIN_TITLE;

            CALCULATOR = new Windows
            {
                Size = WIN_SIZE.ToSize(),
                Text = WIN_TITLE,
            };

            CALCULATOR.Paint += Renderer;
            
            CALCULATOR.KeyDown += OnKeyDown;
            CALCULATOR.KeyUp += OnKeyUp;

            CALCULATOR.MouseMove += OnMouseMove;
            CALCULATOR.MouseDown += OnMouseDown;
            CALCULATOR.MouseUp += OnMouseUp;

            Debug.LogInfo("Programm Opened!");

            OnLoad();

            Debug.LogInfo("Programm Loaded!");
            Application.Run(CALCULATOR);
        }

        public void Update()
        {
            OnUpdate();
            CALCULATOR.Refresh();
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.DarkGray);

            foreach(Shape2d s in AllShape2ds)
            {
                g.FillRectangle(new SolidBrush(s.color), s.Position.X, s.Position.Y, s.Size.X, s.Size.Y);
            }
            foreach(Text t in AllTexts)
            {
                g.DrawString(t.text, new Font(FontFamily.GenericMonospace, t.fontsize), new SolidBrush(Color.Black), t.Position.X - 2, t.Position.Y - 2);
                g.DrawString(t.text, new Font(FontFamily.GenericMonospace, t.fontsize), new SolidBrush(Color.Black), t.Position.X + 2, t.Position.Y + 2);
                g.DrawString(t.text, new Font(FontFamily.GenericMonospace, t.fontsize), new SolidBrush(Color.Black), t.Position.X + 2, t.Position.Y - 2);
                g.DrawString(t.text, new Font(FontFamily.GenericMonospace, t.fontsize), new SolidBrush(Color.Black), t.Position.X - 2, t.Position.Y + 2);
                g.DrawString(t.text, new Font(FontFamily.GenericMonospace, t.fontsize), new SolidBrush(Color.White), t.Position.X, t.Position.Y);
            }
        }

        //#### Extern Code ####

        public abstract void OnLoad();
        public abstract void OnUpdate();

        public abstract void OnKeyDown(object sender, KeyEventArgs e);
        public abstract void OnKeyUp(object sender, KeyEventArgs e);

        public abstract void OnMouseMove(object sender, MouseEventArgs e);
        public abstract void OnMouseDown(object sender, MouseEventArgs e);
        public abstract void OnMouseUp(object sender, MouseEventArgs e);

        //#### Extern Code ####


        //#### Register Funktion ####

        public void RegisterShape2d(Shape2d s) { AllShape2ds.Add(s); }
        public void UnRegisterShape2d(Shape2d s) { AllShape2ds.Remove(s); }

        public void RegisterText(Text t) { AllTexts.Add(t); }
        public void UnRegisterText(Text t) { AllTexts.Remove(t); }

        //#### Register Funktion ####

    }
}