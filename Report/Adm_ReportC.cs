using iTextSharp.text.pdf;
using iTextSharp.text;
using Libms.Models;

namespace Libms.Report
{
    public class Adm_ReportC
    {
         

        #region Declaration
        int _totalColumn = 2;
        Document document;
        Font font;
        PdfPTable table = new PdfPTable(2);
        PdfPCell cell;
        MemoryStream _memoryStream = new MemoryStream();
        List<My_session> _mysession = new List<My_session>();
        #endregion


        public byte[] PrepareAdmissionReport(List<My_session> mysession)
        {

            _mysession = mysession;
            #region
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(40f, 40f, 40f, 40f);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            /*BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            font = FontFactory.GetFont("Arial", 28f, Color.Black);
            Font times = new Font(bfTimes, 12, Font.ITALIC, Color.RED);*/


            //font = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(document, _memoryStream);
            document.Open();
            table.SetWidths(new float[] { 80f, 120f});
            #endregion

            this.ReportHeader();
            this.ReportBody();
            this.ReportBody1();
            table.HeaderRows = 2;
            document.Add(table);
            document.Close();
            return _memoryStream.ToArray();
        }




        private void ReportHeader()
        {



            font = FontFactory.GetFont("Arial", 16f, BaseColor.BLACK);
            cell = new PdfPCell(new Phrase("DPBS Library", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 50;
            table.AddCell(cell);
            table.CompleteRow();

        }



        private void ReportBody()
        {

            #region Table header
            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE); 
            cell = new PdfPCell(new Phrase("Official Information", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.GRAY;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);



            

            table.CompleteRow();

            #endregion


            #region Table Body
            font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);

            cell = new PdfPCell(new Phrase("Session", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 2;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Jan-2018", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 2;
            table.AddCell(cell);

            table.CompleteRow();

            cell = new PdfPCell(new Phrase("Programme", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 2;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("BCA", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 2;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("Enrollment No", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 2;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 2;
            table.AddCell(cell);

            table.CompleteRow();

            #endregion





        }


        private void ReportBody1()
        {

            #region Table header

            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell = new PdfPCell(new Phrase(" ", font));
            cell.Border = 0;    
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = -5;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell = new PdfPCell(new Phrase("Personal Information", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.GRAY;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);





            table.CompleteRow();

            #endregion


            #region Table Body
            font = FontFactory.GetFont("Arial", 13f, BaseColor.BLACK);

            cell = new PdfPCell(new Phrase("University Registration No", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();

            cell = new PdfPCell(new Phrase("Admission Category", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("Merit", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("Name Of Student", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("Nationality", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Gender", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("Category", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();




            cell = new PdfPCell(new Phrase("Sub Category", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();

            cell = new PdfPCell(new Phrase("Permanent Address", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Participated in Sports", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Marital State", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("NCC", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Scouts/Guides", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Hostel Required", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();

            cell = new PdfPCell(new Phrase("Email Id", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("WhatsApp No", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();





            #endregion





        }





















    }
}
