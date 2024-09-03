using iTextSharp.text.pdf;
using iTextSharp.text;
using Libms.Models;

namespace Libms.Report
{
    public class MemberReport
    {

         

        #region Declaration
        int _totalColumn = 10;
        Document document;
        Font font;
        PdfPTable table = new PdfPTable(10);
        PdfPCell cell;
        MemoryStream _memoryStream = new MemoryStream();
        List<My_member> _mymembers = new List<My_member>();
        #endregion


        public byte[] PrepareMemberReport(List<My_member> mymembers)
        {

            _mymembers = mymembers;
            #region
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(40f, 40f, 40f, 40f);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            font = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(document, _memoryStream);
            document.Open();
            table.SetWidths(new float[] { 50f, 150f, 150f, 150f, 150f, 150f, 150f, 150f, 150f ,150f});
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
            cell.ExtraParagraphSpace = 10;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 9f, 1);
            cell = new PdfPCell(new Phrase("Member Report:", font));
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
            cell = new PdfPCell(new Phrase("S.N", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Member Name", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Member Type", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);






            cell = new PdfPCell(new Phrase("Member Gender", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Member Address", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);





            cell = new PdfPCell(new Phrase("Member Class", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Member Email", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Member Mobile No", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Year", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);




            cell = new PdfPCell(new Phrase("Semester", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            table.CompleteRow();

            #endregion


            #region Table Body
            font = FontFactory.GetFont("Tahoma", 8f, 0);
            int serialNumber = 1;
            foreach (var item in _mymembers)
            {

                cell = new PdfPCell(new Phrase(serialNumber++.ToString(), font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(item.Mname, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(item.Mtype, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);



                cell = new PdfPCell(new Phrase(item.Mgen, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(item.Maddr, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);





                cell = new PdfPCell(new Phrase(item.Mclass, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(item.Memail, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);



                cell = new PdfPCell(new Phrase(item.Mmob, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(item.Myear, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase(item.Msection, font));
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
