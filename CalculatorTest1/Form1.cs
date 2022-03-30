using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorTest1
{
    public partial class CalculatorForm1 : Form
    {
        #region variables 
        
        string[] _operatorList = new string[] { "+", "-", "/", "*" };

        
        double? _reservedNumber1 = null, _reservedNumber2 = null;


        string _operator = null;

        bool _clearText = false;
        #endregion  
        public CalculatorForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var text = ((Button)sender).Text;


            var isOpeartor = _operatorList.Any(p => p == text);
            if (isOpeartor)
            {
                if (double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber1 = temp;
                    txtInput.Clear();
                    lblResult.Text = $"{_reservedNumber1} {text}";
                    _operator = text;
                }
            }
            else
            if (text == "=")
            {
                if (double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber2 = temp;
                }
                Calculate();
                _clearText = true;
            }
            else
            {
                if (_clearText)
                {
                    txtInput.Text = text;

                    _clearText = false;
                }
                else
                {
                    txtInput.Text += text;
                }
            }
        }

        private void Calculate()
        {
            double? result = 0;
            switch (_operator)
            {
                case "+":
                    result = _reservedNumber2 + _reservedNumber1;
                    break;
                case "/":
                    result = _reservedNumber1 / _reservedNumber2;
                    break;
                case "-":
                    result = _reservedNumber1 - _reservedNumber2;
                    break;
                case "*":
                    result = _reservedNumber2 * _reservedNumber1;
                    break;
                default:
                    break;
            }
            lblResult.Text = result.ToString();
        }

        private void CalculatorForm1_Load(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            lblResult.Text = String.Empty;
        }
    }
}
