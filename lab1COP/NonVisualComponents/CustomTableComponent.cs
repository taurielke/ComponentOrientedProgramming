using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using lab1COP.NonVisualComponents.HelperModels;
using lab1COP.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace lab1COP.NonVisualComponents
{
    public partial class CustomTableComponent : Component
    {
        public CustomTableComponent()
        {
            InitializeComponent();
        }

        public CustomTableComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void SaveTable <T>(string folder, string docTitle, List<PdfColumnInfo> columns,
           PdfRowInfo[] rows, List<T> objList)
        {
            IsDataNotEmpty(objList);
            AreColumnsFull(columns);

            PdfPTable table = CreateTable(columns, rows, objList);
            FileStream fs = new FileStream(folder, FileMode.Create);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            document.Add(new Paragraph(docTitle));
            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }

        private PdfPTable CreateTable <T>(List<PdfColumnInfo> columns, PdfRowInfo[] rows, List<T> objList)
        {
            float[] widths = new float[columns.Count];
            bool widthsExist = true;
            foreach (var column in columns)
            {
                if (column.Width == null)
                {
                    widthsExist = false;
                }
            }
            if (widthsExist)
            {
                int index = 0;
                foreach (var column in columns)
                {
                    widths[index] = (float)column.Width;
                    index++;
                }
            }
            bool heightsExist = true;
            foreach (var row in rows)
            {
                if (row.Height == null)
                {
                    heightsExist = false;
                }
            }

            PdfPTable table = new PdfPTable(columns.Count);

            if (widthsExist)
            {
                table.LockedWidth = true;
                table.SetTotalWidth(widths);
            }

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font font = new Font(bfTimes, 16, Font.BOLD);
            foreach (var column in columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.Name, font));
                if (heightsExist) cell.MinimumHeight = (float)rows[0].Height;
                table.AddCell(cell);
            }

            foreach (var item in objList)
            {
                foreach (var column in columns)
                {
                    PropertyInfo propertyInfo = item.GetType().GetProperty(column.PropertyName);
                    string value = propertyInfo.GetValue(item).ToString();
                    PdfPCell cell = new PdfPCell(new Phrase(value));
                    if (heightsExist) cell.MinimumHeight = (float)rows[0].Height;
                    table.AddCell(cell);
                }
            }

            foreach (var row in table.Rows)
            {
                PdfPCell cell = row.GetCells()[0];
                string text = cell.Phrase.Content;
                PdfPCell newcell = new PdfPCell(new Phrase(text, font));
                row.GetCells()[0] = newcell;
            }

            return table;
        }

        private void IsDataNotEmpty <T>(List<T> objList)
        {
            if (objList.Count == 0) throw new Exception("list is empty");
        }

        private void AreColumnsFull(List<PdfColumnInfo> columns)
        {
            foreach (PdfColumnInfo column in columns)
            {
                if (column.Name == null || column.PropertyName == null)
                {
                    throw new Exception("fill in the columns");
                }
            }
        }
    }
}
