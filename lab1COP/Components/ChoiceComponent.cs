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
    public partial class ChoiceComponent : UserControl
    {
        public ChoiceComponent()
        {
            InitializeComponent();
            LoadData();
        }

        private event EventHandler _event;
        public event EventHandler EventSelectedValueChanged
        {
            add { _event += value; }
            remove { _event -= value; }
        }

        public void FillList(List<String> strs)
        {
            foreach (var str in strs)
            {
                listBox1.Items.Add(str);
            }
        }

        private void LoadData()
        {
            listBox1.SelectedValueChanged += _event;
        }

        public string ChoosenLine
        {
            set
            {
                int index = listBox1.Items.IndexOf(value);
                if (index != -1)
                {
                    listBox1.SetSelected(index, true);
                }
                else
                {
                    listBox1.ClearSelected();
                }
            }
            get
            {
                if (listBox1.SelectedIndex != -1)
                {
                    return (String)listBox1.SelectedItem;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        public void ClearList()
        {
            listBox1.Items.Clear();
        }

    }
}
