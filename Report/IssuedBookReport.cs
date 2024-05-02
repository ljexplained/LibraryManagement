using iTextSharp.text.pdf;
using iTextSharp.text;
using Libms.Models;
namespace Libms.Report
{
    public class IssuedBookReport
    {



        #region Declaration
        int _totalColumn = 10;
        Document document;
        Font font;
        PdfPTable table = new PdfPTable(10);
        PdfPCell cell;
        MemoryStream _memoryStream = new MemoryStream();
        List<Mybooks> _books = new List<Mybooks>();
        #endregion


        public byte[] PrepareIssuedBookReport(List<Mybooks> books)
        {

            _books = books;
            #region
            document = new Document(PageSize.A4_LANDSCAPE, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4_LANDSCAPE);
            document.SetMargins(40f, 40f, 40f, 40f);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            font = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(document, _memoryStream);
            document.Open();
            table.SetWidths(new float[] { 50f, 100f, 100f, 100f, 100f,
                100f, 100f, 100f, 100f, 100f
                //, 50f, 50f,
                //50f, 50f, 50f, 50f, 50f, 50f
            
            
            });
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
            cell = new PdfPCell(new Phrase("Issued Book Report:", font));
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
            cell.Padding = 3;
            table.AddCell(cell);



            //cell = new PdfPCell(new Phrase("ISBN No", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Accession No", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);





            //cell = new PdfPCell(new Phrase("Register", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);



            cell = new PdfPCell(new Phrase("Book Name", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);




            cell = new PdfPCell(new Phrase("Author", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);




            //cell = new PdfPCell(new Phrase("Publication Year", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);





            cell = new PdfPCell(new Phrase("Edition No", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);



            //cell = new PdfPCell(new Phrase("No Of Pages", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);





            cell = new PdfPCell(new Phrase("Book Price", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);


            //cell = new PdfPCell(new Phrase("Book Title", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);




            //cell = new PdfPCell(new Phrase("Publication Name", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);



            //cell = new PdfPCell(new Phrase("Quanity", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);





            //cell = new PdfPCell(new Phrase("Book Sub Title", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);





            //cell = new PdfPCell(new Phrase("Sub Author Name", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);



            //cell = new PdfPCell(new Phrase("Book Source", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);





            //cell = new PdfPCell(new Phrase("Bill No", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);




            //cell = new PdfPCell(new Phrase("Col No", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);




            //cell = new PdfPCell(new Phrase("Shelf No", font));
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cell.BackgroundColor = BaseColor.WHITE;
            //table.AddCell(cell);




            cell = new PdfPCell(new Phrase("Language", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);




            cell = new PdfPCell(new Phrase("Book Issue Date", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Book Return Date", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Member Name", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);


            table.CompleteRow();

            #endregion


            #region Table Body
            font = FontFactory.GetFont("Tahoma", 8f, 0);
            int serialNumber = 1;
            foreach (var _mybooks in _books)
            {

                cell = new PdfPCell(new Phrase(serialNumber++.ToString(), font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                cell.Padding = 10;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(_mybooks.Bacessno, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(_mybooks.Bname, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase(_mybooks.Bauthor, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);



                cell = new PdfPCell(new Phrase(_mybooks.Bedno, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);




                //cell = new PdfPCell(new Phrase(_mybooks.Bnop, font));
                //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cell.BackgroundColor = BaseColor.WHITE;
                //table.AddCell(cell);



                cell = new PdfPCell(new Phrase(_mybooks.Bprice+" Rs", font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);



                //cell = new PdfPCell(new Phrase(_mybooks.Bpubname, font));
                //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cell.BackgroundColor = BaseColor.WHITE;
                //table.AddCell(cell);



                //cell = new PdfPCell(new Phrase(_mybooks.Bqty.ToString(), font));
                //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cell.BackgroundColor = BaseColor.WHITE;
                //table.AddCell(cell);



                //cell = new PdfPCell(new Phrase(_mybooks.Bbillno, font));
                //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cell.BackgroundColor = BaseColor.WHITE;
                //table.AddCell(cell);

                //cell = new PdfPCell(new Phrase(_mybooks.Bshelfno, font));
                //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cell.BackgroundColor = BaseColor.WHITE;
                //table.AddCell(cell);



                cell = new PdfPCell(new Phrase(_mybooks.Blang, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase(_mybooks.isdate, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase(_mybooks.rtdate, font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);



                cell = new PdfPCell(new Phrase(_mybooks.mname, font));
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
 