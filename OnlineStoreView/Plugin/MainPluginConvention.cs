using lab1COP.Components;
using lab1COP.NonVisualComponents;
using OnlineStoreView.Plugins;
using OnlineStoreDatabaseImplement.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsControlLibraryKutygin.VisualComponents;
using listBoxControlKutyginn;

using OnlineStoreDatabaseImplement.Models;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using lab1COP.NonVisualComponents.HelperModels;
using WindowsFormsControlLibrary.CustomUnvisualElements;
using WindowsFormsControlLibraryKutygin.NonVisualComponents;
using WindowsFormsControlLibraryKutygin.NonVisualComponents.HelperModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DocumentFormat.OpenXml.Drawing.Charts;
using Xceed.Document.NET;

namespace OnlineStoreView.Plugin
{
    public class MainPluginConvention : IPluginsConvention
    {
        private listBoxControl listBoxControl = new listBoxControl();
        private OrderLogic orderLogic = new OrderLogic();
        private DestinationCityLogic destinationCityLogic = new DestinationCityLogic();

        public MainPluginConvention()
        {
            listBoxControl.AddTemplate("{ClientName} {Id} {DestinationCity} {DestinationDate}                                                                                      {Track1}" +
                "{Track2} {Track3} {Track4} {Track5} {Track6}", '{' , '}');
            ReloadData();
        }
        public string PluginName
        {
            get
            {
                return "Заказы";
            }
        }
        public UserControl GetControl
        {
            get
            {
                return listBoxControl;
            }
        }

        public PluginsConventionElement GetElement
        {
            get
            {
                return listBoxControl.GetItem<PluginsConventionElement>();
            }
        }

        public bool DeleteElement(PluginsConventionElement element)
        {
            try
            {
                orderLogic.Delete(new OrderViewModel() { Id = element.Id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public void ReloadData()
        {
            var list = orderLogic.Read(null);
            listBoxControl.ClearList();
            listBoxControl.Add(list);
        }

        public Form GetForm(PluginsConventionElement element)
        {
            FormOrder formOrder = new FormOrder();
            if (element != null)
            {
                formOrder.Id = element.Id;
            }
            return formOrder;
        }
        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                TableComponent tc = new TableComponent();
                var orders = orderLogic.Read(null);

                string[,] strings = new string[orders.Count + 1, 6];
                strings[0, 0] = "Отметка 1";
                strings[0, 1] = "Отметка 2";
                strings[0, 2] = "Отметка 3";
                strings[0, 3] = "Отметка 4";
                strings[0, 4] = "Отметка 5";
                strings[0, 5] = "Отметка 6";
                for (int i = 0; i < orders.Count; ++i)
                {
                    strings[i + 1, 0] = orders[i].Track1;
                    strings[i + 1, 1] = orders[i].Track2;
                    strings[i + 1, 2] = orders[i].Track3;
                    strings[i + 1, 3] = orders[i].Track4;
                    strings[i + 1, 4] = orders[i].Track5;
                    strings[i + 1, 5] = orders[i].Track6;
                }
                tc.SaveTable(saveDocument.FileName, "Отметки о передвижении заказов", new List<string[,]>() { strings });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                var list = orderLogic.Read(null);
                ComponentExcelCustomizableTable cect = new ComponentExcelCustomizableTable();

                var dict = new Dictionary<string, int[]>();
                var arrayHeader = new List<string>() { "ФИО заказчика", "Номер заказа", "Город назначения", "Дата получения"};
                var arrayHeight = new List<int>() { 20, 30, 20, 20 };
                
                dict.Add("Заказ", new int[] { 2, 3 });

                var list1 = new List<OrderToTable>();

                foreach (var item in list)
                {
                    list1.Add(new OrderToTable
                    {
                        ClientName = item.ClientName,
                        Id = item.Id,
                        DestinationCity = item.DestinationCity,
                        DestinationDate = item.DestinationDate
                    });
                }
               
                cect.CreateFile(saveDocument.FileName, "Заказы", dict, arrayHeight, arrayHeader, list1);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            List<Test> chartSeriesList = new List<Test>();
            List<DateTime?> dates = new List<DateTime?>();
            WordLinearDiagramComponent wcld = new WordLinearDiagramComponent();
            try
            {
            var orders = orderLogic.Read(null);
            var cities = destinationCityLogic.Read(null);
            string[] xSeries = new string[cities.Count()];
            for (int i = 0; i < orders.Count; ++i)
            {
                if (!dates.Contains(orders[i].DestinationDate))
                {
                    dates.Add(orders[i].DestinationDate);
                }
            }
            for (int i = 0; i < dates.Count; ++i)
            {
                DateTime? name = dates[i];
                int kek = 0;
                double[] values = new double[xSeries.Length];
                for (int u = 0; u < xSeries.Length; ++u)
                {
                    int value = 0;
                    for (int j = 0; j < orders.Count; ++j)
                    {
                        if (orders[j].DestinationDate == name && orders[j].DestinationCity == xSeries[u])
                        {
                            value += 1;
                        }
                    }
                    kek = value;
                }
                 chartSeriesList.Add(new Test
                 {
                    name = name.ToString(),
                    value = kek
                });
            }

            wcld.Report(
                saveDocument.FileName,
                "Заказы по датам",  "диаграмма",
                ChartLegendPosition.Bottom,
                chartSeriesList
            );
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
