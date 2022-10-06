using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using lab1COP.NonVisualComponents.HelperModels;
using System;
using System.ComponentModel;
using Page = ceTe.DynamicPDF.Page;

namespace lab1COP.NonVisualComponents
{
    public partial class HistogramComponent : Component
    {
        public HistogramComponent()
        {
            InitializeComponent();
        }

        public HistogramComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void SaveHistogram(string folder, string docTitle, string histTitle,
           LegendfInfo legend, HistogramInfo histogramInfo)
        {

            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 100, 400, 230);
            PlotArea plotArea = chart.PrimaryPlotArea;

            Label label = new Label(docTitle, 0, 0, 500, 30, Font.TimesRoman, 18, TextAlign.Center);
            page.Elements.Add(label);

            Title histogramTitle = new Title(histTitle);
            chart.HeaderTitles.Add(histogramTitle);

            IndexedBarSeries barSeries = null;
            AutoGradient autogradient = new AutoGradient(180f, CmykColor.Red, CmykColor.IndianRed);

            foreach (var item in histogramInfo.Data)
            {
                if (item.Value.Length < 1)
                {
                    throw new Exception("Input data is empty!");
                }
                barSeries = new IndexedBarSeries(item.Key);
                barSeries.Values.Add(item.Value);
                barSeries.Color = autogradient;
                plotArea.Series.Add(barSeries);
            }

            for (int i = 0; i < histogramInfo.Data.Count; i++)
            {
                barSeries.YAxis.Labels.Add(new IndexedYAxisLabel((i + 1).ToString(), i));
            }

            chart.Legends.Placement = (LegendPlacement)legend;
            page.Elements.Add(chart);
            document.Draw(folder);
        }
    }
}
