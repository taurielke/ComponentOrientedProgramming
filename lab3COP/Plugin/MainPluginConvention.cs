using lab1COP.Components;
using lab3COP.Plugins;
using OnlineStoreDatabaseImplement.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsControlLibraryKutygin.VisualComponents;
using OnlineStoreDatabaseImplement.Models;

namespace lab3COP.Plugin
{
    public class MainPluginConvention : IPluginsConvention
    {
        private ListBoxControl listBoxControl = new ListBoxControl();
        private OrderLogic orderLogic = new OrderLogic();
        private DestinationCityLogic destinationCityLogic = new DestinationCityLogic();
/*
        private MadyshevDataGridView dataGridView = new MadyshevDataGridView();
        private ProductLogic productLogic = new ProductLogic();
        private UnitMeasurementLogic unitMeasurementLogic = new UnitMeasurementLogic();*/
        public MainPluginConvention()
        {
            listBoxControl.AddTemplate("{ClientName},{Id},{DestinationCity},{Date}", '{' ,'}');
            //listBoxControl.Add(new List<Order>());
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
            listBoxControl.Add(list);

            /*listBoxControl.;
            var rows = productLogic.Read(null);
            for (int i = 0; i < rows.Count(); ++i)
            {
                dataGridView.AddRow<ProductConventionElement>(new ProductConventionElement()
                {
                    Country = rows[i].Country,
                    Name = rows[i].Name,
                    UnitMeasurement = rows[i].UnitMeasurement,
                    Id = (int)rows[i].Id
                });
            }*/
        }
        public Form GetForm(PluginsConventionElement element)
        {
            FormOrder formOrder = new FormOrder();
            if (element != null)
            {
                var kek = element.Id;
            }
            return formOrder;
        }
        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            /*try
            {
                MadyshevDocTablesComponent tablesComponent = new MadyshevDocTablesComponent();
                var products = productLogic.Read(null);
                string[,] strings = new string[products.Count + 1, 3];
                strings[0, 0] = "Поставщик 1";
                strings[0, 1] = "Поставщик 2";
                strings[0, 2] = "Поставщик 3";
                for (int i = 0; i < products.Count; ++i)
                {
                    strings[i + 1, 0] = products[i].ProviderOne;
                    strings[i + 1, 1] = products[i].ProviderTwo;
                    strings[i + 1, 2] = products[i].ProviderThree;
                }
                tablesComponent.CreateDoc(saveDocument.FileName, "Поставщики", new List<string[,]>() { strings });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }*/
            return true;
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            return true;
           /* try
            {
                var list = productLogic.Read(null);
                LipatovTablePdf lipatovTablePdf = new LipatovTablePdf();
                List<TableCell> firstColumn = new List<TableCell> {
                    new TableCell() {
                        Name = "Id",
                        RowHeight = "1cm",
                        PropertyName = "Id"
                    },
                    new TableCell() {
                        Name = "Название",
                        RowHeight = "1cm",
                        PropertyName = "Name"
                    },
                    new TableCell() {
                        Name = "Информация",
                        RowHeight = "3cm",
                        CountCells = 2
                    },
                    new TableCell() {
                        Name = "Поставщики",
                        RowHeight = "4cm",
                        CountCells = 3
                    },
                };
                List<TableCell> SecondColumn = new List<TableCell> {
                    new TableCell() {
                        Name = "Единицы измерения",
                        PropertyName = "UnitMeasurement"
                    },
                    new TableCell() {
                        Name = "Страна",
                        PropertyName = "Country"
                    },
                    new TableCell() {
                        Name = "Поставщик 1",
                        PropertyName = "ProviderOne"
                    },
                    new TableCell() {
                        Name = "Поставщик 2",
                        PropertyName = "ProviderTwo"
                    },
                    new TableCell() {
                        Name = "Поставщик 3",
                        PropertyName = "ProviderThree"
                    }
                };

                lipatovTablePdf.CreateDocument(new TableParameters<ProductViewModel>()
                {
                    Path = saveDocument.FileName,
                    Title = "Продукты",
                    CellsFirstColumn = firstColumn,
                    CellsSecondColumn = SecondColumn,
                    DataList = list
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }*/
        }
        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            return true;
           /* var products = productLogic.Read(null);
            var units = unitMeasurementLogic.Read(null);
            List<IlbekovLineChartExcel.ChartSeries> chartSeriesList = new List<IlbekovLineChartExcel.ChartSeries>();
            string[] xSeries = new string[units.Count()];
            for (int i = 0; i < units.Count; ++i)
            {
                xSeries[i] = units[i].Name;
            }
            List<string> countries = new List<string>();
            for (int i = 0; i < products.Count; ++i)
            {
                if (!countries.Contains(products[i].Country))
                {
                    countries.Add(products[i].Country);
                }
            }
            for (int i = 0; i < countries.Count; ++i)
            {
                string name = countries[i];
                double[] values = new double[xSeries.Length];
                for (int u = 0; u < xSeries.Length; ++u)
                {
                    double value = 0;
                    for (int j = 0; j < products.Count; ++j)
                    {
                        if (products[j].Country == name && products[j].UnitMeasurement == xSeries[u])
                        {
                            value += 1;
                        }
                    }
                    values[u] = value;
                }
                chartSeriesList.Add(new IlbekovLineChartExcel.ChartSeries
                {
                    Name = name,
                    Values = values
                });
            }
            var doc = new IlbekovLineChartExcel();
            doc.CreateFile(
                saveDocument.FileName,
                "Продукты по единицам измерений", "Продукты по странам",
                chartSeriesList,
                IlbekovLineChartExcel.LegendPosition.Bottom,
                _xSeries: xSeries
            );
            return true;*/
        }
    }
}
