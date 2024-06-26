﻿using iTextSharp.text.pdf;
using iTextSharp.text;
using Libms.Models;
using System.Data.SqlClient;

namespace Libms.Report
{
    public class CollegeReport
    {

        #region Declaration
        int _totalColumn = 7;
        Document document;
        Font font;
        PdfPTable table = new PdfPTable(7);
        PdfPCell cell;
        MemoryStream _memoryStream = new MemoryStream();
        List<College> _college = new List<College>();
        #endregion


        public byte[] PrepareReport(List<College> college)
        {

            _college = college;
            #region
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(40f, 40f, 40f, 40f);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            font = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(document, _memoryStream);
            document.Open();
            table.SetWidths(new float[] { 50f, 150f, 150f, 150f, 150f, 150f, 150f});
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
            cell = new PdfPCell(new Phrase("College Report:", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);
            table.CompleteRow();


            //font = FontFactory.GetFont("Tahoma", 8f, 0);
            //cell = new PdfPCell(new Phrase(uname, font));
            //cell.Colspan = 4;
            //cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell.Border = 0;
            //cell.BackgroundColor = BaseColor.WHITE;
            //cell.ExtraParagraphSpace = 0;
            //table.AddCell(cell);
            //table.CompleteRow();


            //font = FontFactory.GetFont("Tahoma", 8f, 0);
            //cell = new PdfPCell(new Phrase(street, font));
            //cell.Colspan = 4;
            //cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell.Border = 0;
            //cell.BackgroundColor = BaseColor.WHITE;
            //cell.ExtraParagraphSpace = 0;
            //table.AddCell(cell);
            //table.CompleteRow();

            //font = FontFactory.GetFont("Tahoma", 8f, 0);
            //cell = new PdfPCell(new Phrase(city, font));
            //cell.Colspan = 4;
            //cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell.Border = 0;
            //cell.BackgroundColor = BaseColor.WHITE;
            //cell.ExtraParagraphSpace = 0;
            //table.AddCell(cell);
            //table.CompleteRow();

            //font = FontFactory.GetFont("Tahoma", 8f, 0);
            //cell = new PdfPCell(new Phrase(post, font));
            //cell.Colspan = 4;
            //cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell.Border = 0;
            //cell.BackgroundColor = BaseColor.WHITE;
            //cell.ExtraParagraphSpace = 0;
            //table.AddCell(cell);
            //table.CompleteRow();

            //font = FontFactory.GetFont("Tahoma", 8f, 0);
            //cell = new PdfPCell(new Phrase(phone, font));
            //cell.Colspan = 4;
            //cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell.Border = 0;
            //cell.BackgroundColor = BaseColor.WHITE;
            //cell.ExtraParagraphSpace = 0;
            //table.AddCell(cell);
            //table.CompleteRow();

            //font = FontFactory.GetFont("Tahoma", 8f, 0);
            //cell = new PdfPCell(new Phrase("Order Date:" + orderdate, font));
            //cell.Colspan = 4;
            //cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //cell.Border = 0;
            //cell.BackgroundColor = BaseColor.WHITE;
            //cell.ExtraParagraphSpace = 0;
            //table.AddCell(cell);
            //table.CompleteRow();

            //font = FontFactory.GetFont("Tahoma", 8f, 0);
            //cell = new PdfPCell(new Phrase("Order Number:" + id, font));
            //cell.Colspan = 4;
            //cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //cell.Border = 0;
            //cell.BackgroundColor = BaseColor.WHITE;
            //cell.ExtraParagraphSpace = 20;
            //table.AddCell(cell);


            //table.CompleteRow();



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



            cell = new PdfPCell(new Phrase("College Name", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("College Address", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);





            cell = new PdfPCell(new Phrase("College Contact No", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Contact Person Name", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);




            cell = new PdfPCell(new Phrase("Contact Person Email", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);




            cell = new PdfPCell(new Phrase("Contact Person Mobile", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            table.CompleteRow();

            #endregion


            #region Table Body
            font = FontFactory.GetFont("Tahoma", 8f, 0);
            int serialNumber = 1;
            foreach (var myCollege in _college)
            {

                cell = new PdfPCell(new Phrase(serialNumber++.ToString(), font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(myCollege.ColName, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(myCollege.Coladdr, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase(myCollege.Colmobile, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);



                cell = new PdfPCell(new Phrase(myCollege.Conpername, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);




                cell = new PdfPCell(new Phrase(myCollege.Coperemail, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);



                cell = new PdfPCell(new Phrase(myCollege.Conpermobie, font));
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
