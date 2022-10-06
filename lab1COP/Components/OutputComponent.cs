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
    public partial class OutputComponent : UserControl
    {
        public OutputComponent()
        {
            InitializeComponent();
        }

        public void ConfigureDataGridView(List<DataGridViewColumn> options)
        {
            foreach (DataGridViewColumn column in options)
            {
                DataGridViewColumn tmp = new DataGridViewTextBoxColumn();
                tmp.HeaderText = column.HeaderText;
                tmp.Width = column.Width;
                tmp.Visible = column.Visible;
                tmp.DataPropertyName = column.DataPropertyName;
                dataGridView1.Columns.Add(tmp);
            }
        }

        public void ClearStrings()
        {
            dataGridView1.DataSource = null;
        }

        public int SelectedIndex
        {
            set
            {
                if (dataGridView1.Rows.Count <= value)
                {
                    throw new Exception("Not enough rows");
                }
                else if (value < 0)
                {
                    throw new Exception("Index must be above 0");
                }
                else
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[value].Selected = true;
                }
            }
            get
            {
                return dataGridView1.SelectedRows[0].Index;
            }
        }

        public T GetSelectedObject<T>()
        {
            T tmp = (T)Activator.CreateInstance(typeof(T));
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                int columnIndex = 0;
                Boolean propIsFound = false;
                for (columnIndex = 0; columnIndex < dataGridView1.Columns.Count; columnIndex++)
                {
                    if (dataGridView1.Columns[columnIndex].DataPropertyName.ToString() == property.Name)
                    {
                        propIsFound = true;
                        break;
                    }
                }
                if (!propIsFound) 
                { 
                    throw new Exception("Cannot find the property"); 
                };
                object value = dataGridView1.SelectedRows[0].Cells[columnIndex].Value;
                property.SetValue(tmp, value);
            }
            return tmp;
        }

        public void FillDataGrid<T>(List<T> list)
        {
            foreach (var listObj in list) 
            {
                int count = dataGridView1.Columns.Count;
                string[] objValues = new string[count];
                var type = typeof(T);
                for (int j = 0; j < count; ++j)
                {
                    var propInfo = type.GetProperty(dataGridView1.Columns[j].DataPropertyName);
                    objValues[j] = propInfo.GetValue(listObj).ToString();
                }
                dataGridView1.Rows.Add(objValues);
            }


        }
    }
}
