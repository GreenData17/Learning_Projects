using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Engine;

namespace Calculator
{
    public class APP : Calc
    {
        public APP() : base(new Vector2(240, 320), "Calculator") { }

        public ManageButton MB;

        Shape2d InputField, btn_plus, btn_minus, btn_div, btn_mul, btn_7, btn_8,
            btn_9, btn_4, btn_5, btn_6, btn_1, btn_2, btn_3, btn_0, btn_dot, btn_equal;

        Text txt_InputField, txt_plus, txt_minus, txt_div, txt_mul, txt_7, txt_8,
            txt_9, txt_4, txt_5, txt_6, txt_1, txt_2, txt_3, txt_0, txt_dot, txt_equal;

        public override void OnLoad()
        {
            MB = new ManageButton();

            #region Create Buttons
            InputField = new Shape2d(new Vector2(5, 5), new Vector2(215, 50), Color.White, "InputF");

            btn_plus = new Shape2d(new Vector2(170, 60), new Vector2(50, 50), Color.Gray, "btn_plus");
            btn_minus = new Shape2d(new Vector2(170, 115), new Vector2(50, 50), Color.Gray, "btn_minus");
            btn_div = new Shape2d(new Vector2(170, 170), new Vector2(50, 50), Color.Gray, "btn_div");
            btn_mul = new Shape2d(new Vector2(170, 225), new Vector2(50, 50), Color.Gray, "btn_mul");

            btn_7 = new Shape2d(new Vector2(5, 60), new Vector2(50, 50), Color.Gray, "btn_7");
            btn_8 = new Shape2d(new Vector2(60, 60), new Vector2(50, 50), Color.Gray, "btn_8");
            btn_9 = new Shape2d(new Vector2(115, 60), new Vector2(50, 50), Color.Gray, "btn_9");
            btn_4 = new Shape2d(new Vector2(5, 115), new Vector2(50, 50), Color.Gray, "btn_4");
            btn_5 = new Shape2d(new Vector2(60, 115), new Vector2(50, 50), Color.Gray, "btn_5");
            btn_6 = new Shape2d(new Vector2(115, 115), new Vector2(50, 50), Color.Gray, "btn_6");
            btn_1 = new Shape2d(new Vector2(5, 170), new Vector2(50, 50), Color.Gray, "btn_1");
            btn_2 = new Shape2d(new Vector2(60, 170), new Vector2(50, 50), Color.Gray, "btn_2");
            btn_3 = new Shape2d(new Vector2(115, 170), new Vector2(50, 50), Color.Gray, "btn_3");

            btn_0 = new Shape2d(new Vector2(5, 225), new Vector2(50, 50), Color.Gray, "btn_0");
            btn_dot = new Shape2d(new Vector2(60, 225), new Vector2(50, 50), Color.Gray, "btn_dot");
            btn_equal = new Shape2d(new Vector2(115, 225), new Vector2(50, 50), Color.Gray, "btn_equal");
            #endregion

            Debug.LogInfo("######################################");

            #region Create Text
            txt_InputField = new Text(new Vector2(10, 15), 20, "0", "txt_InputField");

            txt_plus = new Text(new Vector2(180, 70), 20, "+", "txt_plus");
            txt_minus = new Text(new Vector2(180, 125), 20, "-", "txt_minus");
            txt_div = new Text(new Vector2(180, 180), 20, "/", "txt_div");
            txt_mul = new Text(new Vector2(180, 235), 20, "*", "txt_mul");

            txt_7 = new Text(new Vector2(15, 70), 20, "7", "txt_7");
            txt_8 = new Text(new Vector2(70, 70), 20, "8", "txt_8");
            txt_9 = new Text(new Vector2(125, 70), 20, "9", "txt_9");
            txt_4 = new Text(new Vector2(15, 125), 20, "4", "txt_4");
            txt_5 = new Text(new Vector2(70, 125), 20, "5", "txt_5");
            txt_6 = new Text(new Vector2(125, 125), 20, "6", "txt_6");
            txt_1 = new Text(new Vector2(15, 180), 20, "1", "txt_1");
            txt_2 = new Text(new Vector2(70, 180), 20, "2", "txt_2");
            txt_3 = new Text(new Vector2(125, 180), 20, "3", "txt_3");

            txt_0 = new Text(new Vector2(15, 235), 20, "0", "txt_0");
            txt_dot = new Text(new Vector2(70, 235), 20, ".", "txt_dot");
            txt_equal = new Text(new Vector2(125, 235), 20, "=", "txt_equal");
            #endregion
        }

