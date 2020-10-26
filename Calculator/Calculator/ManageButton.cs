using System;

namespace Calculator
{
    public class ManageButton
    {
        public Double nummber1 = 0;
        public Double nummber2 = 0;
        public Double result = 0;

        public enum math{
            none,
            add,
            sub,
            mul,
            div
        };

        public math newMath = new math();

        public ManageButton()
        {
            nummber1 = 0;
            nummber2 = 0;
            result = 0;
            newMath = math.none;
        }

        public void SetMath(char mathchar)
        {
            switch (mathchar)
            {
                case '+':
                    newMath = math.add;
                    break;
                case '-':
                    newMath = math.sub;
                    break;
                case '*':
                    newMath = math.mul;
                    break;
                case '/':
                    newMath = math.div;
                    break;
            }
        }

        public void SetCalc(char numchar)
        {
            result = 0;
            if (numchar == '.')
            {
                if(newMath == math.none)
                {
                    if (!nummber1.ToString().Contains("."))
                    {
                        nummber1 = float.Parse(nummber1.ToString() + numchar);
                    }
                }
                else
                {
                    if (!nummber2.ToString().Contains("."))
                    {
                        nummber2 = float.Parse(nummber2.ToString() + numchar);
                    }
                }
            }
            else
            {
                if (newMath == math.none)
                {
                    nummber1 = float.Parse(nummber1.ToString() + numchar);
                }
                else
                {
                    if (!nummber2.ToString().Contains("."))
                    {
                        nummber2 = float.Parse(nummber2.ToString() + numchar);
                    }
                }
            }
        }

        public void Calculate()
        {
            switch (newMath)
            {
                case math.add:

                    result = nummber1 + nummber2;

                    break;
                case math.sub:

                    result = nummber1 - nummber2;

                    break;
                case math.mul:

                    result = nummber1 * nummber2;

                    break;
                case math.div:

                    result = nummber1 / nummber2;

                    break;
            }

            newMath = math.none;
        }
    }
}
