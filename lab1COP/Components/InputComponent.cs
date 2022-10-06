using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1COP.Components
{
    public partial class InputComponent : UserControl
    {
        public InputComponent()
        {
            InitializeComponent();
        }

        public int? Number
        {
            set
            {
                checkBox1.Checked = !value.HasValue;
                textBox1.Text = value.ToString();
            }
            get
            {
                if (checkBox1.Checked)
                {
                    return null;
                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    throw new Exception("Fill in a value or check a checkbox");
                }
                else
                {
                    int? number = null;
                    try
                    {
                        number = Convert.ToInt32(textBox1.Text);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    return number;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !checkBox1.Checked;
        }
    }
}
