﻿using iTextSharp.text.pdf;
using iTextSharp.text;
using Libms.Models;
using System.Data.SqlClient;

namespace Libms.Report
{
    public class BookCategoryReport
    {


        #region Declaration
        int _totalColumn = 3;
        Document document;
        Font font;
        PdfPTable table = new PdfPTable(3);
        PdfPCell cell;
        MemoryStream _memoryStream = new MemoryStream();
        List<BookCategory> _bookcategory = new List<BookCategory>();
        #endregion


        public byte[] PrepareBCReport(List<BookCategory> bookcategory)
        {

            _bookcategory = bookcategory;
            #region
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(40f, 40f, 40f, 40f);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            font = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(document, _memoryStream);
            document.Open();
            table.SetWidths(new float[] { 50f, 150f, 150f});
            #endregion

            this.ReportHeader();
            this.ReportBody();
            table.HeaderRows = 2;
            document.Add(table);
            document.Close();
            return _memoryStream.ToArray();
        }




        private void ReportHeader()
        {



            //string conn = "Data Source=DESKTOP-6LQD0UJ\\SQLEXPRESS;Initial Catalog=MyUser;Integrated Security=True";
            //SqlConnection sqlConnection = new SqlConnection(conn);
            //sqlConnection.Open();

            font = FontFactory.GetFont("Tahoma", 16f, 1);
            cell = new PdfPCell(new Phrase("DPBS Library", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 50;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 9f, 1);
            cell = new PdfPCell(new Phrase("Book Category Report:", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);
            table.CompleteRow();

        }



        private void ReportBody()
        {

            #region Table header
            font = FontFactory.GetFont("Tahoma", 8f, 1);
            cell = new PdfPCell(new Phrase("Serial Number", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Category Name", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Remark", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);

            table.CompleteRow();

            #endregion


            #region Table Body
            font = FontFactory.GetFont("Tahoma", 8f, 0);
            int serialNumber = 1;
            foreach (var item in _bookcategory)
            {

                cell = new PdfPCell(new Phrase(serialNumber++.ToString(), font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(item.Bcname, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(item.Bcname, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                table.CompleteRow();


            }
            #endregion





        }








    }
}