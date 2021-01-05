using System;
using System.Windows.Forms;

namespace ClarkWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            currentOperator = EnumOperator.None;
            label1.Text = "";
            label2.Text = "";
            numSum = 0;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            Evaluate();
            label1.Text = numSum.ToString();

            //防止重复按 = 
            if (label1.Text.Length > 1 && label1.Text.Substring(label1.Text.Length - 1) != "=")
            {
                label1.Text += "=";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OperatorClick(EnumOperator.Add);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            OperatorClick(EnumOperator.Minus);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            OperatorClick(EnumOperator.Multiply);
        }

        private void BtnDiv_Click(object sender, EventArgs e)
        {
            OperatorClick(EnumOperator.Divide);
        }

        private void OperatorClick(EnumOperator op)
        {
            if (currentOperator != EnumOperator.None)
            {
                //计算
                Evaluate();
            }
            else
            {
                //numSum = double.Parse(lblResult.Text);
                double.TryParse(label1.Text, out numSum);
            }

            DisplayOperator(op);

            label1.Text = "";
            currentOperator = op;
        }

        private void Evaluate()
        {
            Oper oper;

            //根据不同的对象生成不同的类，多态!
            switch (currentOperator)
            {
                case EnumOperator.None:
                    break;
                case EnumOperator.Add:
                    oper = OperationFactory.createOpeate(EnumOperator.Add);
                    oper.NumberA = numSum;
                    oper.NumnberB = currentValue;
                    numSum = oper.GetResult();
                    break;
                case EnumOperator.Minus:
                    oper = OperationFactory.createOpeate(EnumOperator.Minus);
                    oper.NumberA = numSum;
                    oper.NumnberB = currentValue;
                    numSum = oper.GetResult();
                    break;
                case EnumOperator.Multiply:
                    oper = OperationFactory.createOpeate(EnumOperator.Multiply);
                    oper.NumberA = numSum;
                    oper.NumnberB = currentValue;
                    numSum = oper.GetResult();
                    break;
                case EnumOperator.Divide:
                    if (currentValue != 0)
                    {
                        oper = OperationFactory.createOpeate(EnumOperator.Divide);
                        oper.NumberA = numSum;
                        oper.NumnberB = currentValue;
                        numSum = oper.GetResult();
                    }
                    else
                    {
                        MessageBox.Show("除数不能为0哦，亲~", "出错了~");
                    }
                    break;
            }
            currentValue = 0;
            currentOperator = EnumOperator.None;
        }

        private void DisplayOperator(EnumOperator op)
        {
            switch (op)
            {
                case EnumOperator.None:
                    label2.Text = label1.Text;
                    label2.Text += "";
                    break;
                case EnumOperator.Add:
                    if (label1.Text != "")
                    {
                        label2.Text = label1.Text;
                    }
                    label2.Text += "+";
                    break;
                case EnumOperator.Minus:
                    if (label1.Text != "")
                    {
                        label2.Text = label1.Text;
                    }
                    label2.Text += "-";
                    break;
                case EnumOperator.Multiply:
                    label2.Text = label1.Text;
                    label2.Text += "x";
                    break;
                case EnumOperator.Divide:
                    label2.Text = label1.Text;
                    label2.Text += "➗";
                    break;
                default:
                    break;
            }
        }

        double currentValue = 0;   //第1个数 
        double numSum = 0;  //第2个数
        private EnumOperator currentOperator; //当前操作符  

        /// <summary>
        /// 按数字的时候
        /// </summary>
        /// <param name="strNumber"></param>
        private void NumberClick(string strNumber)
        {
            label1.Text = label1.Text + strNumber;
            currentValue = Convert.ToDouble(label1.Text);

            label2.Text += strNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            NumberClick(((Button)sender).Text);
        }
    }

    public enum EnumOperator
    {
        None,
        Add,
        Minus,
        Multiply,
        Divide
    }

    public class Oper
    {
        private double _numberA = 0;
        private double _numberB = 0;

        public double NumberA
        {
            get { return _numberA; }
            set { _numberA = value; }
        }

        public double NumnberB
        {
            get { return _numberB; }
            set { _numberB = value; }
        }

        public virtual double GetResult()
        {
            double result = 0d;
            return result;
        }
    }

    //加法类
    public class OperationAdd : Oper
    {
        /// <summary>
        /// 重写父方法:GetResult
        /// </summary>
        /// <returns></returns>
        public override double GetResult()
        {
            double result = 0;
            result = NumberA + NumnberB;
            return result;
        }
    }


    //减法类
    public class OperationSub : Oper
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA - NumnberB;
            return result;
        }
    }

    //乘法类
    public class OperationMul : Oper
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA * NumnberB;
            return result;
        }
    }

    //除法类
    public class OperationDiv : Oper
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumnberB == 0)
                throw new Exception("除数不能为0.");
            result = NumberA * 1.0 / NumnberB;
            return result;
        }
    }

    public class OperationFactory
    {
        /// <summary>
        /// 只需输入运算符，工厂就能实例化出合适的对象，通过多态，返回父类的方式实现了计算器的结果
        /// </summary>
        /// <param name="operate">运算符</param>
        /// <returns></returns>
        public static Oper createOpeate(EnumOperator op)
        {
            Oper oper = null;
            switch (op)
            {
                case EnumOperator.Add:
                    oper = new OperationAdd();
                    break;
                case EnumOperator.Minus:
                    oper = new OperationSub();
                    break;
                case EnumOperator.Multiply:
                    oper = new OperationMul();
                    break;
                case EnumOperator.Divide:
                    oper = new OperationDiv();
                    break;
                default:
                    break;
            }
            return oper;
        }
    }
}