        public override void OnUpdate()
        {
            if (txt_InputField != null && MB.CalcUpdated)
            {
                if (MB.result == "0")
                {
                    if (MB.number2 == "0")
                    {
                        if (MB.newMath == ManageButton.math.none)
                        {
                            txt_InputField.text = MB.GetNumber1();
                        }
                        else
                        {
                            if (MB.newMath == ManageButton.math.add) { txt_InputField.text = MB.GetNumber1() + " + "; }
                            if (MB.newMath == ManageButton.math.sub) { txt_InputField.text = MB.GetNumber1() + " - "; }
                            if (MB.newMath == ManageButton.math.div) { txt_InputField.text = MB.GetNumber1() + " / "; }
                            if (MB.newMath == ManageButton.math.mul) { txt_InputField.text = MB.GetNumber1() + " * "; }
                        }
                    }
                    else
                    {
                        if (MB.newMath == ManageButton.math.add) { txt_InputField.text = MB.GetNumber1() + " + " + MB.GetNumber2(); }
                        if (MB.newMath == ManageButton.math.sub) { txt_InputField.text = MB.GetNumber1() + " - " + MB.GetNumber2(); ; }
                        if (MB.newMath == ManageButton.math.div) { txt_InputField.text = MB.GetNumber1() + " / " + MB.GetNumber2(); ; }
                        if (MB.newMath == ManageButton.math.mul) { txt_InputField.text = MB.GetNumber1() + " * " + MB.GetNumber2(); ; }
                    }
                }
                else
                {
                    txt_InputField.text = MB.GetResult();
                }
            }
        }

        public override void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (MouseHoverCheck(e, InputField.Position, InputField.Size)) { InputField.color = Color.LightGray; InputField.Hovering = true; }
            else { InputField.color = Color.White; InputField.Hovering = false; }

            #region operator btn hover

            if (MouseHoverCheck(e, btn_plus.Position, btn_plus.Size)) { btn_plus.color = Color.LightCoral; btn_plus.Hovering = true; }
            else { btn_plus.color = Color.Gray; btn_plus.Hovering = false; }
            
            if(MouseHoverCheck(e, btn_minus.Position, btn_minus.Size)) { btn_minus.color = Color.LightCoral; btn_minus.Hovering = true; }
            else { btn_minus.color = Color.Gray; btn_minus.Hovering = false; }

            if (MouseHoverCheck(e, btn_div.Position, btn_div.Size)) { btn_div.color = Color.LightCoral; btn_div.Hovering = true; }
            else { btn_div.color = Color.Gray; btn_div.Hovering = false; }

            if (MouseHoverCheck(e, btn_mul.Position, btn_mul.Size)) { btn_mul.color = Color.LightCoral; btn_mul.Hovering = true; }
            else { btn_mul.color = Color.Gray; btn_mul.Hovering = false; }

            #endregion

            #region nummber btn hover

            if (MouseHoverCheck(e, btn_7.Position, btn_7.Size)) { btn_7.color = Color.LightBlue; btn_7.Hovering = true; }
            else { btn_7.color = Color.Gray; btn_7.Hovering = false; }

            if (MouseHoverCheck(e, btn_8.Position, btn_8.Size)) { btn_8.color = Color.LightBlue; btn_8.Hovering = true; }
            else { btn_8.color = Color.Gray; btn_8.Hovering = false; }

