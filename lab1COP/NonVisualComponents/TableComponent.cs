using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using Section = MigraDoc.DocumentObjectModel.Section;

namespace lab1COP.NonVisualComponents
{
    public partial class TableComponent : Component
    {
        public TableComponent()
        {
            InitializeComponent();
        }

        public TableComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Obsolete]
        public void SaveTable(string folder, string docTitle, List<string[,]> tables)
        {
            if (!IsFull(tables))
            {
                throw new Exception("the table is somewhere empty");
            }

            var document = new Document();

            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(docTitle);
            paragraph.Format.SpaceAfter = 15;
            paragraph.Format.Alignment = ParagraphAlignment.Left;

            foreach (string[,] strings in tables)
            {
                var table = document.LastSection.AddTable();
                table.Borders.Width = 1;
                for (int i = 0; i < strings.GetLength(1); i++)
                {
                    table.AddColumn();
                }

                for (int i = 0; i < strings.GetLength(0); i++)
                {
                    var row = table.AddRow();
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        row.Cells[j].AddParagraph(strings[i, j]);
                    }
                }
                Paragraph prg = section.AddParagraph();
                prg.Format.SpaceAfter = 15;
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(folder);
        }

        private Boolean IsFull(List<string[,]> tables)
        {
            foreach (string[,] table in tables)
            {
                foreach (string str in table)
                {
                    if (str == null) return false;
                }
            }
            return true;
        }
    }
}
