using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineStoreDatabaseImplement.Logics;
using OnlineStoreDatabaseImplement.Models;

namespace OnlineStoreView.Plugin
{
    public partial class FormOrder : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private OrderLogic orderLogic = new OrderLogic();
        private DestinationCityLogic destinationCityLogic = new DestinationCityLogic();
        private bool flagChanges = false;
        public FormOrder()
        {
            InitializeComponent();
            timePickBox1.DateFrom = DateTime.Now;
            timePickBox1.DateTo = DateTime.Now.AddDays(4);
            var destCities = destinationCityLogic.Read(null);
            var citiesNames = new List<string>();
            for (int i = 0; i < destCities.Count; ++i)
            {
                citiesNames.Add(destCities[i].Name);
                //ilbekovComboBoxMeasures.AddItem(units[i].Name);
            }

            choiceComponent1.FillList(citiesNames);

            choiceComponent1.EventSelectedValueChanged += SmthChanged;
            timePickBox1.SelectedTimeChanged += SmthChanged;

            /*ilbekovComboBoxMeasures.SelectedIndexChanged += SmthChanged;
            lipatovTextBoxCountry.CheckedTextBoxChanged += SmthChanged;*/
        }

        private void SmthChanged(object sender, EventArgs e)
        {
            flagChanges = true;
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = orderLogic.Read(new OrderViewModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxClientName.Text = view.ClientName;
                        textBoxTrack1.Text = view.Track1;
                        textBoxTrack2.Text = view.Track2;
                        textBoxTrack3.Text = view.Track3;
                        textBoxTrack4.Text = view.Track4;
                        textBoxTrack5.Text = view.Track5;
                        textBoxTrack6.Text = view.Track6;
                        timePickBox1.TimePicked = view.DestinationDate;
                        choiceComponent1.ChoosenLine = view.DestinationCity;

                        //lipatovTextBoxCountry.InputText = view.Country;
                        //ilbekovComboBoxMeasures.ChoosenItem = view.UnitMeasurement;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            flagChanges = false;
        }

        private void FormOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flagChanges)
            {
                if (MessageBox.Show("Сохранить изменения перед закрытием?", "Закрыть", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }
            }
        }

        private void Save()
        {
            if (textBoxClientName.Text != "" && timePickBox1.TimePicked != null && choiceComponent1.ChoosenLine != "")
            {
                flagChanges = false;
                if (id != null)
                {
                    orderLogic.Update(new OrderViewModel()
                    {
                        Id = id,
                        ClientName = textBoxClientName.Text,
                        Track1 = textBoxTrack1.Text,
                        Track2 = textBoxTrack2.Text,
                        Track3 = textBoxTrack3.Text,
                        Track4 = textBoxTrack4.Text,
                        Track5 = textBoxTrack5.Text,
                        Track6 = textBoxTrack6.Text,
                        DestinationDate = timePickBox1.TimePicked,
                        DestinationCity = choiceComponent1.ChoosenLine
                    });
                }
                else
                {
                    orderLogic.Create(new OrderViewModel()
                    {
                        ClientName = textBoxClientName.Text,
                        Track1 = textBoxTrack1.Text,
                        Track2 = textBoxTrack2.Text,
                        Track3 = textBoxTrack3.Text,
                        Track4 = textBoxTrack4.Text,
                        Track5 = textBoxTrack5.Text,
                        Track6 = textBoxTrack6.Text,
                        DestinationDate = timePickBox1.TimePicked,
                        DestinationCity = choiceComponent1.ChoosenLine
                    });
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Все поля обязательны к заполнению, за исключением меток передвижения");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