            if (MouseHoverCheck(e, btn_9.Position, btn_9.Size)) { btn_9.color = Color.LightBlue; btn_9.Hovering = true; }
            else { btn_9.color = Color.Gray; btn_9.Hovering = false; }


            if (MouseHoverCheck(e, btn_4.Position, btn_4.Size)) { btn_4.color = Color.LightBlue; btn_4.Hovering = true; }
            else { btn_4.color = Color.Gray; btn_4.Hovering = false; }

            if (MouseHoverCheck(e, btn_5.Position, btn_5.Size)) { btn_5.color = Color.LightBlue; btn_5.Hovering = true; }
            else { btn_5.color = Color.Gray; btn_5.Hovering = false; }

            if (MouseHoverCheck(e, btn_6.Position, btn_6.Size)) { btn_6.color = Color.LightBlue; btn_6.Hovering = true; }
            else { btn_6.color = Color.Gray; btn_6.Hovering = false; }


            if (MouseHoverCheck(e, btn_1.Position, btn_1.Size)) { btn_1.color = Color.LightBlue; btn_1.Hovering = true; }
            else { btn_1.color = Color.Gray; btn_1.Hovering = false; }

            if (MouseHoverCheck(e, btn_2.Position, btn_2.Size)) { btn_2.color = Color.LightBlue; btn_2.Hovering = true; }
            else { btn_2.color = Color.Gray; btn_2.Hovering = false; }

            if (MouseHoverCheck(e, btn_3.Position, btn_3.Size)) { btn_3.color = Color.LightBlue; btn_3.Hovering = true; }
            else { btn_3.color = Color.Gray; btn_3.Hovering = false; }

            #endregion

            #region 0 dot equal btn hover

            if (MouseHoverCheck(e, btn_0.Position, btn_0.Size)) { btn_0.color = Color.LightPink; btn_0.Hovering = true; }
            else { btn_0.color = Color.Gray; btn_0.Hovering = false; }

            if (MouseHoverCheck(e, btn_dot.Position, btn_dot.Size)) { btn_dot.color = Color.LightYellow; btn_dot.Hovering = true; }
            else { btn_dot.color = Color.Gray; btn_dot.Hovering = false; }

            if (MouseHoverCheck(e, btn_equal.Position, btn_equal.Size)) { btn_equal.color = Color.LightGreen; btn_equal.Hovering = true; }
            else { btn_equal.color = Color.Gray; btn_equal.Hovering = false; }

            #endregion
            

        }

        public override void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (btn_plus.Hovering) { MB.SetMath('+'); }
            if (btn_minus.Hovering) { MB.SetMath('-'); }
            if (btn_div.Hovering) { MB.SetMath('/'); }
            if (btn_mul.Hovering) { MB.SetMath('*'); }
            if (btn_7.Hovering) { MB.SetCalc('7'); }
            if (btn_8.Hovering) { MB.SetCalc('8'); }
            if (btn_9.Hovering) { MB.SetCalc('9'); }
            if (btn_4.Hovering) { MB.SetCalc('4'); }
            if (btn_5.Hovering) { MB.SetCalc('5'); }
            if (btn_6.Hovering) { MB.SetCalc('6'); }
            if (btn_1.Hovering) { MB.SetCalc('1'); }
            if (btn_2.Hovering) { MB.SetCalc('2'); }
            if (btn_3.Hovering) { MB.SetCalc('3'); }
            if (btn_0.Hovering) { MB.SetCalc('0'); }
            if (btn_dot.Hovering) { MB.SetCalc('.'); }
            if (btn_equal.Hovering) { MB.Calculate(); }
        }

        private bool MouseHoverCheck(MouseEventArgs e, Vector2 Position, Vector2 Size)
        {
            if (e.X < Position.X + Size.X && e.X > Position.X)
            {
                if (e.Y < Position.Y + Size.Y && e.Y > Position.Y)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}
