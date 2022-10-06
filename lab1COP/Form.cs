using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab1COP.Model;
using lab1COP.NonVisualComponents;
using lab1COP.NonVisualComponents.HelperModels;

namespace lab1COP
{
    public partial class Form : System.Windows.Forms.Form
    {
        List<String> list = new List<string> {
            "Katya","Andrey","Evgeniy"
        };

        List<Order> orderList = new List<Order> {
            new Order{ BuyerName = "Kate Taurielke",
            ProductName = "Table",
            Price = 100
            },
            new Order{ BuyerName = "Andrey Kutygin",
            ProductName = "Chair",
            Price = 50
            },
            new Order{ BuyerName = "Evgeniy Sergeev",
            ProductName = "Laptop",
            Price = 1000
            }
        };

        public Form()
        {
            InitializeComponent();
        }

        private void buttonAddElemsListBox_Click(object sender, EventArgs e)
        {
            choiceComponent1.FillList(list);
        }

        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            choiceComponent1.ClearList();
        }

        private void buttonSetNumber_Click(object sender, EventArgs e)
        {
            inputComponent1.Number = 5;
        }

        private void buttonSetNull_Click(object sender, EventArgs e)
        {
            inputComponent1.Number = null;
        }

        private void buttonGetNumbFromTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (inputComponent1.Number != null)
                {
                    MessageBox.Show("Your number is " + inputComponent1.Number.ToString());
                }
                if (inputComponent1.Number == null) 
                {
                    MessageBox.Show("Your number is null");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonFillGrid_Click(object sender, EventArgs e)
        {
            outputComponent1.FillDataGrid<Order>(orderList);
        }

        private void buttonConfigGrid_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
            columns.Add(new DataGridViewColumn()
            {
                HeaderText = "BuyerName",
                Width = 200,
                Visible = true,
                DataPropertyName = "BuyerName"
            });
            columns.Add(new DataGridViewColumn()
            {
                HeaderText = "ProductName",
                Width = 200,
                Visible = true,
                DataPropertyName = "ProductName"
            });
            columns.Add(new DataGridViewColumn()
            {
                HeaderText = "Price",
                Width = 50,
                Visible = true,
                DataPropertyName = "Price"
            });
            outputComponent1.ConfigureDataGridView(columns);
        }

        private void buttonGetSelectedObj_Click(object sender, EventArgs e)
        {
            Order order = outputComponent1.GetSelectedObject<Order>();
            MessageBox.Show(order.ToString());
        }

        private void buttonGetIndex_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(outputComponent1.SelectedIndex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSetIndex_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(textBox1.Text);
                outputComponent1.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClearGrid_Click(object sender, EventArgs e)
        {
            outputComponent1.ClearStrings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string[,]> list = new List<string[,]>() {
                new string[,]{ { "let's","check","if"},{ "it","works",","},{"I","hope","it" }, {"does","?","?" } },
                new string[,]{ { "let's","check","if"},{ "it","works",","},{"I","hope","it" }, {"does","!","!" } }
            };
            TableComponent tc = new TableComponent();
            tc.SaveTable("D:\\testPDF\\firstComponent.pdf", "Question and answer", list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomTableComponent ctc = new CustomTableComponent();
            string folder = "D:\\testPDF\\secondComponent.pdf";
            string title = "Test";

            List<PdfColumnInfo> columns = new List<PdfColumnInfo>();
            PdfRowInfo[] rows = new PdfRowInfo[2];

            columns.Add(new PdfColumnInfo { Name = "BuyerName", PropertyName = "BuyerName" });
            columns.Add(new PdfColumnInfo { Name = "ProductName", PropertyName = "ProductName" });
            columns.Add(new PdfColumnInfo { Name = "Price", PropertyName = "Price" });

            rows[0] = new PdfRowInfo() { Height = 50 };
            rows[1] = new PdfRowInfo() { Height = 50 };

            ctc.SaveTable(folder, title, columns, rows, orderList);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string folder = "D:\\testPDF\\thirdComponent.pdf";
            string title = "Very nice histogram";
            string histTitle = "Random Data";

            HistogramComponent hc = new HistogramComponent();
            LegendfInfo legend = LegendfInfo.BottomCenter;

            HistogramInfo hi = new HistogramInfo();
            Dictionary<string, float[]> data = new Dictionary<string, float[]>();
            data.Add("does", new float[] { 10 });
            data.Add("it", new float[] { 25, 40 });
            data.Add("work", new float[] { 19 });
            data.Add("she", new float[] { 27 });
            data.Add("wonders", new float[] { 45 });
            hi.Data = data;

            hc.SaveHistogram(folder, title, histTitle, legend, hi);
        }
    }
}
